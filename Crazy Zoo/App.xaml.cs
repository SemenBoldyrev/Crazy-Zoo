using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Script;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Xaml;


namespace Crazy_Zoo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? Services;
        public App()
        {
            var sc = new ServiceCollection();

            sc.AddSingleton<ILogger, XmlLogger>();
            sc.AddSingleton<IAnimalDatabaseController, AnimalDatabaseController>();

            Services = sc.BuildServiceProvider();
        }
    }
}
