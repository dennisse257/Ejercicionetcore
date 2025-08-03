using Ejercicionetcore.Bll;
using Ejercicionetcore.Helpers;
using Ejercicionetcore.Models.Partner;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ejercicionetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private PartnerBll bll = new PartnerBll();

        // GET: api/partner
        [HttpGet]
        public ActionResult<ResponseGeneralModel<List<PartnerModel>>> GetAll()
        {
            var partners = bll.GetAllPartners();
            return new ResponseGeneralModel<List<PartnerModel>>(200, partners, "Colaboradores listados correctamente");
        }

        // GET: api/partner/5
        [HttpGet("{id}")]
        public ActionResult<ResponseGeneralModel<PartnerModel>> GetById(int id)
        {
            var partner = bll.GetPartnerById(id);
            if (partner == null)
                return new ResponseGeneralModel<PartnerModel>(404, null, "Colaborador no encontrado");
            return new ResponseGeneralModel<PartnerModel>(200, partner, "Colaborador encontrado");
        }

        // POST: api/partner
        [HttpPost]
        public ActionResult<ResponseGeneralModel<PartnerModel>> Add([FromBody] PartnerAddRequest partner)
        {
            var response = bll.AddPartner(partner);
            return StatusCode(response.Code, response);
        }

        // DELETE: api/partner/5
        [HttpDelete("{id}")]
        public ActionResult<ResponseGeneralModel<string>> Delete(int id)
        {
            var response = bll.DeletePartner(id);
            return StatusCode(response.Code, response);
        }
    }
}
