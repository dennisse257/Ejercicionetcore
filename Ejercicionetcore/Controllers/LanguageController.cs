using Ejercicionetcore.Bll;
using Ejercicionetcore.Helpers;
using Ejercicionetcore.Models.Language;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicionetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private LanguageBll bll = new LanguageBll();
        // GET: api/<LanguageController>
        [HttpGet]
        public ActionResult<ResponseGeneralModel<List<LanguageModel>>> GetAll()
        {
            var languages = bll.GetAllLanguage ();
            return new ResponseGeneralModel<List<LanguageModel>>(200, languages, "Idiomas listados correctamente");
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public ActionResult<ResponseGeneralModel<LanguageModel>> GetById(int id)
        {
            var language = bll.GetLanguageById(id);
            if (language == null)
                return new ResponseGeneralModel<LanguageModel>(404, null, "Idioma no encontrado");
            return new ResponseGeneralModel<LanguageModel>(200, language, "Idioma encontrado");
        }
       
        // POST api/<LanguageController>
        [HttpPost]
        public ActionResult<ResponseGeneralModel<LanguageModel>> Add([FromBody] LanguageAddRequest language)
        {
            var response = bll.AddLanguage(language);
            return StatusCode(response.Code, response);
        }
        

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public ActionResult<ResponseGeneralModel<string>> Delete(int id)
        {
            var response = bll.DeleteLanguage(id);
            return StatusCode(response.Code, response);
        }
    }
}
