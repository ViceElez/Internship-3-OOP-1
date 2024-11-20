using System;
using System.Collections;
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
                    Console.WriteLine($"Prioritet zadatka:{task.PriorityOfTask}");
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
                        Console.WriteLine($"Prioritet zadatka:{task.PriorityOfTask}");
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
            if (selectedProject.StatusOfProject.ToLower().Trim() == "zavrsen")
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
                if (newStatus.ToLower().Trim() == "aktivan" || newStatus.ToLower().Trim() == "zavrsen" || newStatus.ToLower().Trim() == "na cekanju")
                {
                    if (newStatus.ToLower().Trim() == selectedProject.StatusOfProject.ToLower().Trim())
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
                if (selectedProject.StatusOfProject.ToLower().Trim() == "zavrsen")
                {
                    Console.WriteLine("Ne možete dodati zadatak jer je projekt završen.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    var taskOrder=new List<Task>();
                    Console.Write("Upisite ime zadatka:");
                    var nameOfTask = Console.ReadLine();
                    foreach (var task in tasksOfASelectedProject)
                    {
                        if(task.NameOfTask.ToLower().Trim()== nameOfTask.ToLower().Trim())
                        {
                            Console.WriteLine("Zadatak s tim imenom već postoji.");
                            Console.ReadKey();
                            return;
                        }
                    }
                    var projectTaskBelongsTo = selectedProject.NameOfProject;
                    var newTask = new Task(nameOfTask,projectTaskBelongsTo);
                    tasksOfASelectedProject.Add(newTask);
                    taskOrder.Add(newTask);
                    var lastAddedTask = taskOrder[taskOrder.Count-1];
                    Console.Clear();
                    Console.WriteLine($"Ime zadatka:{lastAddedTask.NameOfTask}");
                    Console.WriteLine($"Opis zadatka:{lastAddedTask.DescriptionOfTask}");
                    Console.WriteLine($"Status zadatka:{lastAddedTask.StatusOfTask}");
                    Console.WriteLine($"Projekt kojem pripada zadatka:{lastAddedTask.ProjectItBelongsTo}");
                    Console.WriteLine($"Očekivano trajanje zadatka u minutama:{lastAddedTask.ExcpetedMinutesToFinishTask}");
                    Console.WriteLine($"Datum završetka zadatka:{lastAddedTask.MandatoryEndDateOfTask}");
                    Console.WriteLine("Zadatak je dodan.");
                    Console.ReadKey();
                    return;

                }
        }

        public static void deletingTaskFromProject(Project selectedProject, List<Task> tasksOfASelectedProject)
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
                Console.WriteLine("Upisite ime zadatka koji želite obrisati:");
                var taskToDelete = Console.ReadLine();
                var foundTask=false;
                foreach (var task in tasksOfASelectedProject)
                {
                    if (task.NameOfTask.ToLower().Trim() == taskToDelete.ToLower().Trim())
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
            var sumOfMinutes = 0.00f;
            var countOfActiveTasks = 0;
            foreach (var task in tasksOfASelectedProject)
            {
                if (task.StatusOfTask.ToLower() == "aktivan")
                {
                    sumOfMinutes += task.ExcpetedMinutesToFinishTask;
                    countOfActiveTasks++;
                }
            }
            var estimatedTime = sumOfMinutes / (float)countOfActiveTasks;
            Console.WriteLine($"Ukupno ocekivano vrijeme za sve aktivne zadatke u projektu {selectedProject.NameOfProject} je : {estimatedTime:F2}");
            Console.ReadKey();
        }

        public static void sortingTaskByEstimatedTime( List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            if (tasksOfASelectedProject.Count == 0)
            {
                Console.WriteLine("Nema zadataka za ovaj projekt.");
                Console.ReadKey();
                return;
            }
            foreach (var task in tasksOfASelectedProject.OrderBy(x => x.ExcpetedMinutesToFinishTask))
            {
                Console.WriteLine($"Ime zadatka:{task.NameOfTask}");
                Console.WriteLine($"Opis zadatka:{task.DescriptionOfTask}");
                Console.WriteLine($"Status zadatka:{task.StatusOfTask}");
                Console.WriteLine($"Prioritet zadatka:{task.PriorityOfTask}");
                Console.WriteLine($"Projekt kojem pripada zadatka:{task.ProjectItBelongsTo}");
                Console.WriteLine($"Očekivano trajanje zadatka u minutama:{task.ExcpetedMinutesToFinishTask}");
                Console.WriteLine($"Datum završetka zadatka:{task.MandatoryEndDateOfTask}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static void sortingTasksByPriority(List<Task> tasksOfASelectedProject)
        {
            Console.Clear();
            if (tasksOfASelectedProject.Count == 0)
            {
                Console.WriteLine("Nema zadataka za ovaj projekt.");
                Console.ReadKey();
                return;
            }
            foreach (var task in tasksOfASelectedProject.OrderBy(x => x.PriorityOfTask))
            {
                Console.WriteLine($"Ime zadatka:{task.NameOfTask}");
                Console.WriteLine($"Opis zadatka:{task.DescriptionOfTask}");
                Console.WriteLine($"Status zadatka:{task.StatusOfTask}");
                Console.WriteLine($"Prioritet zadatka:{task.PriorityOfTask}");
                Console.WriteLine($"Projekt kojem pripada zadatka:{task.ProjectItBelongsTo}");
                Console.WriteLine($"Očekivano trajanje zadatka u minutama:{task.ExcpetedMinutesToFinishTask}");
                Console.WriteLine($"Datum završetka zadatka:{task.MandatoryEndDateOfTask}");
                Console.WriteLine();
            }
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
                Console.WriteLine($"Ime zadatka: {task.NameOfTask}");
            }

            Console.Write("Upisite ime zadatka na kojem zelite raditi daljnje promjene: ");
            var taskToHandle = Console.ReadLine();
            var foundTask = false;

            foreach (var task in tasksOfASelectedProject)
            {
                if (task.NameOfTask.ToLower().Trim() == taskToHandle.ToLower().Trim())
                {
                    foundTask = true;
                    var taskSubMenuRunning = true;

                    while (taskSubMenuRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("1 - Prikaz detalja odabranog zadatka\n2 - Uređivanje statusa zadatka\n3 - Povratak");
                        Console.Write("Odaberite opciju: ");

                        var inputValid = int.TryParse(Console.ReadLine(), out var optionForSubTaskMenu);

                        if (!inputValid || optionForSubTaskMenu < 1 || optionForSubTaskMenu > 3)
                        {
                            Console.WriteLine("\nKrivi unos, molimo pokusajte ponovo.");
                            Console.ReadKey();
                            continue; 
                        }

                        switch (optionForSubTaskMenu)
                        {
                            case 1: 
                                Console.Clear();
                                Console.WriteLine($"Ime zadatka: {task.NameOfTask}");
                                Console.WriteLine($"Opis zadatka: {task.DescriptionOfTask}");
                                Console.WriteLine($"Status zadatka: {task.StatusOfTask}");
                                Console.WriteLine($"Prioritet zadatka: {task.PriorityOfTask}");
                                Console.WriteLine($"Projekt kojem pripada zadatak: {task.ProjectItBelongsTo}");
                                Console.WriteLine($"Očekivano trajanje zadatka u minutama: {task.ExcpetedMinutesToFinishTask}");
                                Console.WriteLine($"Datum završetka zadatka: {task.MandatoryEndDateOfTask}");
                                Console.ReadKey();
                                break;

                            case 2: 
                                Console.Clear();
                                if (task.StatusOfTask.ToLower().Trim() == "zavrsen")
                                {
                                    Console.WriteLine("Ne možete izmjeniti status jer je zadatak zavrsen.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"Status trenutnog zadatka je: {task.StatusOfTask}");
                                    Console.WriteLine("Upisite novi status za zadatak (aktivan, zavrsen, na cekanju):");
                                    var newStatus = Console.ReadLine();

                                    if (newStatus.ToLower().Trim() == "aktivan" || newStatus.ToLower().Trim() == "zavrsen" || newStatus.ToLower().Trim() == "na cekanju")
                                    {
                                        while (newStatus.ToLower().Trim()==task.StatusOfTask.ToLower().Trim())
                                        {
                                            Console.WriteLine("Novi status je isti kao i trenutni status.");
                                            Console.WriteLine("Upisite novi status za zadatak:");
                                            newStatus = Console.ReadLine();
                                        }
                                        task.StatusOfTask = newStatus;
                                        Console.WriteLine("Status zadatka je promjenjen.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Krivo upisan status. Dozvoljeni statusi su: aktivan, zavrsen, na cekanju.");
                                        Console.ReadKey();
                                    }
                                }
                                var countOfFinishedTasks = 0;
                                foreach (var task1 in tasksOfASelectedProject)
                                {
                                    if (task1.StatusOfTask.ToLower().Trim() == "zavrsen")
                                        countOfFinishedTasks++;  
                                    else 
                                        break;
                                }
                                if(countOfFinishedTasks == tasksOfASelectedProject.Count)
                                {
                                    selectedProject.StatusOfProject = "zavrsen";
                                }
                                break;

                            case 3:
                                taskSubMenuRunning = false;
                                break;
                        }
                    }
                    break;
                }
            }

            if (!foundTask)
            {
                Console.WriteLine("\nNepostoji zadatak s takvim imenom, molimo pokusajte ponovo.");
                Console.ReadKey();
            }
        }

    }
}
