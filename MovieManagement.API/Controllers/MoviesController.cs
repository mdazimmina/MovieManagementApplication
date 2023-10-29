using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Repository.Configuration;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = _unitOfWork.Actor.GetAll();
            return new JsonResult(data);
        }
    }
}
