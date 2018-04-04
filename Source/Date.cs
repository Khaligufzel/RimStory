﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace RimStory
{
    public class Date : IExposable
    {

        public int day;
        public Quadrum quadrum;
        public int year;

 

        public Date(int day, Quadrum quadrum, int year)
        {
            this.day = day;
            this.quadrum = quadrum;
            this.year = year;           
        }

        public void ExposeData()
        {
            throw new NotImplementedException();
        }

        public Date getDate()
        {
            return this;
        }

        public override string ToString()
        {
            return day + " " + quadrum + " " + year;
        }
    }

    
}