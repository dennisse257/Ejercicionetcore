using Ejercicionetcore.Helpers;
using Ejercicionetcore.Models.LanguagePartner;
using Ejercicionetcore.Repository;

namespace Ejercicionetcore.Bll
{
    public class LanguagePartnerBll
    {
        private LanguagePartnerRepository languagePartnerRepo = new LanguagePartnerRepository();
        private PartnerRepository partnerRepo = new PartnerRepository();
        private LanguageRepository languageRepo = new LanguageRepository();

        public ResponseGeneralModel<string> AddLanguagePartner(int idPartner, int idLanguage)
        { 
        var partner = partnerRepo.GetPartnerById(idPartner);
        var language= languageRepo.GetLanguageById(idLanguage);

            if (partner == null || language == null)
            {
                return new ResponseGeneralModel<string> (400, null, "Colaborador o Lenguaje no encontrado.");
            }
            languagePartnerRepo.AddLanguagePartner(idPartner, idLanguage);
            return new ResponseGeneralModel<string>(200, null, "Relación agregada correctamente.");

        }


        public ResponseGeneralModel<List<LanguageWithPartnersDto >> GetLanguagesWithPartners()
        {
            var result = languagePartnerRepo.GetLanguagesWithPartners(partnerRepo);
            return new ResponseGeneralModel<List<LanguageWithPartnersDto>>(200, result, "Listado obtenido correctamente.");
        }
        public ResponseGeneralModel<List<PartnerWithLanguagesDto>> GetPartnersWithLanguages()
        {
            var result = languagePartnerRepo.GetPartnersWithLanguages(partnerRepo, languageRepo);
            return new ResponseGeneralModel<List<PartnerWithLanguagesDto>>(200, result, "Listado obtenido correctamente.");
        }

        public ResponseGeneralModel<string> DeleteLanguagePartner(int idLanguagePartner)
        {
            bool isRemoved = languagePartnerRepo.RemoveLanguagePartner(idLanguagePartner);
            return new ResponseGeneralModel<string>(
                isRemoved ? 200 : 404,
                null,
                isRemoved ? "Relación eliminada correctamente." : "No se encontró la relación."
            );
        }



    }
}
