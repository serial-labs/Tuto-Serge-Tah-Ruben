using Pam.EF5.Entites;
using Pam.Metier.Service;
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

        public Exception InitException { get; set; }

    }
}