using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.EMS.BUSSINESS;
using NS.EMS.DATABASE.Entities;
using NS.EMS.MODEL;

namespace NS.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class InfoController : ControllerBase
    {
        private readonly IBussiness _Bussiness;
        public InfoController(IBussiness Bussiness)
        {
            _Bussiness = Bussiness;
        }


        [Route("[action]")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetInformation()
        {
            return Ok(_Bussiness.GetInformation());
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]

        public IActionResult GetInfoByID(int id)
        {
            return Ok(_Bussiness.DetailId(id));
        }


        [Route("[action]")]
        [HttpPost]
        [Authorize]

        public IActionResult AddInformation(Model model)
        {
            _Bussiness.AddInformation(model);
            return Ok("Success");
        }

        [Route("[action]")]
        [HttpPut]
        [Authorize(Roles ="Admin")]
        public IActionResult Update(Information info)
        {
            _Bussiness.Update(info);
            return Ok("Updated");
        }


        [Route("[action]")]
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            _Bussiness.Delete(id);
            return Ok("Deleted");
        }
    }
}
