using System;
using System.Collections.Generic;
using Ejercicionetcore.Models.Proyect;
using Ejercicionetcore.Repository;
using Ejercicionetcore.Helpers;

namespace Ejercicionetcore.Bll
{
    public class ProjectBll
    {
        private ProjectRepository projectRepo = new ProjectRepository();

        public List<ProjectModel> GetAllProjects()
        {
            return projectRepo.GetAllProjects();
        }

        public ProjectModel? GetProjectById(int id)
        {
            return projectRepo.GetProjectById(id);
        }

        public ResponseGeneralModel<ProjectModel> AddProject(ProjectModel project)
        {
            if (string.IsNullOrWhiteSpace(project.NameProject))
            {
                return new ResponseGeneralModel<ProjectModel>(400, null, "El nombre del proyecto es obligatorio.");
            }
            if (project.DateProject == default)
            {
                return new ResponseGeneralModel<ProjectModel>(400, null, "La fecha del proyecto es obligatoria.");
            }

            projectRepo.AddProject(project);
            return new ResponseGeneralModel<ProjectModel>(200, project, "Proyecto agregado correctamente.");
        }

        public ResponseGeneralModel<ProjectModel> UpdateProject(int id, ProjectModel updatedProject)
        {
            var existingProject = projectRepo.GetProjectById(id);
            if (existingProject == null)
            {
                return new ResponseGeneralModel<ProjectModel>(404, null, "Proyecto no encontrado.");
            }

            if (string.IsNullOrWhiteSpace(updatedProject.NameProject))
            {
                return new ResponseGeneralModel<ProjectModel>(400, null, "El nombre del proyecto es obligatorio.");
            }
            if (updatedProject.DateProject == default)
            {
                return new ResponseGeneralModel<ProjectModel>(400, null, "La fecha del proyecto es obligatoria.");
            }

            existingProject.NameProject = updatedProject.NameProject;
            existingProject.DateProject = updatedProject.DateProject;

            return new ResponseGeneralModel<ProjectModel>(200, existingProject, "Proyecto actualizado correctamente.");
        }

        public ResponseGeneralModel<string> DeleteProject(int id)
        {
            var project = projectRepo.GetProjectById(id);
            if (project == null)
            {
                return new ResponseGeneralModel<string>(404, null, "Proyecto no encontrado.");
            }

            bool removed = projectRepo.RemoveProject(id);
            if (!removed)
            {
                return new ResponseGeneralModel<string>(500, null, "Error al eliminar el proyecto.");
            }

            return new ResponseGeneralModel<string>(200, null, "Proyecto eliminado correctamente.");
        }
    }
}

