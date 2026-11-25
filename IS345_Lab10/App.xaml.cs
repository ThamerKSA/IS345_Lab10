using Microsoft.Extensions.DependencyInjection;

namespace IS345_Lab10
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromArgb("#512BD4"),
                BarTextColor = Colors.White
            });
        }
    }
}
