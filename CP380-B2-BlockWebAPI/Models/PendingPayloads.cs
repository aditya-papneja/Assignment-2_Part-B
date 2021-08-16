using CP380_B1_BlockList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Models
{
    public class PendingPayloads
    {
        List<Payload> Payloads = new List<Payload>();



        public List<Payload> ListofPayload()
        {
            return Payloads;
        }

        public void AddPayload(Payload payload)
        {
           Payloads.Add(payload);
        }
        public void RemovePaylod()
        {
            Payloads = new List<Payload>();
            
        }
    }
}
