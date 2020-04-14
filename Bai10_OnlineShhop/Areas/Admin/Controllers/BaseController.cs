using Bai10_OnlineShhop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bai10_OnlineShhop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session[CommonConstants.CurrentCulture] !=null)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
            }
            else
            {
                Session[CommonConstants.CurrentCulture] = "vi";
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
            }
        }

        public ActionResult ChangeCulture(string ddlCulture, string returnUrl)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ddlCulture);

            Session[CommonConstants.CurrentCulture] = ddlCulture;
            return Redirect(returnUrl);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                 RouteValueDictionary(new { Controller ="Login",Action="Index", Areas="Admin"}));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type== "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type== "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}