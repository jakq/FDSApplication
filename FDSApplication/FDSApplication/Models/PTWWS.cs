using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class PTWWS
    {
        private int ptwwsId;
        private int rId;


        public int PtwwsId { get => ptwwsId; set => ptwwsId = value; }
        public int RId { get => rId; set => rId = value; }


        public PTWWS()
        {
        }

        public PTWWS(int rId)
        {
            this.rId = rId;
        }

        public PTWWS(int ptwwsId, int rId)
        {
            this.ptwwsId = ptwwsId;
            this.rId = rId;
        }
    }
}