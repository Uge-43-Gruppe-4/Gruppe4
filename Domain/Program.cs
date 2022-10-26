using System.ComponentModel;

namespace Domain
{
    internal class Program
    {
        static int sleeper = 1500;

        static void Main(string[] args)
        {
            bool run = true;
            while (run)

            {
                Menu MainMenu = new Menu("Hej og velkommen til ElSystemet", 4); // Main Title for the Menu

                MainMenu.AddItem("Se el oversigt");
                MainMenu.AddItem("Prisberegner");
                MainMenu.AddItem("Luk program");

                switch (MainMenu.Selector("Vælg handling:")) //Selector that depends on the users input to show the correct thing
                {
                    case 0:
                        Console.Clear();

                        break;

                    case 1:
                        Console.Clear();

                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Konsolen lukker om 3... \n");
                        Thread.Sleep(sleeper);
                        Console.WriteLine("Konsolen lukker om 2... \n");
                        Thread.Sleep(sleeper);
                        Console.WriteLine("Konsolen lukker om 1... \n");
                        Thread.Sleep(sleeper);

                        run = false;
                        break;

                    default: // Default error handeling message.. comes when SELECTOR's input is letter or not 1-4
                        Console.WriteLine("How did you get here?");
                        break;
                }
            }
        }
    }
    }
