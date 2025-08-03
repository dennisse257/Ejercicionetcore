using Ejercicionetcore.Helpers;
using Ejercicionetcore.Models.Language;
using Ejercicionetcore.Models.Partner;
using Ejercicionetcore.Repository;

namespace Ejercicionetcore.Bll
{
    public class LanguageBll
    {
        private LanguageRepository languagePart = new LanguageRepository();

        public List<LanguageModel> GetAllLanguage()
        {
            return languagePart.GetAllLanguages();

        }

        public LanguageModel? GetLanguageById(int id)
        {
            return languagePart.GetLanguageById(id);
        }

        public ResponseGeneralModel<LanguageModel> AddLanguage(LanguageAddRequest language)
        {
            if (string.IsNullOrWhiteSpace(language.NameLanguage))
            {
                return new ResponseGeneralModel<LanguageModel>(400, null, "El nombre del lenguaje es obligatorio.");
            }
            var test = languagePart.AddLanguage(new LanguageModel(0, language.NameLanguage));
            LanguageModel languageAdd = new LanguageModel(test.IdLanguage, test.NameLanguage);
            return new ResponseGeneralModel<LanguageModel>(200, languageAdd, "Lenguaje agregado correctamente.");
        }

        public ResponseGeneralModel<string> DeleteLanguage(int id)
        {
            bool removed = languagePart.RemoveLanguage(id);
            if (removed)
                return new ResponseGeneralModel<string>(200, null, "Lenguaje eliminado correctamente");
            else
                return new ResponseGeneralModel<string>(404, null, "Lenguaje no encontrado");



        }
    }
}
