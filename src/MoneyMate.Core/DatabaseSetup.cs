
namespace MoneyMate.Core
{
    public static class DatabaseSetup
    {
        public static string DatabaseDesktopPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MoneyMate", "moneymate.db");
    }
}
