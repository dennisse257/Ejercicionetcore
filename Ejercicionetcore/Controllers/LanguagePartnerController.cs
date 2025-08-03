using Ejercicionetcore.Bll;
using Ejercicionetcore.Helpers;
using Ejercicionetcore.Models.LanguagePartner;
using Microsoft.AspNetCore.Mvc;
using static Ejercicionetcore.Models.LanguagePartner.LanguagePartnerModelcs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicionetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagePartnerController : ControllerBase
    {
        private LanguagePartnerBll bll = new LanguagePartnerBll();
        // GET: api/<LanguagePartnerController>
        [HttpGet]
        public ActionResult<List<LanguageWithPartnersDto >> GetLanguagesWithPartners()
        {
            var response = bll.GetLanguagesWithPartners();
            return Ok(response);
        }

        [HttpGet("partners-with-languages")]
        public ActionResult<ResponseGeneralModel<List<PartnerWithLanguagesDto>>> GetPartnersWithLanguages()
        {
            var response = bll.GetPartnersWithLanguages();
            return StatusCode(response.Code, response);
        }

        // GET api/<LanguagePartnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LanguagePartnerController>
        [HttpPost]
        public ActionResult<ResponseGeneralModel<string>> AddLanguagePartner([FromBody] LanguagePartnerModelcs request)
        {
            var response = bll.AddLanguagePartner(request.IdPartner, request.IdLanguage);
            return StatusCode(response.Code, response);
        }

        // PUT api/<LanguagePartnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguagePartnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<ResponseGeneralModel<string>> DeleteLanguagePartner(int id)
        {
            var response = bll.DeleteLanguagePartner(id);
            return StatusCode(response.Code, response);
        }
    }
}
