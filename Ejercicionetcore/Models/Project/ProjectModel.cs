namespace Ejercicionetcore.Models.Proyect
{
    public class ProjectModel
    {
        public int IdProject { get; set; } 
        public string NameProject { get; set; }
        public DateTime DateProject {get; set; }


        public ProjectModel(int idProject, string nameProject, DateTime dateProject)
        {
            this.IdProject = idProject;
            this.NameProject = nameProject;
            this.DateProject = dateProject;
        }


    }
}
