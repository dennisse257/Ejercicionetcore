using Ejercicionetcore.Models.Language;
using Ejercicionetcore.Models.Partner;

namespace Ejercicionetcore.Models.LanguagePartner
{
    public class LanguagePartnerModelcs
    {
        public int IdLanguagePartner { get; set; }
        public int IdLanguage { get; set; }
        public int IdPartner { get; set; }

        public LanguagePartnerModelcs(int idLanguagePartner, int idLanguage, int idPartner)
        {
            IdLanguagePartner = idLanguagePartner;
            IdLanguage = idLanguage;
            IdPartner = idPartner;
        }
    }

    // 🔽 DTOs deben ir fuera de la clase LanguagePartnerModelcs

    public class LanguageWithPartnersDto
    {
        public int IdLanguage { get; set; }
        public string NameLanguage { get; set; }
        public List<PartnerModel> Partners { get; set; }

        public LanguageWithPartnersDto()
        {
            Partners = new List<PartnerModel>();
        }
    }

    public class PartnerWithLanguagesDto
    {
        public int IdPartner { get; set; }
        public string NamePartner { get; set; }
        public List<LanguageModel> Languages { get; set; }

        public PartnerWithLanguagesDto()
        {
            Languages = new List<LanguageModel>();
        }
    }
}
