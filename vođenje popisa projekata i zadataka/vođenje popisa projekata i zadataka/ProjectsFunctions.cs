using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    public  class ProjectsFunctions
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
                        Console.WriteLine($"Ime zadatka: {task.NameOfTask}\nOpis zadatka: {task.DescriptionOfTask}\nStatus zadatka: {task.StatusOfTask}\nProjekt kojem pripada zadatak: {task.ProjectItBelongsTo}\nDatum završetka zadatka: {task.MandatoryEndDateOfTask}\nOčekivano trajanje zadatka u minutama: {task.ExcpetedMinutesToFinishTask}");
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
            var newProject = new Project();

            projectTasksMapping.Add(newProject, new List<Task>());
            projectOrder.Add(newProject);
            var lastAddedProject = projectOrder[projectOrder.Count - 1];
            Console.Clear();
            Console.WriteLine($"Ime projekta: {lastAddedProject.NameOfProject}\nOpis projekta: {lastAddedProject.DescriptionOfProject}\nStatus projekta: {lastAddedProject.StatusOfProject}\nDatum početka projekta: {lastAddedProject.StartDateOfProject}\nDatum završetka projekta: {lastAddedProject.EndDateOfProject}");
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
                    if (project.Key.NameOfProject == projectNameToDelete)
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
                                Console.WriteLine("Transakcija uspješno izbrisana");
                            }
                            else if (answer == "ne")
                            {
                                Console.WriteLine("Transakcija nije izbrisana");
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
            if(!foundProject)
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
                        Console.WriteLine($"Ime zadatka: {task.NameOfTask}\nOpis zadatka: {task.DescriptionOfTask}\nStatus zadatka: {task.StatusOfTask}\nProjekt kojem pripada zadatak: {task.ProjectItBelongsTo}\nDatum završetka zadatka: {task.MandatoryEndDateOfTask}\nOčekivano trajanje zadatka u minutama: {task.ExcpetedMinutesToFinishTask}");
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
                if (statusToFilterBy.ToLower() == "aktivan" || statusToFilterBy.ToLower() == "zavrsen" || statusToFilterBy.ToLower() == "na cekanju")
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
                if(project.Key.StatusOfProject.ToLower() == statusToFilterBy.ToLower())
                {
                    foundProject = true;
                    Console.WriteLine($"Ime projekta: {project.Key.NameOfProject}\nOpis projekta: {project.Key.DescriptionOfProject}\nStatus projekta: {project.Key.StatusOfProject}\nDatum početka projekta: {project.Key.StartDateOfProject}\nDatum završetka projekta: {project.Key.EndDateOfProject}");
                }
            }
            if (!foundProject)
            {
                Console.WriteLine("Nema projekata sa tim statusom.");
            }
        }
    }
}
