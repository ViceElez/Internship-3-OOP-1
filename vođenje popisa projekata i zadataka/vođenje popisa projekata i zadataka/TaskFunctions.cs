using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    public class TaskFunctions
    {
        public static void listAllTasksOfProject(Project selectedProject, List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            if (tasksOfASelectedProject.Count == 0)
            {
                Console.WriteLine("Nema zadataka za ovaj projekt.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine($"Zadaci za projekt {selectedProject.NameOfProject} su:");
                Console.WriteLine();
                foreach (var task in tasksOfASelectedProject)
                {
                    Console.WriteLine($"Ime zadatka:{task.NameOfTask}");
                    Console.WriteLine($"Opis zadatka:{task.DescriptionOfTask}");
                    Console.WriteLine($"Status zadatka:{task.StatusOfTask}");
                    Console.WriteLine($"Projekt kojem pripada zadatka:{task.ProjectItBelongsTo}");
                    Console.WriteLine($"Očekivano trajanje zadatka u minutama:{task.ExcpetedMinutesToFinishTask}");
                    Console.WriteLine($"Datum završetka zadatka:{task.MandatoryEndDateOfTask}");
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }

        public static void listOfDetailsForSelectedProject(Project selectedProject, List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            Console.WriteLine($"Ime projekta: {selectedProject.NameOfProject}\nOpis projekta: {selectedProject.DescriptionOfProject}\n" +
                $"Status projekta: {selectedProject.StatusOfProject}\nDatum početka projekta: " +
                $"{selectedProject.StartDateOfProject}\nDatum završetka projekta: {selectedProject.EndDateOfProject}");
            Console.Write("Dali zelite vidjeti sve zadatke za ovaj projekt(da/ne):");
            var answer = String.Empty;
            do
            {
                answer = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (answer == "da")
                {
                    foreach(var task in tasksOfASelectedProject)
                    {
                        Console.WriteLine($"Ime zadatka:{task.NameOfTask}");
                        Console.WriteLine($"Opis zadatka:{task.DescriptionOfTask}");
                        Console.WriteLine($"Status zadatka:{task.StatusOfTask}");
                        Console.WriteLine($"Projekt kojem pripada zadatka:{task.ProjectItBelongsTo}");
                        Console.WriteLine($"Očekivano trajanje zadatka u minutama:{task.ExcpetedMinutesToFinishTask}");
                        Console.WriteLine($"Datum završetka zadatka:{task.MandatoryEndDateOfTask}");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                }
                else if (answer == "ne")
                {
                   continue;
                }
                else
                {
                    Console.WriteLine("Morate upisati da ili ne");
                    continue;
                }
            } while (answer != "da" && answer != "ne");
        }

        public static void editingStatusOfProject(Project selectedProject)
        {
            Console.Clear();
            if (selectedProject.StatusOfProject.ToLower() == "zavrsen")
            {
                Console.WriteLine("Ne možete izmjenitit status jer je projekt završen.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine($"Status trenutnog projekta je:{selectedProject.StatusOfProject}");
                Console.WriteLine("Upisite novi status za projekt:");
                var newStatus = Console.ReadLine();
                if (newStatus.ToLower() == "aktivan" || newStatus.ToLower() == "zavrsen" || newStatus.ToLower() == "na cekanju")
                {
                    if (newStatus.ToLower() == selectedProject.StatusOfProject.ToLower())
                    {
                        Console.WriteLine("Novi status je isti kao i trenutni status.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        selectedProject.StatusOfProject = newStatus;
                        Console.WriteLine("Status projekta je promjenjen.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Krivo upisan status.");
                    Console.ReadKey();
                    return;
                }
            }
            
        }

        public static void addingTaskToProject(Project selectedProject, List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            if (tasksOfASelectedProject.Count == 0)
            {
                Console.WriteLine("Nema zadataka za ovaj projekt.");
                Console.ReadKey();
                return;
            }
            else
            {
                if (selectedProject.StatusOfProject.ToLower() == "zavrsen")
                {
                    Console.WriteLine("Ne možete dodati zadatak jer je projekt završen.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Task newTask = new Task();
                    tasksOfASelectedProject.Add(newTask);
                    Console.WriteLine("Zadatak je dodan.");
                    Console.ReadKey();
                    return;

                }
            }
        }

        public static void deletingTaskFromProject(Project selectedProject, List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            if (tasksOfASelectedProject.Count == 0)
            {
                Console.WriteLine("Nema zadataka za ovaj projekt.");
                return;
            }
            else
            {
                Console.WriteLine("Upisite ime zadatka koji želite obrisati:");
                var taskToDelete = Console.ReadLine();
                var foundTask=false;
                foreach (var task in tasksOfASelectedProject)
                {
                    if (task.NameOfTask.ToLower() == taskToDelete.ToLower())
                    {
                        foundTask = true;
                        Console.WriteLine("Da li stvarno želite izbrisati ovu transakciju (da/ne)?");
                        var answer = string.Empty;
                        do
                        {
                            answer = Console.ReadLine().ToLower();
                            if (answer == "da")
                            {
                                tasksOfASelectedProject.Remove(task);
                                Console.WriteLine("Zadatak je obrisan.");
                                Console.ReadKey();
                                return;
                            }
                            else if (answer == "ne")
                            {
                                Console.WriteLine("Zadatak nije izbrisana");
                                Console.ReadKey();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Morate upisati da ili ne");
                                continue;
                            }
                        } while (answer != "da" && answer != "ne");
                    }
                }
                if(!foundTask)
                {
                    Console.WriteLine("Zadatak nije pronađen.");
                    Console.ReadKey();
                    return;
                }
            }
        }

        public static void esitimatedTimeForAllActiveTasks(Project selectedProject, List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            var sumOfMinutes = 0;
            foreach (var task in tasksOfASelectedProject)
            {
                if (task.StatusOfTask.ToLower() == "aktivan")
                {
                    sumOfMinutes += task.ExcpetedMinutesToFinishTask;
                }
            }
            Console.WriteLine($"Ukupno ocekivano vrijeme za sve aktivne zadatke u projektu {selectedProject.NameOfProject} je : {sumOfMinutes}");
            Console.ReadKey();
        }

        public static void handlingSpecificTasks(Project selectedProject, List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            if (tasksOfASelectedProject.Count == 0)
            {
                Console.WriteLine("Nema zadataka za ovaj projekt.");
                Console.ReadKey();
                return;
            }
            foreach (var task in tasksOfASelectedProject)
            {
                Console.WriteLine($"Ime zadatka:{task.NameOfTask}");
            }
            Console.Write("Upisite ime zadatka na kojem zelite raditi daljnje promjene:");
            var taskToHandle = Console.ReadLine();
            var foundTask = false;
            foreach (var task in tasksOfASelectedProject)
            {
                if (task.NameOfTask == taskToHandle)  //pitaj nekog za savjet dali triba bit tolower ili ne 
                {
                    var taskSubMenuRunning = true;
                    while (taskSubMenuRunning)
                    {
                        Console.Clear();    
                        foundTask = true;
                        Console.WriteLine("1 - Prikaz detalja odabranog zadatka\n2 - Uređivanje statusa zadatka\n3 - Povratak");
                        var inputedRightOption = int.TryParse(Console.ReadLine(), out var optionForSubTaskMenu);
                        switch (optionForSubTaskMenu)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Ime zadatka:{task.NameOfTask}");
                                    Console.WriteLine($"Opis zadatka:{task.DescriptionOfTask}");
                                    Console.WriteLine($"Status zadatka:{task.StatusOfTask}");
                                    Console.WriteLine($"Projekt kojem pripada zadatka:{task.ProjectItBelongsTo}");
                                    Console.WriteLine($"Očekivano trajanje zadatka u minutama:{task.ExcpetedMinutesToFinishTask}");
                                    Console.WriteLine($"Datum završetka zadatka:{task.MandatoryEndDateOfTask}");
                                    Console.ReadKey();
                                    break;
                                }
                            case 2:
                                {
                                    Console.Clear();
                                    if (task.StatusOfTask.ToLower() == "zavrsen")
                                    {
                                        Console.WriteLine("Ne možete izmjenitit status jer je zadatak završen.");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Status trenutnog zadatka je:{task.StatusOfTask}");
                                        Console.WriteLine("Upisite novi status za zadatak:");
                                        var newStatus = Console.ReadLine();
                                        if (newStatus.ToLower() == "aktivan" || newStatus.ToLower() == "zavrsen" || newStatus.ToLower() == "na cekanju")
                                        {
                                            if (newStatus.ToLower() == task.StatusOfTask.ToLower())
                                            {
                                                Console.WriteLine("Novi status je isti kao i trenutni status.");
                                                Console.ReadKey();
                                                break;
                                            }
                                            else
                                            {
                                                task.StatusOfTask = newStatus;
                                                Console.WriteLine("Status zadatka je promjenjen.");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Krivo upisan status.");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                }
                            case 3:
                                {
                                    taskSubMenuRunning = false;
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
            if (!foundTask)
            {
                Console.WriteLine("Nepostoji zadatak s takvim imenom, molimo pokusajte ponovo.");
                Console.ReadKey();
            }
        }
    }
}
