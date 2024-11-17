using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    public  class ProjectsFunctions
    {
        public static void listAllProjects(Dictionary<Project, List<Task>> projectsWithTasks)
        {
            Console.Clear();
            if (projectsWithTasks.Count == 0)
            {
                Console.WriteLine("Nema projekata.");
                return;
            }
            else
            {
                foreach (var project in projectsWithTasks)
                {
                    Console.WriteLine($"Ime projekta: {project.Key.NameOfProject}\nOpis projekta: {project.Key.DescriptionOfProject}\nStatus projekta: {project.Key.StatusOfProject}\nDatum početka projekta: {project.Key.StartDateOfProject}\nDatum završetka projekta: {project.Key.EndDateOfProject}");
                    foreach (var task in project.Value)
                    {
                        Console.WriteLine($"Ime zadatka: {task.NameOfTask}\nOpis zadatka: {task.DescriptionOfTask}\nStatus zadatka: {task.StatusOfTask}\nProjekt kojem pripada zadatak: {task.ProjectItBelongsTo}\nDatum završetka zadatka: {task.MandatoryEndDateOfTask}\nOčekivano trajanje zadatka u minutama: {task.ExcpetedMinutesToFinishTask}");
                    }
                }
            }
        }  
        
        public static void addNewProject(Dictionary<Project, List<Task>> projectsWithTasks)
        {
            Console.Clear();
            var newProject = new Project();
            projectsWithTasks.Add(newProject, new List<Task>());
        }
    }
}
