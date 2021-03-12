using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace pam_Web.Infrastructure
{
    public class Static
    {
        public static List<string> GetErreursForException(Exception ex)// rend liste d'erreur d'une pile d'excepetion
        {
            List<string> erreurs = new List<string>();
            while(ex != null)
            {
                erreurs.Add(ex.Message);
                ex = ex.InnerException;
            }
            return erreurs;
        }

        public static List<string> GetErreursForModel(ModelStateDictionary etat)//liste d'erreur d'un modele d'action invalide
        {
            List<string> erreurs = new List<string>();
            if (!etat.IsValid)
            {
                foreach(ModelState modelState in etat.Values)
                {
                    foreach(ModelError error in modelState.Errors)
                    {
                        erreurs.Add(getErrorMessageFor(error));
                    }
                }
            }
            return erreurs;
        }

        private static string getErrorMessageFor(ModelError error)
        {
            if(error.ErrorMessage != null && error.ErrorMessage.Trim() != string.Empty)
            {
                return error.ErrorMessage;
            }

            if(error.Exception!=null && error.Exception.InnerException == null && error.Exception.Message != string.Empty)
            {
                return error.Exception.Message;
            }

            if(error.Exception!=null && error.Exception.InnerException !=null && error.Exception.InnerException.Message!= string.Empty)
            {
                return error.Exception.InnerException.Message;
            }
            return string.Empty;
        }
    }
}