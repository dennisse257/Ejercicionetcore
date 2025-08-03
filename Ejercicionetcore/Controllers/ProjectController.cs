using Ejercicionetcore.Bll;
using Ejercicionetcore.Helpers;
using Ejercicionetcore.Models.Proyect;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ejercicionetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ProjectBll bll = new ProjectBll();

        // GET api/project
        [HttpGet]
        public ActionResult<ResponseGeneralModel<List<ProjectModel>>> GetAll()
        {
            var projects = bll.GetAllProjects();
            return new ResponseGeneralModel<List<ProjectModel>>(200, projects, "Proyectos listados correctamente");
        }

        // GET api/project/5
        [HttpGet("{id}")]
        public ActionResult<ResponseGeneralModel<ProjectModel>> GetById(int id)
        {
            var project = bll.GetProjectById(id);
            if (project == null)
                return NotFound(new ResponseGeneralModel<ProjectModel>(404, null, "Proyecto no encontrado"));

            return new ResponseGeneralModel<ProjectModel>(200, project, "Proyecto encontrado");
        }

        // POST api/project
        [HttpPost]
        public ActionResult<ResponseGeneralModel<ProjectModel>> Add([FromBody] ProjectModel project)
        {
            var response = bll.AddProject(project);
            return StatusCode(response.Code, response);
        }

        // PUT api/project/5
        [HttpPut("{id}")]
        public ActionResult<ResponseGeneralModel<ProjectModel>> Update(int id, [FromBody] ProjectModel project)
        {
            var response = bll.UpdateProject(id, project);
            return StatusCode(response.Code, response);
        }

        // DELETE api/project/5
        [HttpDelete("{id}")]
        public ActionResult<ResponseGeneralModel<string>> Delete(int id)
        {
            var response = bll.DeleteProject(id);
            return StatusCode(response.Code, response);
        }
    }
}
