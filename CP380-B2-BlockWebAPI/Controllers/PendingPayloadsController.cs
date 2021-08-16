
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private readonly PendingPayloads pending;
        
        
        public PendingPayloadsController(PendingPayloads pending)
        {
            this.pending = pending;
        }
        [HttpGet]
        public  ActionResult<List<Payload>> Get()
        {
           
            return Ok(pending.ListofPayload());
        }

            
        [HttpPost]
        public ActionResult Post(Payload payload)
        {
            try
            {
                if (payload == null) { return BadRequest(); }
                    

                pending.AddPayload(payload);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Adding");
            }

        }
    }
}
