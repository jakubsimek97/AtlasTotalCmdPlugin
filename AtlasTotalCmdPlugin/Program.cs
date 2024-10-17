using TCPoints.GUI;

namespace TCPoints
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string path;
            if (args.Length == 0)
                path = "w:\\smay\\chocen.bod";
            else
                path = args[0] + args[1];

            MainPage mainPage = new MainPage(path);
            mainPage.ShowDialog();
        }
    }
}