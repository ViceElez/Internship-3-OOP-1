﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    public class ProjectsFunctions
    {
        public static void listAllProjects(Dictionary<Project, List<Task>> projectTasksMapping)
        {
            Console.Clear();
            if (projectTasksMapping.Count == 0)
            {
                Console.WriteLine("Nema projekata.");
                return;
            }
            else
            {
                foreach (var project in projectTasksMapping)
                {
                    Console.WriteLine($"Ime projekta: {project.Key.NameOfProject}\nOpis projekta: {project.Key.DescriptionOfProject}\nStatus projekta: {project.Key.StatusOfProject}\nDatum početka projekta: {project.Key.StartDateOfProject}\nDatum završetka projekta: {project.Key.EndDateOfProject}");
                    Console.Write("\n");
                    foreach (var task in project.Value)
                    {
                        Console.WriteLine($"Ime zadatka: {task.NameOfTask}\nOpis zadatka: {task.DescriptionOfTask}\n" +
                            $"Status zadatka: {task.StatusOfTask}\nPrioritet zadatka: {task.PriorityOfTask}\n" +
                            $"Projekt kojem pripada zadatak: {task.ProjectItBelongsTo}\n" +
                            $"Datum završetka zadatka: {task.MandatoryEndDateOfTask}\n" +
                            $"Očekivano trajanje zadatka u minutama: {task.ExcpetedMinutesToFinishTask}");
                        Console.Write("\n");
                    }
                    Console.Write("\n");
                    Console.Write("\n");
                }
            }
        }

        public static void addNewProject(Dictionary<Project, List<Task>> projectTasksMapping)
        {
            Console.Clear();
            var projectOrder = new List<Project>();
            Console.Write("Upisite ime projekta:");
            var nameOfProject = Console.ReadLine();
            foreach (var project in projectTasksMapping)
            {
                if(nameOfProject.ToLower().Trim() == project.Key.NameOfProject.ToLower().Trim())
                {
                    Console.WriteLine("Projekt s tim imenom već postoji.");
                    return;
                }
            }
            var newProject=new Project(nameOfProject);

            projectTasksMapping.Add(newProject, new List<Task>());
            projectOrder.Add(newProject);
            var lastAddedProject = projectOrder[projectOrder.Count - 1];
            Console.Clear();
            Console.WriteLine($"Ime projekta: {lastAddedProject.NameOfProject}\nOpis projekta: {lastAddedProject.DescriptionOfProject}\nStatus projekta: {lastAddedProject.StatusOfProject}\nDatum početka projekta: {lastAddedProject.StartDateOfProject}\nDatum završetka projekta: {lastAddedProject.EndDateOfProject}");
            Console.WriteLine("Projekt uspjesno dodan.");
        }

        public static void deleteProject(Dictionary<Project, List<Task>> projectTasksMapping)
        {
            Console.Clear();
            Console.Write("Upisite ime projekta koji zelite ukloniti:");
            var projectNameToDelete = Console.ReadLine();
            bool foundProject = false;
            if (projectTasksMapping.Count == 0)
            {
                Console.WriteLine("Nema projekata.");
                return;
            }

            foreach (var project in projectTasksMapping)
            {
                if (project.Key.NameOfProject.ToLower().Trim() == projectNameToDelete.ToLower().Trim())
                {
                    foundProject = true;
                    Console.WriteLine("Dali stvarno zelite izbrisati projekt:");
                    Console.WriteLine($"{project.Key.NameOfProject}-{project.Key.DescriptionOfProject}-{project.Key.StatusOfProject}-{project.Key.StartDateOfProject}-{project.Key.EndDateOfProject}");
                    Console.WriteLine("Da/Ne");
                    var answer = string.Empty;
                    do
                    {
                        answer = Console.ReadLine().ToLower();
                        if (answer == "da")
                        {
                            projectTasksMapping.Remove(project.Key);
                            Console.WriteLine("Projekt uspješno izbrisana");
                        }
                        else if (answer == "ne")
                        {
                            Console.WriteLine("Projekt nije izbrisana");
                        }
                        else
                        {
                            Console.WriteLine("Morate upisati da ili ne");
                            continue;
                        }
                    } while (answer != "da" && answer != "ne");

                    return;
                }
            }
            if (!foundProject)
            {
                Console.WriteLine("Projekt nije pronaden.");
            }
        }

        public static void listAllTasksWithDeadlineInNextSevenDays(Dictionary<Project, List<Task>> projectTasksMapping)
        {
            Console.Clear();
            var today = DateTime.Now;
            var nextWeek = today.AddDays(7);
            bool foundTask = false;
            if (projectTasksMapping.Count == 0)
            {
                Console.WriteLine("Nema projekata.");
                return;
            }

            foreach (var project in projectTasksMapping)
            {
                foreach (var task in project.Value)
                {
                    if (task.MandatoryEndDateOfTask >= today && task.MandatoryEndDateOfTask <= nextWeek)
                    {
                        foundTask = true;
                        Console.WriteLine($"Ime zadatka: {task.NameOfTask}\nOpis zadatka: {task.DescriptionOfTask}\n" +
                           $"Status zadatka: {task.StatusOfTask}\nPrioritet zadatka: {task.PriorityOfTask}\n" +
                           $"Projekt kojem pripada zadatak: {task.ProjectItBelongsTo}\n" +
                           $"Datum završetka zadatka: {task.MandatoryEndDateOfTask}\n" +
                           $"Očekivano trajanje zadatka u minutama: {task.ExcpetedMinutesToFinishTask}");
                        Console.WriteLine();
                    }
                }
            }
            if (!foundTask)
            {
                Console.WriteLine("Nema zadataka sa rokom u sljedecih 7 dana.");
            }

        }

        public static void listAllProjectsFilteredByStatus(Dictionary<Project, List<Task>> projectTasksMapping)
        {
            Console.Clear();
            Console.Write("Upisite status projekta po kojem zelite filtrirati projekte:");
            var statusToFilterBy = Console.ReadLine();
            bool foundProject = false;
            if (projectTasksMapping.Count == 0)
            {
                Console.WriteLine("Nema projekata.");
                return;
            }

            while (true)
            {
                if (statusToFilterBy.ToLower().Trim() == "aktivan" || statusToFilterBy.ToLower().Trim() == "zavrsen" || statusToFilterBy.ToLower().Trim() == "na cekanju")
                    break;
                else
                {
                    Console.WriteLine("Status projekta može biti samo aktivan,zavrsen ili na cekanju.");
                    Console.Write("Upisite status projekta:");
                    statusToFilterBy = Console.ReadLine();
                    continue;
                }
            }

            foreach (var project in projectTasksMapping)
            {
                if (project.Key.StatusOfProject.ToLower().Trim() == statusToFilterBy.ToLower().Trim())
                {
                    foundProject = true;
                    Console.WriteLine($"Ime projekta: {project.Key.NameOfProject}\nOpis projekta: {project.Key.DescriptionOfProject}\nStatus projekta: {project.Key.StatusOfProject}\nDatum početka projekta: {project.Key.StartDateOfProject}\nDatum završetka projekta: {project.Key.EndDateOfProject}");
                    Console.WriteLine();
                }
            }
            if (!foundProject)
            {
                Console.WriteLine("Nema projekata sa tim statusom.");
            }
        }

        public static void handlingSpecifProject(Dictionary<Project, List<Task>> projectTasksMapping)
        {
            Console.Clear();
            if (projectTasksMapping.Count == 0)
            {
                Console.WriteLine("Nema projekata.");
                Console.ReadKey();
                return;
            }

            foreach (var project in projectTasksMapping.Keys)
            {
                Console.WriteLine($"Ime projekta: {project.NameOfProject}");
            }
            Console.WriteLine();

            Console.Write("Upisite ime projekta na kojem zelite raditi daljnje promjene: ");
            var projectNameToMakeChanges = Console.ReadLine();
            var foundProject = false;

            foreach (var project in projectTasksMapping)
            {
                if (project.Key.NameOfProject.ToLower().Trim() == projectNameToMakeChanges.ToLower().Trim())
                {
                    foundProject = true;
                    var taskMenuRunning = true;
                    while (taskMenuRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("1 - Ispis svih zadataka unutar odabranog projekta\n2 - Prikaz detalja odabranog projekta\n" +
                                          "3 - Uređivanje statusa projekta\n4 - Dodavanje zadatka unutar projekta\n5 - Brisanje zadatka iz projekta\n" +
                                          "6 - Prikaz ukupno očekivanog vremena potrebnog za sve aktivne zadatke u projektu\n7 - Sortirani zadaci po duljini" +
                                          "\n8 - Sortirani zadaci po prioritetu\n9 - Upravljanje pojedinim zadatkom\n" +
                                          "0 - Povratak");
                        Console.Write("Odaberite opciju: ");

                        var inputValid = int.TryParse(Console.ReadLine(), out var optionForTaskMenu);

                        if (!inputValid || optionForTaskMenu < 0 || optionForTaskMenu > 9)
                        {
                            Console.WriteLine("\nKrivi unos, molimo pokusajte ponovo.");
                            Console.ReadKey();
                            continue; 
                        }
                        switch (optionForTaskMenu)
                        {
                            case 1:
                                TaskFunctions.listAllTasksOfProject(project.Key, project.Value);
                                break;
                            case 2:
                                TaskFunctions.listOfDetailsForSelectedProject(project.Key, project.Value);
                                break;
                            case 3:
                                TaskFunctions.editingStatusOfProject(project.Key);
                                break;
                            case 4:
                                TaskFunctions.addingTaskToProject(project.Key, project.Value);
                                break;
                            case 5:
                                TaskFunctions.deletingTaskFromProject(project.Key, project.Value);
                                break;
                            case 6:
                                TaskFunctions.esitimatedTimeForAllActiveTasks(project.Key, project.Value);
                                break;
                            case 7:
                                TaskFunctions.sortingTaskByEstimatedTime(project.Value);
                                break;
                            case 8:
                                TaskFunctions.sortingTasksByPriority(project.Value);
                                break;
                            case 9:
                                TaskFunctions.handlingSpecificTasks(project.Key, project.Value);
                                break;
                            case 0:
                                taskMenuRunning = false; 
                                break;
                        }
                    }
                    break; 
                }
            }

            if (!foundProject)
            {
                Console.WriteLine("\nNepostoji projekt s takvim imenom, molimo pokusajte ponovo.");
                Console.ReadKey();
            }
        }

    }
}
