using pam_td.Metier;
using pam_td.Metier.entite;
using pam_td.Metier.service;
using pam_Web.Infrastructure;
using pam_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace pam_Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //-----------------------------------------------------------------
            //------------------configuration specifique
            //-----------------------------------------------------------------
            //données de portées d'applications

            ApplicationModel application = new ApplicationModel();
            Application["data"] = application;
            Employe employe = new Employe();
            //instanciation couche metier
            application.pamMetier = new PamMetier();
            
            //tableau des employes
            application.Employes = application.pamMetier.GetAllIdentitesEmployes();


            // elements du combo des employes
            int nbEmpolyees = application.Employes.Length;
            application.EmployesItems = new SelectListItem[nbEmpolyees];
            for (int i = 0; i < nbEmpolyees; i++)
            {
                application.EmployesItems[i] = new SelectListItem() { Text = application.Employes[i].Nom + " " + application.Employes[i].Prenom, Value = application.Employes[i].SS };
            }
            //model binders
            ModelBinders.Binders.Add(typeof(ApplicationModel), new ApplicationModelBinder());
            ModelBinders.Binders.Add(typeof(SessionModel), new SessionModelBinder());


        }

        protected void Session_Start()
        {
            Session["data"] = new SessionModel();
        }
    }
}
