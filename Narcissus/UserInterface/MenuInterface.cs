using Narcissus.UserInterface;
using System.Drawing;
using System.Reflection;
using System.Text;

// E:\Source\Repos\Narcissus\Narcissus\bin\Debug\net7.0\Narcissus.dll

namespace Narcissus.MenuInterface
{
    public class MenuInterface : IUserInterface
    {
        private Assembly _assembly = null;

        public MenuInterface()
        {

        }

        public async Task<bool> Run()
        {
            string selection = "";

            while (selection.ToLower() != "q")
            {
                selection = MainMenu();

                switch (selection.ToLower())
                {
                    case "d":
                        DisplayInfo();
                        break;
                    case "l":
                        LoadAssembly();
                        break;
                    case "q":
                        Console.WriteLine("Good-bye.");
                        break;
                    default:
                        Console.WriteLine($"You entered: {selection}");
                        Console.WriteLine("Please try agian.");
                        break;
                }
            }

            return true;
        }

        private string MainMenu()
        {
            string selection = "";

            Console.WriteLine("Main functions:");
            Console.WriteLine("\tL:   Load an assembly");
            Console.WriteLine("\tD:   Display basic assembly info");
            Console.WriteLine("Test functions:");
            Console.WriteLine("\tT:   Run the tests");
            Console.WriteLine("\tTM:  Display the test menu");
            Console.WriteLine("Other:");
            Console.WriteLine("\tQ:   Quit");
            Console.Write("Enter your selection: ");

            selection = Console.ReadLine();

            return selection;
        }

        private bool LoadAssembly()
        {
            string assemplyName = "";

            Console.Write("Enter the full path of the assembly to load: ");
            assemplyName = Console.ReadLine();

            if (string.IsNullOrEmpty(assemplyName))
            {
                Console.WriteLine("The assembly name entered is null or empty.");
                return false;
            }

            _assembly = Assembly.LoadFrom(assemplyName);

            return true;
        }

        private void DisplayInfo()
        {
            if (_assembly== null)
            {
                Console.WriteLine("Can't display assembly info because assembly is null.");
                return;
            }

            Console.WriteLine($"Name: {_assembly.GetName().Name}");
            Console.WriteLine($"Version: {_assembly.GetName().Version}");

            foreach (Type type in _assembly.GetTypes())
            {
                Console.WriteLine($"\tType: {type.FullName}");
                Console.WriteLine($"\tProperties:");

                foreach (PropertyInfo propertyinfo in type.GetProperties())
                {
                    Console.WriteLine($"\t\t{propertyinfo.PropertyType} {propertyinfo.Name}");
                }

                Console.WriteLine($"\tMethods:");

                foreach (MethodInfo methodinfo in type.GetMethods())
                {
                    Console.WriteLine($"\t\tpublic {methodinfo.ReturnType} {methodinfo.Name}(...)");
                }

                foreach (MethodInfo methodinfo in type.GetMethods(BindingFlags.NonPublic))
                {
                    Console.WriteLine($"\t\tprivate {methodinfo.ReturnType} {methodinfo.Name}(...)");
                }

                Console.WriteLine($"\tConstructors:");

                foreach (ConstructorInfo constructorinfo in type.GetConstructors())
                {
                    Console.WriteLine($"\t\tpublic {constructorinfo.Name}(...)");
                }

                foreach (ConstructorInfo constructorinfo in type.GetConstructors(BindingFlags.NonPublic))
                {
                    Console.WriteLine($"\t\tprivate {constructorinfo.Name}(...)");
                }
            }
        }
    }
}
