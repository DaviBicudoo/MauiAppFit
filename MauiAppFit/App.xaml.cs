using MauiAppFit.Helpers;

namespace MauiAppFit
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper database;

        public App()
        {
            InitializeComponent();
        }

        public static SQLiteDataBaseHelper Database
        {
            get
            {
                if(database == null)
                {
                    database = new SQLiteDataBaseHelper(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamAppFit.db3"));
                }

                return database;
            }

            
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}