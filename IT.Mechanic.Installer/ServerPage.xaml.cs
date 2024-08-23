using IT.Mechanic.Installer.Services;
using IT.Mechanic.Models.Configuration;

namespace IT.Mechanic.Installer;

public partial class ServerPage : ContentPage
{
	private readonly ConfigService _configService;
	public ServerPage()
	{
		InitializeComponent();
        _configService = App.Current.Handler.MauiContext.Services.GetService<ConfigService>();
        BindingContext = _configService.Model;
    }

    public void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (_configService != null)
        {
            if (sender is RadioButton radioButton)
            {
                var selectedContent = radioButton.Content;
                var selectedProvider = ServerModel.GetHostingProviderFromName(selectedContent.ToString());
                _configService.Model.Server.HostingProvider = selectedProvider;
            }
        }
    }

    public async void OnNextClicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync("//ReviewBuild");
    }

    public async void OnBackClicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync("///DNS");
    }
}