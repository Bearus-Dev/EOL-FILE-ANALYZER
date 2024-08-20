using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace EOL_FILE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de Excel|*.xls;*.xlsx",
                Title = "Selecciona un archivo Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textBoxFilePath.Text = filePath; // Mostrar la ruta del archivo en el TextBox

                // Extraer la estructura del archivo y mostrar detalles
                string structure = ExcelInspector.InspectExcelFile(filePath);
                textBoxFileInfo.Text = $"Archivo: {filePath}\n\n{structure}";
            }
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            string filePath = textBoxFilePath.Text.Trim();

            if (!string.IsNullOrEmpty(filePath))
            {
                // Extraer la estructura del archivo y mostrar detalles
                string structure = ExcelInspector.InspectExcelFile(filePath);
                textBoxFileInfo.Text = $"Archivo: {filePath}\n\n{structure}";
            }
            else
            {
                MessageBox.Show("Por favor selecciona un archivo Excel primero.", "Archivo no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir ventana de opciones aquí
         
        }

        private void infoInEnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar información en inglés aquí
            MessageBox.Show("Heliophant Studio, created by Bearus-Dev.\nVisit our GitHub: https://github.com/Bearus-Dev",
                            "About Heliophant Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void analyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Redibujar el formulario (opcional, en este caso no hace nada específico)
            Invalidate();
        }
    }
}
