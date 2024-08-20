using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace EOL_FILE
{
    public static class ExcelInspector
    {
        public static string InspectExcelFile(string filePath)
        {
            Application xlApp = new Application();
            Workbook xlWorkbook = null;
            string info = $"Archivo: {filePath}\n";

            try
            {
                xlWorkbook = xlApp.Workbooks.Open(filePath);
                info += $"Número de hojas: {xlWorkbook.Sheets.Count}\n\n";

                foreach (Worksheet sheet in xlWorkbook.Sheets)
                {
                    Range xlRange = sheet.UsedRange;
                    info += $"Hoja: {sheet.Name}\n";
                    info += $"Número de filas: {xlRange.Rows.Count}\n";
                    info += $"Columnas: ";

                    // Identificar la columna de Fixture ID
                    int fixtureIDColumn = 18; // Columna R (índice base 1)
                    for (int col = 1; col <= xlRange.Columns.Count; col++)
                    {
                        object cellValue = ((Range)xlRange.Cells[1, col]).Value2;
                        if (cellValue != null && cellValue.ToString().Equals("Fixture ID", StringComparison.OrdinalIgnoreCase))
                        {
                            fixtureIDColumn = col;
                            break;
                        }
                    }

                    if (fixtureIDColumn != -1)
                    {
                        SeparateByFixtureID(filePath, xlApp, xlWorkbook, sheet, xlRange, fixtureIDColumn);
                    }
                }

                return info;
            }
            catch (Exception ex)
            {
                return $"Error al inspeccionar el archivo Excel: {ex.Message}";
            }
            finally
            {
                // Cerrar y liberar recursos de Excel
                xlWorkbook?.Close(false);
                xlApp?.Quit();

                if (xlWorkbook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                }
                if (xlApp != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                }
            }
        }

        private static void SeparateByFixtureID(string originalFilePath, Application xlApp, Workbook xlWorkbook, Worksheet sheet, Range xlRange, int fixtureIDColumn)
        {
            try
            {
                // Crear un diccionario para almacenar rangos por Fixture ID
                Dictionary<string, List<int>> fixtureRows = new Dictionary<string, List<int>>();

                // Recorrer las filas para separar por Fixture ID
                for (int row = 2; row <= xlRange.Rows.Count; row++)
                {
                    object fixtureIDValue = ((Range)xlRange.Cells[row, fixtureIDColumn]).Value2;
                    if (fixtureIDValue != null)
                    {
                        string fixtureID = fixtureIDValue.ToString();
                        if (!fixtureRows.ContainsKey(fixtureID))
                        {
                            fixtureRows[fixtureID] = new List<int>();
                        }
                        fixtureRows[fixtureID].Add(row);
                    }
                }

                if (fixtureRows.Count == 0)
                {
                    return; // No crear archivo si no hay datos
                }

                // Obtener fecha de creación del archivo original
                DateTime creationDate = File.GetCreationTime(originalFilePath);

                // Obtener primer y último Work ID
                var workIDs = new List<string>();
                for (int row = 2; row <= xlRange.Rows.Count; row++)
                {
                    object workIDValue = ((Range)xlRange.Cells[row, 11]).Value2; // Columna K (índice base 1)
                    if (workIDValue != null)
                    {
                        workIDs.Add(workIDValue.ToString());
                    }
                }
                string firstWorkID = workIDs.FirstOrDefault() ?? "Unknown";
                string lastWorkID = workIDs.LastOrDefault() ?? "Unknown";

                // Crear directorio de logs
                string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Log");
                Directory.CreateDirectory(logDirectory);

                // Crear un nuevo archivo Excel con hojas combinadas para cada Fixture ID
                Workbook newWorkbook = xlApp.Workbooks.Add();

                foreach (var kvp in fixtureRows)
                {
                    string fixtureID = kvp.Key;
                    List<int> rows = kvp.Value;

                    if (rows.Count == 0)
                    {
                        continue; // No crear hoja si no hay datos
                    }

                    // Crear una nueva hoja para el Fixture ID actual
                    Worksheet newWorksheet = (Worksheet)newWorkbook.Sheets.Add();
                    newWorksheet.Name = $"Fixture_{fixtureID}";

                    // Copiar los datos al nuevo archivo Excel
                    for (int i = 0; i < rows.Count; i++)
                    {
                        Range sourceRange = sheet.Rows[rows[i]];
                        Range destinationRange = newWorksheet.Rows[i + 1];
                        sourceRange.Copy(destinationRange);
                    }

                    // Agregar encabezados
                    for (int col = 1; col <= xlRange.Columns.Count; col++)
                    {
                        newWorksheet.Cells[1, col] = ((Range)xlRange.Cells[1, col]).Value2;
                    }

                    // Crear tablas y gráficos para el Fixture ID actual en la misma hoja
                    CreateTablesAndChartsForFixtureID(newWorksheet, xlRange);
                }

                // Formatear el nombre del nuevo archivo
                string newFileName = $"{Path.GetFileNameWithoutExtension(originalFilePath)}_{creationDate:yyyyMMdd}_{firstWorkID}_{lastWorkID}.xlsx";
                string newFilePath = Path.Combine(logDirectory, newFileName);

                // Guardar el archivo
                newWorkbook.SaveAs(newFilePath);
                newWorkbook.Close(false);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(newWorkbook);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al separar por Fixture ID y crear archivos de log: {ex.Message}");
            }
        }

        private static void CreateTablesAndChartsForFixtureID(Worksheet dataSheet, Range xlRange)
        {
            try
            {
                // Crear tablas y gráficos para el Fixture ID actual en la misma hoja
                int startRow = dataSheet.UsedRange.Rows.Count + 2;

                // Ejemplo de creación de tablas y gráficos
                CreateAverageTableAndChart(dataSheet, startRow, "Align MA", xlRange);
                startRow += 17; // Ajustar el salto según el número de filas agregadas
                CreateAverageTableAndChart(dataSheet, startRow, "Align MH", xlRange);
                startRow += 17;
                CreateAverageTableAndChart(dataSheet, startRow, "Align MV", xlRange);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear tablas y gráficos para el Fixture ID: {ex.Message}");
            }
        }

        private static void CreateAverageTableAndChart(Worksheet dataSheet, int startRow, string alignType, Range xlRange)
        {
            try
            {
                // Encontrar la columna inicial para el tipo de alineación específico
                int alignColumnStart = -1;
                for (int col = 1; col <= xlRange.Columns.Count; col++)
                {
                    object cellValue = ((Range)xlRange.Cells[1, col]).Value2;
                    if (cellValue != null && cellValue.ToString().StartsWith(alignType, StringComparison.OrdinalIgnoreCase))
                    {
                        alignColumnStart = col;
                        break;
                    }
                }

                if (alignColumnStart == -1)
                {
                    return; // No se encontraron columnas para el tipo de alineación
                }

                // Nombre de la tabla de promedios
                string tableName = $"{alignType} Averages";

                // Calcular y escribir promedios en la hoja de datos
                for (int i = 0; i < 9; i++)
                {
                    var colRange = dataSheet.Range[dataSheet.Cells[2, alignColumnStart + i], dataSheet.Cells[dataSheet.UsedRange.Rows.Count, alignColumnStart + i]];
                    dataSheet.Cells[startRow, i + 1] = $"=AVERAGE({colRange.Address})";
                }

                // Crear gráfico en la misma hoja
                ChartObjects chartObjects = (ChartObjects)dataSheet.ChartObjects(Type.Missing);
                ChartObject chartObject = chartObjects.Add(60, startRow * 15, 300, 200);
                Chart chart = chartObject.Chart;
                Range chartRange = dataSheet.Range[dataSheet.Cells[startRow, 1], dataSheet.Cells[startRow, 9]];
                chart.SetSourceData(chartRange, Type.Missing);
                chart.ChartType = XlChartType.xlLine; // Tipo de gráfico (puedes cambiarlo según tu preferencia)
                chart.HasTitle = true;
                chart.ChartTitle.Text = tableName; // Título del gráfico

                // Estilo de tabla en la hoja de datos
                Range tableRange = dataSheet.Range[dataSheet.Cells[startRow, 1], dataSheet.Cells[startRow, 9]];
                tableRange.Font.Bold = true;
                tableRange.Borders.LineStyle = XlLineStyle.xlContinuous;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear tabla y gráfico para el tipo de alineación {alignType}: {ex.Message}");
            }
        }



    }
}
