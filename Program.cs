namespace _4FunBike
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //starting point of the application

            ApplicationConfiguration.Initialize();
            Application.Run(new ShopApplication());
        }
    }
}