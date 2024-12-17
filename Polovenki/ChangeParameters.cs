using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Classes.RelativePath;

namespace Utilities.Classes
{
    public static class ChangeParameters
    {
        static string parametersFilePath = GetFullPath(@"Source\Parameters\Parameters.txt");
        
        public static void WriteParam(string nameParam, string valueParam) {
            using (StreamWriter writer = new StreamWriter(parametersFilePath, true))
            {
                writer.WriteLine(nameParam+" = " + "\""+valueParam + "\"");
            }
        }
        public static string ReadParam(string nameParam)
        {
            string ReadingValue = "NaN";
            string[] lines = File.ReadAllLines(parametersFilePath);
            string paramLine = lines.FirstOrDefault(line => line.StartsWith(nameParam));
            if (paramLine != null)
            {
                string value = paramLine.Split('=')[1].Trim('\'').Trim(';').Trim().ToLower();
                ReadingValue = value;
            }
            return ReadingValue;
        }

        public static void SetParamValue(string nameParam, string valueParam) {
            string[] lines = File.ReadAllLines(parametersFilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(nameParam))
                {
                    lines[i] = $"{nameParam} = \"{valueParam.ToString().ToLower()}\";";
                    break;
                }
            }
            File.WriteAllLines(parametersFilePath, lines);
        }
    }
}
