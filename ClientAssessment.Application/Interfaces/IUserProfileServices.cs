using ClientAssessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAssessment.Application.Interfaces
{
    public interface IUserProfileServices
    {
        bool IsFunctionalityEnabled(string settings, int functionalityToCheck);

        void SaveSettings(string filePath, IEnumerable<UserProfile> profiles);
        IEnumerable<UserProfile> GetAllSettings(string filePath);
    }
}
