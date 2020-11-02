using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class WWS
    {
        private int wwsId;
        private int mwsId;
        private DateTime wwsDate;
        private DateTime wwsStartTime;
        private DateTime wwsEndTime;
        private DateTime wwsStartTimeTwo;
        private DateTime wwsEndTimeTwo;

        public int WwsId { get => wwsId; set => wwsId = value; }
        public int MwsId { get => mwsId; set => mwsId = value; }
        public DateTime WwsDate { get => wwsDate; set => wwsDate = value; }
        public DateTime WwsStartTime { get => wwsStartTime; set => wwsStartTime = value; }
        public DateTime WwsEndTime { get => wwsEndTime; set => wwsEndTime = value; }
        public DateTime WwsStartTimeTwo { get => wwsStartTimeTwo; set => wwsStartTimeTwo = value; }
        public DateTime WwsEndTimeTwo { get => wwsEndTimeTwo; set => wwsEndTimeTwo = value; }


        public WWS()
        {
        }

        public WWS(int wwsId, int mwsId, DateTime wwsDate, DateTime wwsStartTime, DateTime wwsEndTime, DateTime wwsStartTimeTwo, DateTime wwsEndTimeTwo)
        {
            this.wwsId = wwsId;
            this.mwsId = mwsId;
            this.wwsDate = wwsDate;
            this.wwsStartTime = wwsStartTime;
            this.wwsEndTime = wwsEndTime;
            this.wwsStartTimeTwo = wwsStartTimeTwo;
            this.wwsEndTimeTwo = wwsEndTimeTwo;
        }

        public WWS(int mwsId, DateTime wwsDate, DateTime wwsStartTime, DateTime wwsEndTime, DateTime wwsStartTimeTwo, DateTime wwsEndTimeTwo)
        {
            this.mwsId = mwsId;
            this.wwsDate = wwsDate;
            this.wwsStartTime = wwsStartTime;
            this.wwsEndTime = wwsEndTime;
            this.wwsStartTimeTwo = wwsStartTimeTwo;
            this.wwsEndTimeTwo = wwsEndTimeTwo;
        }
    }
}