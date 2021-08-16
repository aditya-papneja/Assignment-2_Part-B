using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Services
{
    public class BlockListService
    {
        private readonly IConfiguration configuration;
        private readonly BlockList blockList;
        private readonly PendingPayloads pendingPayloads;

        public BlockListService(IConfiguration configuration,BlockList blockList,PendingPayloads pendingPayloads)
        {
            this.configuration = configuration;
            this.blockList = blockList;
            this.pendingPayloads = pendingPayloads;
        }
        public Block SubmitNewBlock(string hash,int nounce,DateTime timestamp)
        {
            var pendingPayload = pendingPayloads.ListofPayload();
            Block block = new();
            block.TimeStamp = timestamp;
            block.Nonce = nounce;
            block.PreviousHash = blockList.GetLatestBlock().Hash;
            block.Data = pendingPayload;
            block.Hash = block.CalculateHash();
            
            if (blockList.IsValid())
            {
                blockList.AddBlock(block);
                pendingPayloads.RemovePaylod();
                return block;
            }
            return null;
           
            



        }
    }
}
