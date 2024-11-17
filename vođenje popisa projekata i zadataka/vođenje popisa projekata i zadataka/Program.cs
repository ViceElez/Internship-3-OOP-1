using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainMenuRunning = true;
            while (mainMenuRunning)
            {
                var projectTasksMapping = new Dictionary<Project, List<Task>>();
                Console.WriteLine("1 - Ispis svih projekata s pripadajućim zadacima\n2 - Dodavanje novog projekta\n3 - Brisanje projekta" +
                    "\n4 - Prikaz svih zadataka s rokom u sljedećih 7 dana\n5 - Prikaz  projekata filtriranih po status\n6 - Upravljanje pojedinim projektom\n" +
                    "7 - Izlaz iz aplikacije");
                var inputedRightOption = int.TryParse(Console.ReadLine(), out var optionForMainMenu);
                switch (optionForMainMenu)
                {
                    case 1:
                        {
                            ProjectsFunctions.listAllProjects(projectTasksMapping);
                            break;
                        }
                    case 2:
                        {
                            ProjectsFunctions.addNewProject(projectTasksMapping);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("3");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("4");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("5");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("6");
                            break;
                        }
                    case 7:
                        {
                            mainMenuRunning = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Krivi unos, molimo pokusajte ponovo.");
                            break;
                        }
                }
            }

        }

    }
}
