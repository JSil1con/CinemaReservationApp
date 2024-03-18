using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaReservationApp.Classes
{
    internal class FileHandler
    {
        private string _filePath;
        public FileHandler(string filePath)
        {
            _filePath = filePath;

            File.Create(filePath).Close();
        }

        public string Read()
        {
            return File.ReadAllText(_filePath);
        }

        public void Write(string content)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.Write(content);
            }
        }

        public string GetFilePath()
        {
            return _filePath;
        }
    }
}
