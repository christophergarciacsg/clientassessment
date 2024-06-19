using ClientAssessment.Application.Interfaces;
using ClientAssessment.Core.Entities;
using ClientAssessment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAssessment.Application.Services
{
    public class UserProfileServices : IUserProfileServices
    {
        private readonly IFileRepository _fileRepository;

        public UserProfileServices(IFileRepository fileRepository) {
            _fileRepository = fileRepository;
        }
        public bool IsFunctionalityEnabled(string settings, int functionalityToCheck)
        {
            
            int index = functionalityToCheck - 1;
            return settings[index] == '1';

        }
        public void SaveSettings(string filePath, IEnumerable<UserProfile> profiles)
        {
            _fileRepository.SaveSettings(filePath, profiles);
        }

        public IEnumerable<UserProfile> GetAllSettings(string filePath)
        {
            return _fileRepository.GetAllSettings(filePath);
        }
    }
}
