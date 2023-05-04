
using System;
using Contract;

namespace implementation
{
    public class LogTxt : ILogger
    {
        public string Name { get; set; }
        public LogTxt() { }
        public LogTxt(string aName)
        {
            Name = aName;
        }

        public void Log(string toSave, string route)
        {
            string text = "Campo 1: " + toSave.ToString();
            Console.WriteLine($"Guarde texto: {text} en {toSave}");
            // System.IO.File.WriteAllText(@route, text);
        }
    }
}