using CP380_B1_BlockList;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using CP380_B2_BlockWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly BlockList blockList;
        private readonly BlockListService service;

        // TODO

        public BlocksController(BlockList blockList,BlockListService service)
        {
            this.blockList = blockList;
            this.service = service;
        }


        [HttpGet]
        public ActionResult<List<BlockSummary>>  GetAllBlock()
         {

            List<BlockSummary> blockSummaries = new List<BlockSummary>();

            foreach (var item in blockList.Chain)
            {
                BlockSummary blockSummary = new BlockSummary
                {
                    Index=item.Index,
                    Hash = item.Hash,
                    Stamp = item.TimeStamp,
                    PreviousBlock = item.PreviousHash,
                    Nounce=item.Nonce
                   
                };
                blockSummaries.Add(blockSummary);
            }
        

           
           return blockSummaries;
        }
        [HttpGet("{hash}")]
        public ActionResult<Block> GetBlock(string hash)
        {

          var block=  blockList.Chain.Where(b => b.Hash == hash).FirstOrDefault();
            if (block==null)
            {
                return NotFound();
            }
            return block;
          
        }
        [HttpGet("{hash}/payloads")]
        public ActionResult<List<Payload>> GetItem(string hash)
        {
            
            var bd = blockList.Chain.Where(d => d.Hash == hash).SelectMany(b => b.Data).ToList();


            return bd;

        }

        [HttpPost]
        public ActionResult<Block> PostBlock(Block block)
        {                      
            if (block == null)
            {
                return NotFound();
            }
          var newblock=  service.SubmitNewBlock(block.Hash, block.Nonce, block.TimeStamp);
            if (newblock==null)
            {
                return BadRequest();
            }
            return newblock;
        }
    }
}
