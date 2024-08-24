using IT.Mechanic.Installer.Services;

namespace IT.Mechanic.Installer.Pages.Credentials;

public partial class DigitalOceanCredentialsPage : ContentPage
{
    private readonly ConfigService _configService;

    public DigitalOceanCredentialsPage()
	{
		InitializeComponent();
        _configService = App.Current.Handler.MauiContext.Services.GetService<ConfigService>();
        BindingContext = _configService.Model;
    }

    public async void OnBackClicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync("///Server");
    }

    public async void OnNextClicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync("//DigitaloceanHostingPage");
    }

    private void apiKeyEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}