using Ejercicionetcore.Models.Language;
using Ejercicionetcore.Models.Proyect;
using System;
using System.Collections.Generic;
using System.Linq;
using Ejercicionetcore.Repository;
using Ejercicionetcore.Models;
using System.Security.Cryptography.X509Certificates;


namespace Ejercicionetcore.Repository
{
    public class LanguageRepository
    {
        static List<LanguageModel> languages = new List<LanguageModel>();
        public List<LanguageModel> GetAllLanguages()
        {
            return languages;
        }

        public LanguageModel? GetLanguageById(int id)
        {
            return languages.FirstOrDefault(l => l.IdLanguage == id);
        }

        public LanguageModel AddLanguage(LanguageModel language)
        {
            int idLanguage = languages.Count > 0 ? languages.Max(l => l.IdLanguage) + 1 : 1;
            LanguageModel newLanguage = new LanguageModel(idLanguage, language.NameLanguage);
            languages.Add(newLanguage);
            return newLanguage;
        }

        public bool RemoveLanguage(int id)
        {
            var language = languages.FirstOrDefault(l => l.IdLanguage == id);
            if (language == null) return false;
            return languages.Remove(language);
        }

    }
}
