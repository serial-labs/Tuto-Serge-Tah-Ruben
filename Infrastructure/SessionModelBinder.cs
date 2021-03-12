using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pam_Web.Infrastructure
{
    public class SessionModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // ren les données de pportée session
            return controllerContext.HttpContext.Session["data"];
        }
    }
}