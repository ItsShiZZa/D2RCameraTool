using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace D2RCameraTool
{
    public class AppConfig
    {
        private readonly string filePath;

        public AppConfig(string filePath) {
            this.filePath = filePath;
        }

        public Dictionary<string, string> Load() {
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (!File.Exists(filePath)) {
                MessageBox.Show("INI file does not exist.");
                return data;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines) {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";"))
                    continue;

                string[] parts = line.Split('=');
                if (parts.Length == 2) {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    data[key] = value;
                }
            }

            return data;
        }

        public void Save(Dictionary<string, string> data) {
            using (StreamWriter writer = new StreamWriter(filePath)) {
                foreach (var kvp in data) {
                    writer.WriteLine($"{kvp.Key}={kvp.Value}");
                }
            }
        }
    }
}