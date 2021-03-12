using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pam_Web.Infrastructure
{
    public class ApplicationModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return controllerContext.RequestContext.HttpContext.Application["data"];
        }
    }
}