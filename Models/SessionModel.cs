using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pam_Web.Models
{
    public class SessionModel
    {
        internal int NumNextSimulation;

        public List<Simulation> Simulations { get; set; }
        public int NumNextSimulaiton { get; set; }

        public Simulation Simulation { get; set; }


        public SessionModel()
        {
            // liste des simulation vide
            Simulations = new List<Simulation>();
            //n° de la prochiane simulation
            NumNextSimulation = 1;
        }
    }
}