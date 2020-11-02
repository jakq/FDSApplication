using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSApplication.Models
{
    public class PTDaySchedule
    {
        private int ptDayScheduleId;
        private int ptwwsId;
        private DateTime ptwwsDate;
        private DateTime ptwwsStartTime;
        private DateTime ptwwsEndTime;
        private DateTime ptwwsStartTimeTwo;
        private DateTime ptwwsEndTimeTwo;
        private DateTime ptwwsStartTimeThree;
        private DateTime ptwwsEndTimeThree;


        public int PtDayScheduleId { get => ptDayScheduleId; set => ptDayScheduleId = value; }
        public int PtwwsId { get => ptwwsId; set => ptwwsId = value; }
        public DateTime PtwwsDate { get => ptwwsDate; set => ptwwsDate = value; }
        public DateTime PtwwsStartTime { get => ptwwsStartTime; set => ptwwsStartTime = value; }
        public DateTime PtwwsEndTime { get => ptwwsEndTime; set => ptwwsEndTime = value; }
        public DateTime PtwwsStartTimeTwo { get => ptwwsStartTimeTwo; set => ptwwsStartTimeTwo = value; }
        public DateTime PtwwsEndTimeTwo { get => ptwwsEndTimeTwo; set => ptwwsEndTimeTwo = value; }
        public DateTime PtwwsStartTimeThree { get => ptwwsStartTimeThree; set => ptwwsStartTimeThree = value; }
        public DateTime PtwwsEndTimeThree { get => ptwwsEndTimeThree; set => ptwwsEndTimeThree = value; }


        public PTDaySchedule()
        {
        }

        public PTDaySchedule(int ptDayScheduleId, int ptwwsId, DateTime ptwwsDate, DateTime ptwwsStartTime, DateTime ptwwsEndTime, DateTime ptwwsStartTimeTwo, DateTime ptwwsEndTimeTwo, DateTime ptwwsStartTimeThree, DateTime ptwwsEndTimeThree)
        {
            this.ptDayScheduleId = ptDayScheduleId;
            this.ptwwsId = ptwwsId;
            this.ptwwsDate = ptwwsDate;
            this.ptwwsStartTime = ptwwsStartTime;
            this.ptwwsEndTime = ptwwsEndTime;
            this.ptwwsStartTimeTwo = ptwwsStartTimeTwo;
            this.ptwwsEndTimeTwo = ptwwsEndTimeTwo;
            this.ptwwsStartTimeThree = ptwwsStartTimeThree;
            this.ptwwsEndTimeThree = ptwwsEndTimeThree;
        }

        public PTDaySchedule(int ptwwsId, DateTime ptwwsDate, DateTime ptwwsStartTime, DateTime ptwwsEndTime, DateTime ptwwsStartTimeTwo, DateTime ptwwsEndTimeTwo, DateTime ptwwsStartTimeThree, DateTime ptwwsEndTimeThree)
        {
            this.ptwwsId = ptwwsId;
            this.ptwwsDate = ptwwsDate;
            this.ptwwsStartTime = ptwwsStartTime;
            this.ptwwsEndTime = ptwwsEndTime;
            this.ptwwsStartTimeTwo = ptwwsStartTimeTwo;
            this.ptwwsEndTimeTwo = ptwwsEndTimeTwo;
            this.ptwwsStartTimeThree = ptwwsStartTimeThree;
            this.ptwwsEndTimeThree = ptwwsEndTimeThree;
        }

        public PTDaySchedule(int ptwwsId, DateTime ptwwsDate, DateTime ptwwsStartTime, DateTime ptwwsEndTime, DateTime ptwwsStartTimeTwo, DateTime ptwwsEndTimeTwo)
        {
            this.ptwwsId = ptwwsId;
            this.ptwwsDate = ptwwsDate;
            this.ptwwsStartTime = ptwwsStartTime;
            this.ptwwsEndTime = ptwwsEndTime;
            this.ptwwsStartTimeTwo = ptwwsStartTimeTwo;
            this.ptwwsEndTimeTwo = ptwwsEndTimeTwo;
        }

        public PTDaySchedule(int ptwwsId, DateTime ptwwsDate, DateTime ptwwsStartTime, DateTime ptwwsEndTime)
        {
            this.ptwwsId = ptwwsId;
            this.ptwwsDate = ptwwsDate;
            this.ptwwsStartTime = ptwwsStartTime;
            this.ptwwsEndTime = ptwwsEndTime;
        }
    }
}