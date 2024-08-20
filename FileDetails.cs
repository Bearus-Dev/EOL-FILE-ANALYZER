using System;
using System.IO;

namespace EOL_FILE
{
    public static class FileDetails
    {
        public static string GetFileDetails(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            string details = $"Nombre del archivo: {fileInfo.Name}\n";
            details += $"Ruta completa: {fileInfo.FullName}\n";
            details += $"Tamaño del archivo: {fileInfo.Length} bytes\n";
            details += $"Fecha de creación: {fileInfo.CreationTime}\n";
            details += $"Última modificación: {fileInfo.LastWriteTime}\n";
            return details;
        }
    }
}
