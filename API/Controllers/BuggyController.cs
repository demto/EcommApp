using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class BuggyController : BaseAPIController {
        
        private StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;    
        }

        [HttpGet("Notfound")]
        public ActionResult CannotFind() {
            var stuff = _context.Products.Find(42);

            if (stuff == null) {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("ServerError")]
        public ActionResult ServerError() {
            var stuff = _context.Products.Find(42);

            var stuffToReturn = stuff.ToString();

            return Ok(stuffToReturn);
        }
        
        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest() {
            return BadRequest(new ApiResponse(400, "You have made a really bad request"));
        }
        
        [HttpGet("Notfound/{id}")]
        public ActionResult GetNotFoundRequest(int id) {
            return Ok();
        }
    }
}