﻿using System.Text.Json;
using IT.Mechanic.App.Services.Profiles;
using IT.Mechanic.App.Services.Settings;

namespace IT.Mechanic.App
{
    public partial class MainPage : ContentPage
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ISettingsService _settingsService;
        private readonly IProfileService _profileService;
        private readonly IProfileFactory _profileFactory;

        public MainPage(
            JsonSerializerOptions jsonSerializerOptions,
            ISettingsService settingsService,
            IProfileService profileService,
            IProfileFactory profileFactory
        )
        {
            _jsonSerializerOptions = jsonSerializerOptions;
            _settingsService = settingsService;
            _profileService = profileService;
            _profileFactory = profileFactory;
            InitializeComponent();
        }
    }
}
