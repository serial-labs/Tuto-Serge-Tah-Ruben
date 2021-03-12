using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pam_Web.Models
{
    [Bind(Exclude="Application")]
    public class IndexModel
    {

        public ApplicationModel Application { get; set; }


        //valeurs postées
        [Display(Name="Employe")]
        public string SS { get; set; }
        [Display(Name ="Heures travaillees")]
        [Range(0,400,ErrorMessage ="Le champs Heures doit etre un nombre compris en 0 et 400")]
        [UIHint("Decimal")]
        public double HeuresTravaillees { get; set; }
        [Display(Name = "Jours travaillees")]
        [Range(0, 31, ErrorMessage = "Le champs Heures doit etre un nombre compris entre 0 et  31")]
        public double joursTravaillees { get; set; }
    }
}