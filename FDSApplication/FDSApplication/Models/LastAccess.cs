using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class LastAccess
    {
        private int accessId;
        private DateTime accessDate;

        public LastAccess()
        {
        }

        public LastAccess(int accessId, DateTime accessDate)
        {
            this.accessId = accessId;
            this.accessDate = accessDate;
        }

        public LastAccess(DateTime accessDate)
        {
            this.accessDate = accessDate;
        }

        public int AccessId { get => accessId; set => accessId = value; }
        public DateTime AccessDate { get => accessDate; set => accessDate = value; }
    }
}