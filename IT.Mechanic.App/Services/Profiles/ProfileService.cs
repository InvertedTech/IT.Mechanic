﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using IT.Mechanic.App.Services.Settings;
using IT.Mechanic.Models.Configuration;

namespace IT.Mechanic.App.Services.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly ISettingsService _settingsService;
        private readonly JsonSerializerOptions _jsonOptions;
        public IEnumerable<MainModel> Profiles { get; set; }

        public ProfileService(ISettingsService settingsService, JsonSerializerOptions jsonOptions)
        {
            _settingsService = settingsService;
            _jsonOptions = jsonOptions;
            Profiles = new List<MainModel>();
            InitializeProfiles();
        }

        public async Task<MainModel?> GetProfileByIdAsync(string id)
        {
            var profileDirectory = _settingsService.Settings.ProfilesDirectory;
            var filePath = Path.Combine(profileDirectory, $"{id}.json");

            if (File.Exists(filePath))
            {
                try
                {
                    var jsonString = await File.ReadAllTextAsync(filePath);
                    return JsonSerializer.Deserialize<MainModel>(jsonString, _jsonOptions);
                }
                catch (JsonException jsonEx)
                {
                    // Handle JSON deserialization errors
                    Console.WriteLine($"Error deserializing file {filePath}: {jsonEx.Message}");
                }
                catch (IOException ioEx)
                {
                    // Handle file I/O errors
                    Console.WriteLine($"Error reading file {filePath}: {ioEx.Message}");
                }
            }
            else
            {
                // Handle case where the file does not exist
                Console.WriteLine($"File not found: {filePath}");
            }

            return null;
        }

        private void InitializeProfiles()
        {
            var profileDirectory = _settingsService.Settings.ProfilesDirectory;

            if (Directory.Exists(profileDirectory))
            {
                var jsonFiles = Directory.GetFiles(profileDirectory, "*.json");

                if (jsonFiles.Length > 0)
                {
                    var profiles = new List<MainModel>();

                    foreach (var file in jsonFiles)
                    {
                        try
                        {
                            var jsonString = File.ReadAllText(file);
                            var profile = JsonSerializer.Deserialize<MainModel>(
                                jsonString,
                                _jsonOptions
                            );

                            if (profile != null)
                            {
                                profiles.Add(profile);
                                Console.WriteLine(profile.DNS.DomainName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error reading file {file}: {ex.Message}");
                        }
                    }

                    Profiles = profiles;
                }
            }
        }
    }
}
