using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.utility
{
    class fileUploadHandler
    {
        public string filePath;
        public string fileUploadPath(String fileName)
        {
            filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            filePath = Directory.GetParent(filePath).FullName;
            filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
            //filePath += @"\config\TestMail.docx";
            filePath += @fileName;
            return filePath;
        }
    }
}
