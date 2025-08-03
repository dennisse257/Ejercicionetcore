using Ejercicionetcore.Models.Proyect;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicionetcore.Repository
{
    public class ProjectRepository
    {
        static List<ProjectModel> projects = new List<ProjectModel>();


        public List<ProjectModel> GetAllProjects()
        {
            return projects;
        }

        public ProjectModel?GetProjectById(int id)
        {
            return projects.FirstOrDefault(p => p.IdProject == id);
        }

        public void AddProject(ProjectModel project)
        {
            project.IdProject = projects.Count > 0 ? projects.Max(p => p.IdProject) + 1 : 1;
      
            projects.Add(project);
        }

        public bool RemoveProject(int id)
        {
            var project = projects.FirstOrDefault(p => p.IdProject == id);
            if (project == null)
                return false;

            return projects.Remove(project);
        }

    }
}
