using Pam.Metier.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pam_Web.Models
{
    public class Simulation
    {
        public int Num { get; set; }//n° Simulation
        public double HeuresTravaillees { get; set; }
        public int JoursTravaillees{get;set;}

        public FeuilleSalaire FeuilleSalaire { get; set; }
    }
}