using CRUDREPOSITORY.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDREPOSITORY.Dto;

namespace CRUDREPOSITORY.controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Homecontroller : ControllerBase
    {
        private readonly IHomeinterface _homeinterface;
        public Homecontroller (IHomeinterface homeinterface)
        {
            _homeinterface = homeinterface;
        }

        [HttpGet]
        public ActionResult<string> retornoString()
        {
            var result = _homeinterface.AllPeople();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> CreatPeople(users user)
        {
            var result = _homeinterface.NewPeople(user);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<string> PutPeople(users user)
        {
            var result = _homeinterface.UpdatePeople(user);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<string> DeletePeople(int id)
        {
            var result = _homeinterface.DeletePeople(id);
            return Ok(result);
        }
    }
}