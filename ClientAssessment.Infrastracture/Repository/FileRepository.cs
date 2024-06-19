using ClientAssessment.Core.Entities;
using ClientAssessment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientAssessment.Infrastracture.Repository
{
    public class FileRepository : IFileRepository
    {
        public IEnumerable<UserProfile> GetAllSettings(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<IEnumerable<UserProfile>>(jsonString);
        }

        public void SaveSettings(string filePath, IEnumerable<UserProfile> profiles)
        {
            string jsonString = JsonSerializer.Serialize(profiles, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
