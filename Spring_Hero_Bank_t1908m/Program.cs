using Spring_Hero_Bank_t1908m.Controller;
using Spring_Hero_Bank_t1908m.Helper;
using Spring_Hero_Bank_t1908m.Model;
using Spring_Hero_Bank_t1908m.View;

namespace Spring_Hero_Bank_t1908m
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var menuControl = new MenuControl();
            menuControl.GenerateMainMenu();
            // var accountController = new AccountController();
            // accountController.Register();
            // SeedingHelper helper = new SeedingHelper();
            // helper.SeedAcount();
        }
    }
}