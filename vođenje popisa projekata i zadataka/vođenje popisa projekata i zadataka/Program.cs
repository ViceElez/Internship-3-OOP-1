using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    public class Program
    {
        static void Main(string[] args)
        {
            var projectTasksMapping = new Dictionary<Project, List<Task>>();

            projectTasksMapping.Add(
     new Project("Razvoj web stranice", "Razvijanje responzivne web stranice", "Aktivan",
                 new DateTime(2024, 1, 1), new DateTime(2024, 6, 30)),
     new List<Task>
     {
        new Task("Dizajn početne stranice", "Kreirati vizualno privlačnu početnu stranicu", "Zavrsen",
                 "Razvoj web stranice", new DateTime(2024, 2, 1), 120),
        new Task("Postavljanje hostinga", "Konfigurirati hosting za web stranicu", "Aktivan",
                 "Razvoj web stranice", new DateTime(2024, 3, 15), 60),
        new Task("Razvoj stranice za kontakt", "Dodati obrazac za kontakt i podatke", "Na cekanju",
                 "Razvoj web stranice", new DateTime(2024, 4, 10), 90)
     }
 );

            projectTasksMapping.Add(
                new Project("Mobilna aplikacija", "Kreiranje cross-platform mobilne aplikacije", "Na cekanju",
                            new DateTime(2024, 2, 15), new DateTime(2024, 9, 30)),
                new List<Task>
                {
        new Task("Izrada žičanih okvira", "Dizajniranje žičanih okvira aplikacije", "Zavrsen",
                 "Mobilna aplikacija", new DateTime(2024, 11, 23), 100),
        new Task("Razvoj Backend API-a", "Izgraditi backend za aplikaciju", "Aktivan",
                 "Mobilna aplikacija", new DateTime(2024, 5, 10), 200),
        new Task("Implementacija autentifikacije", "Dodati sustav autentifikacije korisnika", "Na cekanju",
                 "Mobilna aplikacija", new DateTime(2024, 7, 15), 150)
                }
            );

            projectTasksMapping.Add(
                new Project("Analiza podataka", "Analiziranje prodajnih podataka za trendove", "Zavrsen",
                            new DateTime(2023, 11, 1), new DateTime(2024, 1, 31)),
                new List<Task>
                {
        new Task("Prikupljanje sirovih podataka", "Prikupiti prodajne podatke sa svih odjela", "Zavrsen",
                 "Analiza podataka", new DateTime(2023, 12, 1), 50),
        new Task("Čišćenje podataka", "Pripremiti podatke za analizu", "Zavrsen",
                 "Analiza podataka", new DateTime(2023, 12, 15), 70),
        new Task("Generiranje vizualnih izvještaja", "Kreirati vizualne prikaze podataka", "Aktivan",
                 "Analiza podataka", new DateTime(2024, 1, 20), 90)
                }
            );

            MainMenuOfTheApp(projectTasksMapping);

        }
        static void MainMenuOfTheApp(Dictionary<Project, List<Task>> projectTasksMapping)
        {
            var mainMenuRunning = true;
            while (mainMenuRunning)
            {
                Console.Clear();
                Console.WriteLine("1 - Ispis svih projekata s pripadajućim zadacima\n2 - Dodavanje novog projekta\n3 - Brisanje projekta" +
                    "\n4 - Prikaz svih zadataka s rokom u sljedećih 7 dana\n5 - Prikaz  projekata filtriranih po status\n6 - Upravljanje pojedinim projektom\n" +
                    "7 - Izlaz iz aplikacije");
                var inputedRightOption = int.TryParse(Console.ReadLine(), out var optionForMainMenu);
                switch (optionForMainMenu)
                {
                    case 1:
                        {
                            ProjectsFunctions.listAllProjects(projectTasksMapping);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            ProjectsFunctions.addNewProject(projectTasksMapping);
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            ProjectsFunctions.deleteProject(projectTasksMapping);
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            ProjectsFunctions.listAllTasksWithDeadlineInNextSevenDays(projectTasksMapping);
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            ProjectsFunctions.listAllProjectsFilteredByStatus(projectTasksMapping);
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            //daljnje granjanje u podmeni za taskove
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
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
    }
}
