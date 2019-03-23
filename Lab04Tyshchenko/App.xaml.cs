using Lab04Tyshchenko.Model;
using Lab04Tyshchenko.Navigation;
using Lab04Tyshchenko.Windows;
using System.Windows;

namespace Lab04Tyshchenko
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Storage storage = new Storage();
            ContentWindow contentWindow = new ContentWindow();

            NavigationModel navigationModel = new NavigationModel(contentWindow, storage);
            NavigationManager.Instance.Initialize(navigationModel);
            contentWindow.Show();
            navigationModel.Navigate(ModesEnum.Main);
        }
    }
}
