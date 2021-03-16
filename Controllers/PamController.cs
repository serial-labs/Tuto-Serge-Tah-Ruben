using Pam.Metier.Entites;
using pam_Web.Infrastructure;
using pam_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace pam_Web.Controllers
{
    public class PamController : Controller
    {
        
        [HttpGet]
        public ViewResult Index(ApplicationModel application)
        {
            if (application.InitException != null)
            {
                return View("InitFailed", Static.GetErreursForException(application.InitException));
            }


            return View(new IndexModel() { Application = application});
        }

        [HttpPost]
        public PartialViewResult FaireSimulation(ApplicationModel application,SessionModel session,FormCollection data)
        {
            //modele de l'action
            IndexModel model = new IndexModel() { Application = application };
            FeuilleSalaire feuilleSalaire = null;
            Exception exception = null;
            TryUpdateModel(model, data);
            if (!ModelState.IsValid)
            {
                
                return PartialView("Erreurs", Static.GetErreursForModel(ModelState));
            }
            try
            {
                
                feuilleSalaire = application.pamMetier.GetSalaire(data["Application.Employes"],model.HeuresTravaillees,(int)model.joursTravaillees);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            //erreur ?
            if (exception != null)
            {
                return PartialView("Erreurs", Static.GetErreursForException(exception));
                
            }
            session.Simulation = new Simulation()
            {
                FeuilleSalaire = feuilleSalaire,
                HeuresTravaillees = model.HeuresTravaillees,
                JoursTravaillees = (int)model.joursTravaillees,
                Num = session.NumNextSimulation++
            };
                //on affiche la feuille de salaire
                return PartialView("simulation", feuilleSalaire);
            
           
            
        }

        [HttpPost]
        public PartialViewResult EnregistrerSimulation(SessionModel session)
        {
            session.Simulations.Add(session.Simulation);//ajoute a la liste des simulation la derniere simulation
            session.NumNextSimulation++;// incermentation du n° de la next simulation

            return PartialView("Simulations", session.Simulations);
        }

        [HttpPost]
        public PartialViewResult VoirSimulation(SessionModel session)
        {
            return PartialView("simulations",session.Simulations);
        }

        [HttpPost]
        public PartialViewResult Formulaire(ApplicationModel application)
        {
            IndexModel model = new IndexModel() { Application = application };
            return PartialView("formulaire",model);
        }
        [HttpPost]
        public PartialViewResult TerminerSession(SessionModel session,ApplicationModel application)
        {
            IndexModel model = new IndexModel() { Application = application };
            session.Simulations.Clear();
            return PartialView("formulaire",model);
        }
        [HttpPost]
        public PartialViewResult RetirerSimulation(SessionModel session, int num)
        {
            session.Simulations.RemoveAt(num - 1);
            return PartialView("Simulations", session.Simulations);
        }
    }
}