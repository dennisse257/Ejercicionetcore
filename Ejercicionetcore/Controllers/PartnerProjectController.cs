using Ejercicionetcore.Bll;
using Ejercicionetcore.Helpers;
using Microsoft.AspNetCore.Mvc;
using static Ejercicionetcore.Models.PartnerProject.PartnerProjectModel;
using Ejercicionetcore.Models.PartnerProject;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicionetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerProjectController : ControllerBase
    {
        private PartnerProjectBll bll = new PartnerProjectBll();
        // GET: api/<PartnerProjectController>
        [HttpGet]
        public ActionResult<ResponseGeneralModel<List<ProjectWithPartnersDto>>> GetProjectsWithPartners()
        {
            var response = bll.GetProjectsWithPartners();
            return StatusCode(response.Code, response);
        }

        // GET api/<PartnerProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartnerProjectController>
        [HttpPost]
        public  ActionResult<ResponseGeneralModel<string>> AddRelation([FromBody] PartnerProjectModel request)
        {
            var response = bll.AddRelation(request.IdProject, request.IdPartner);
            return StatusCode(response.Code, response);
        }

        // PUT api/<PartnerProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartnerProjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<ResponseGeneralModel<string>> DeleteRelation(int id)
        {
            var response = bll.DeleteRelation(id);
            return StatusCode(response.Code, response);
        }
    }
}
