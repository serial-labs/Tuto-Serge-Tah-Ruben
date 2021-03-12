using pam_td.Metier.entite;
using pam_td.Metier.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pam_Web.Models
{
    public class ApplicationModel
    {
        public Employe[] Employes { get; set; }
        public IPamMetier pamMetier { get; set; }

        public SelectListItem[] EmployesItems {get;set;}


    }
}