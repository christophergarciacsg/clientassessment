using ClientAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAssessment.Core.Interfaces
{
    public interface IFileRepository
    {
        void SaveSettings(string filePath, IEnumerable<UserProfile> profiles);
        IEnumerable<UserProfile> GetAllSettings(string filePath);
    }
}
