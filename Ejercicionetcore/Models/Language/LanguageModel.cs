namespace Ejercicionetcore.Models.Language
{
    public class LanguageModel
    {
        public int IdLanguage { get; set; }
        public string NameLanguage { get; set; }



        public LanguageModel(int idLanguage, string nameLanguage)
        {
            this.IdLanguage = idLanguage;
            this.NameLanguage = nameLanguage;
        }


    }
}
