using Ejercicionetcore.Models.Partner;
using Ejercicionetcore.Models.PartnerProject;
using static Ejercicionetcore.Models.PartnerProject.PartnerProjectModel;

namespace Ejercicionetcore.Repository
{
    public class PartnerProjectRepository
    {
        static List<PartnerProjectModel> partnerProjects = new List<PartnerProjectModel>();


        public List<PartnerProjectModel> GetAll()
        {
            return partnerProjects;
        }

        public void AddRelation(int idProject, int idPartner)
        {
            int newId = partnerProjects.Count > 0 ? partnerProjects.Max(pp => pp.IdPartnerProject) + 1 : 1;
            partnerProjects.Add(new PartnerProjectModel(newId, idPartner, idProject));

        }

        public List<PartnerProjectModel> GetRelationsByPartnerId(int idPartner)
        {
            return partnerProjects.Where(pp => pp.IdPartner == idPartner).ToList();
        }

        public List<PartnerProjectModel> GetRelationsByProjectId(int idProject)
        {
            return partnerProjects.Where(pp => pp.IdProject == idProject).ToList();

        }

        public bool RemoveRelation(int id)
        {
            var relation = partnerProjects.FirstOrDefault(pp => pp.IdPartnerProject == id);
            if (relation != null)
            {
                partnerProjects.Remove(relation);
                return true;
            }
            return false;
        }

        public List<ProjectWithPartnersDto> GetProjectsWithPartners(ProjectRepository projectRepo, PartnerRepository partnerRepo)
        {
            var result = new List<ProjectWithPartnersDto>();
            var projects = projectRepo.GetAllProjects();

            foreach (var project in projects)
            {
                var dto = new ProjectWithPartnersDto
                {
                    IdProject = project.IdProject,
                    NameProject = project.NameProject,
                    DateProject = project.DateProject,
                    Partners = new List<PartnerModel>()
                };

                var relations = GetRelationsByProjectId(project.IdProject);
                foreach (var relation in relations)
                {
                    var partner = partnerRepo.GetPartnerById(relation.IdPartner);
                    if (partner != null)
                    {
                        dto.Partners.Add(partner);
                    }
                }

                result.Add(dto);
            }

            return result;
        }



    }

}

