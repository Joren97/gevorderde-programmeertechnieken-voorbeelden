using Generics_WPF.ViewModels;
using Generics_WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Generics_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainView mainView = new MainView();
            MainViewModel mainViewModel = new MainViewModel();
            mainView.DataContext = mainViewModel;
            mainView.Show();
        }
    }
}
