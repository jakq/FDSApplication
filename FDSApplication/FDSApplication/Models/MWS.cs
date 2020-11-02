using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class MWS
    {
        private int mwsId;
        private int rId;

        public int MwsId { get => mwsId; set => mwsId = value; }
        public int RId { get => rId; set => rId = value; }

        public MWS()
        {
        }

        public MWS(int rId)
        {
            this.rId = rId;
        }

        public MWS(int mwsId, int rId)
        {
            this.mwsId = mwsId;
            this.rId = rId;
        }
    }
}