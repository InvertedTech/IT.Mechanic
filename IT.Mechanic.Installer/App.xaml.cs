﻿using IT.Mechanic.Installer.Services;
using IT.Mechanic.Models.Configuration;

namespace IT.Mechanic.Installer
{
    public partial class App : Application
    {
        public App(IConfigService _configService)
        {
            InitializeComponent();

            MainPage = new AppShell(_configService);
        }
    }
}
