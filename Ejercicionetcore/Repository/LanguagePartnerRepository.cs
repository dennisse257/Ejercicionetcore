using Ejercicionetcore.Models.LanguagePartner;
using Ejercicionetcore.Models.Partner;
using static Ejercicionetcore.Models.LanguagePartner.LanguagePartnerModelcs;

namespace Ejercicionetcore.Repository
{
    public class LanguagePartnerRepository
    {

        static List<LanguagePartnerModelcs> languagePartners = new List<LanguagePartnerModelcs>();
        public List<LanguagePartnerModelcs> GetAllLanguagePartners()
        {
            return languagePartners;
        }

        public void AddLanguagePartner(int idLanguage, int idPartner)
        {
            int newId = languagePartners.Count > 0 ? languagePartners.Max(lp => lp.IdLanguagePartner) + 1 : 1;
            languagePartners.Add(new LanguagePartnerModelcs(newId, idLanguage, idPartner));
        }

        public List<LanguagePartnerModelcs> GetLanguagePartnersByPartnerId(int idPartner)
        {
            return languagePartners.Where(lp => lp.IdPartner == idPartner).ToList();
        }

        public List<LanguagePartnerModelcs> GetLanguagePartnersByLanguageId(int idLanguage)
        {
            return languagePartners.Where(lp => lp.IdLanguage == idLanguage).ToList();
        }

        public bool RemoveLanguagePartner(int id)
        {
            var languagePartner = languagePartners.FirstOrDefault(lp => lp.IdLanguagePartner == id);
            if (languagePartner != null)
            {
                languagePartners.Remove(languagePartner);
                return true;
            }
            return false;
        }

        public List<LanguageWithPartnersDto> GetLanguagesWithPartners(PartnerRepository partnerRepo)
        {
            var result = new List<LanguageWithPartnersDto>();
            var languages = languagePartners.Select(lp => lp.IdLanguage).Distinct();
            foreach (var languageId in languages)
            {
                var dto = new LanguageWithPartnersDto
                {
                    IdLanguage = languageId,
                    Partners = new List<PartnerModel>(),
                };
                var partners = GetLanguagePartnersByLanguageId(languageId);
                foreach (var partner in partners)
                {
                    var partnerModel = partnerRepo.GetPartnerById(partner.IdPartner);
                    if (partnerModel != null)
                    {
                        dto.Partners.Add(partnerModel);
                    }
                }
                result.Add(dto);
            }
            return result;
        }

        public List<PartnerWithLanguagesDto> GetPartnersWithLanguages(PartnerRepository partnerRepo, LanguageRepository languageRepo)
        {
            var result = new List<PartnerWithLanguagesDto>();

            var partners = languagePartners.Select(lp => lp.IdPartner).Distinct();

            foreach (var partnerId in partners)
            {
                var partnerModel = partnerRepo.GetPartnerById(partnerId);
                if (partnerModel == null) continue;

                var dto = new PartnerWithLanguagesDto
                {
                    IdPartner = partnerId,
                    NamePartner = partnerModel.NamePartner
                };

                var relations = languagePartners.Where(lp => lp.IdPartner == partnerId);

                foreach (var rel in relations)
                {
                    var language = languageRepo.GetLanguageById(rel.IdLanguage);
                    if (language != null)
                    {
                        dto.Languages.Add(language);
                    }
                }

                result.Add(dto);
            }

            return result;
        }
    }
}
