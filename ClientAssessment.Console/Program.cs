using ClientAssessment.Application.Services;
using ClientAssessment.Core.Entities;
using ClientAssessment.Core.Interfaces;
using ClientAssessment.Infrastracture.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;


internal class Program
{
    private static void Main(string[] args)
    {
        // Setup DI
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IFileRepository>(provider => new FileRepository())
            .BuildServiceProvider();

        // Resolve the service
        var fileRepository = serviceProvider.GetService<IFileRepository>();
        var profileServices = new UserProfileServices(fileRepository);

        var settings = "00000000";
        var settingsToCheck = 7;
        var output = profileServices.IsFunctionalityEnabled(settings, settingsToCheck);
        Console.WriteLine(output);

        settings = "00000010";
        settingsToCheck = 7;
        output = profileServices.IsFunctionalityEnabled(settings, settingsToCheck);
        Console.WriteLine(output);

        settings = "11111111";
        settingsToCheck = 4;
        output = profileServices.IsFunctionalityEnabled(settings, settingsToCheck);
        Console.WriteLine(output);


        string filePath = "userprofile.json";
        var userProfileToSave = new List<UserProfile>();
        userProfileToSave.Add(new UserProfile { Id = 1, Settings = "00000000" });
        userProfileToSave.Add(new UserProfile { Id = 2, Settings = "00000010" });
        profileServices.SaveSettings(filePath, userProfileToSave);

        var profiles = profileServices.GetAllSettings(filePath);
        Console.WriteLine(JsonSerializer.Serialize(profiles, new JsonSerializerOptions()));
    }
}