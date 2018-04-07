using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory
{
    class ARecruitment : IEvent
    {
        private Date date;
        private Pawn recruiter;
        private Pawn recruitee;

        public ARecruitment(Date date, Pawn recruiter, Pawn recruitee)
        {
            this.date = date;
            this.recruiter = recruiter;
            this.recruitee = recruitee;
        }

        public Date Date()
        {
            throw new NotImplementedException();
        }

        public void EndEvent()
        {
            throw new NotImplementedException();
        }

        public void ExposeData()
        {
            throw new NotImplementedException();
        }

        public bool GetIsAnniversary()
        {
            throw new NotImplementedException();
        }

        public bool IsStillEvent()
        {
            throw new NotImplementedException();
        }

        public string ShowInLog()
        {
            //return (date.day + " " + date.quadrum + " " + date.year + " " + recruiter.Name + " recruited " + recruitee.Name);
            return (date.day + " " + date.quadrum + " " + date.year + " " + "ARecruitment".Translate(new object[] { recruiter.Name, recruitee.Name }));
        }

        public bool TryStartEvent()
        {
            throw new NotImplementedException();
        }

        public bool TryStartEvent(Map map)
        {
            throw new NotImplementedException();
        }
    }
}
