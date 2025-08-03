using Ejercicionetcore.Models.Partner;

namespace Ejercicionetcore.Models.PartnerProject
{
    public class PartnerProjectModel
    {
        public int IdPartnerProject { get; set; }
        public int IdPartner { get; set; }
        public int IdProject { get; set; }

        public PartnerProjectModel ( int idPartnerProject, int idPartner, int idProject)
        {
            this.IdPartnerProject = idPartnerProject;
            this.IdPartner = idPartner;
            this.IdProject = idProject;
        }
        public class ProjectWithPartnersDto
        {
            public int IdProject { get; set; }
            public string NameProject { get; set; }
            public DateTime DateProject { get; set; }
            public List<PartnerModel> Partners { get; set; }

            public ProjectWithPartnersDto()
            {
                Partners = new List<PartnerModel>();
            }
        }
    }
}
