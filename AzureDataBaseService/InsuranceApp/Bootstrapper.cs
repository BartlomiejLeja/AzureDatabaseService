using Prism.Unity;
using System.Windows;

namespace InsuranceApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() // tworzymy początek apki co się bedzie wyświetlało powłoke
        {
            return Container.TryResolve<MainWindow>(); //pierwsze co się wyświetla View MainWindow
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();//Pokazuje MainWindow
        }

        protected override void ConfigureContainer() //zarządznie kontenerami co kolwiek to znaczy
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<MainWindow>("MainWindow");
        }

    }
}
