using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class Staff
    {
        private int staffId;
        private int restId;
        private string staffName;

        public Staff(int staffId, int restId, string staffName)
        {
            this.staffId = staffId;
            this.restId = restId;
            this.staffName = staffName;
        }

        public Staff(int staffId, string staffName)
        {
            this.staffId = staffId;
            this.staffName = staffName;
        }

        public int StaffId { get => staffId; set => staffId = value; }
        public int RestId { get => restId; set => restId = value; }
        public string StaffName { get => staffName; set => staffName = value; }
    }
}