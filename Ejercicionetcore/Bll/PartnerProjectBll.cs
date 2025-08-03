using Ejercicionetcore.Helpers;
using Ejercicionetcore.Models.Partner;
using Ejercicionetcore.Models.PartnerProject;
using Ejercicionetcore.Models.Proyect;
using Ejercicionetcore.Repository;
using System.Collections.Generic;
using static Ejercicionetcore.Models.PartnerProject.PartnerProjectModel;

namespace Ejercicionetcore.Bll
{
    public class PartnerProjectBll
    {
        private PartnerProjectRepository partnerProjectRepo = new PartnerProjectRepository();
        private ProjectRepository projectRepo = new ProjectRepository();
        private PartnerRepository partnerRepo = new PartnerRepository();

       
        public ResponseGeneralModel<string> AddRelation(int idProject, int idPartner)
        {
            var project = projectRepo.GetProjectById(idProject);
            var partner = partnerRepo.GetPartnerById(idPartner);

            if (project == null || partner == null)
            {
                return new ResponseGeneralModel<string>(400, null, "Proyecto o Colaborador no encontrado.");
            }

            partnerProjectRepo.AddRelation(idProject, idPartner);
            return new ResponseGeneralModel<string>(200, null, "Relación agregada correctamente.");
        }

       
        public ResponseGeneralModel<List<ProjectWithPartnersDto>> GetProjectsWithPartners()
        {
            var result = partnerProjectRepo.GetProjectsWithPartners(projectRepo, partnerRepo);
            return new ResponseGeneralModel<List<ProjectWithPartnersDto>>(200, result, "Listado obtenido correctamente.");
        }

       
        public ResponseGeneralModel<string> DeleteRelation(int idRelation)
        {
            bool isRemoved = partnerProjectRepo.RemoveRelation(idRelation);
            return new ResponseGeneralModel<string>(
                isRemoved ? 200 : 404,
                null,
                isRemoved ? "Relación eliminada correctamente." : "No se encontró la relación."
            );
        }
    }
}
