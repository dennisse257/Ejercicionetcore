using Ejercicionetcore.Models.Language;

namespace Ejercicionetcore.Models.Partner
{
    public class PartnerModel
    {
        public int IdPartner {get; set; }
        public string NamePartner {get; set; }
        public List<LanguageModel> Languages {get; set; }


        public PartnerModel(int idPartner, string namePartner)
        {
            this.IdPartner = idPartner;
            this.NamePartner = namePartner;
            this.Languages = new List<LanguageModel>();
        }


    }
}
