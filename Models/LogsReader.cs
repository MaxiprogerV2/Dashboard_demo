using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AspExample_v1._0.Models
{
    public class LogsReader
    {
        string myPath = @"D:\c# projects\asp.net framework\AspExamples\LogsExamples";
        List<string> TimeWork = new List<string>();
        private List<string> GetLogs(string RobotName)
        {
            using (StreamReader sr = new StreamReader(Path.Combine(myPath, RobotName+".txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    TimeWork.Add(line);
                }
            }
            return TimeWork;
        }

        public KeyValuePair<string, string> GetCurrentStatus(string RobotName)
        {
            string lastRow = GetLogs(RobotName).Last();

            Regex regex = new Regex(@"(?<time>\d{2}:\d{2}:\d{2})/(?<status>\S+)");
            Match match = regex.Match(lastRow);

            return new KeyValuePair<string, string>(match.Groups["time"].Value, match.Groups["status"].Value);
        }
        public  string GetLastStatus(string RobotName)
        {
            string lastRow = GetLogs(RobotName).Last();

            Regex regex = new Regex(@"(?<time>\d{2}:\d{2}:\d{2})/(?<status>\S+)");
            Match match = regex.Match(lastRow);

            return match.Groups["status"].Value;
        }

        public List<string> getAllRobots()
        {
            var robots = new List<string>();
            var files = Directory.GetFiles(myPath);
            foreach(var f in files)
            {
                var tmp = f.Split('\\');
                robots.Add(tmp.Last().Replace(".txt",""));
            }
            return robots;
        }

        public Dictionary<string, string> getInfo()
        {
            var info = new Dictionary<string,string>();
            var robots = getAllRobots();
            foreach (var r in robots)
                info.Add(r, GetLastStatus(r));

            return info;
        }
    }
}