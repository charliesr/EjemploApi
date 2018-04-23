using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace EjemploApi.Business.Facade.WebApi.Controllers
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {

        private HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            try
            {
                var controllers = GetControllerMapping();
                var routeData = request.GetRouteData();

                var controllerName = routeData.Values["controller"].ToString();

                HttpControllerDescriptor controllerDescriptor;

                if (GetVersionFromAcceptHeader(request) == "v1")
                {
                    if (controllers.TryGetValue(controllerName, out controllerDescriptor))
                    {
                        return controllerDescriptor;
                    }

                }
                else
                {
                    controllerName = string.Concat(controllerName, "v2");
                    if (controllers.TryGetValue(controllerName, out controllerDescriptor))
                    {
                        return controllerDescriptor;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private string GetVersionFromQueryString(HttpRequestMessage request)
        {
            var version = HttpUtility.ParseQueryString(request.RequestUri.Query);
            return version[0] != null ? version[0] : "v1";

        }

        private string GetVersionFromHeader(HttpRequestMessage request)
        {
            const string HEADER_NAME = "Version-Num";

            if (request.Headers.Contains(HEADER_NAME))
            {
                var versionHeader = request.Headers.GetValues(HEADER_NAME).FirstOrDefault();
                if (versionHeader != null)
                {
                    return versionHeader;
                }
            }

            return "v1";
        }

        private string GetVersionFromAcceptHeader(HttpRequestMessage request)
        {
            var acceptHeader = request.Headers.Accept;

            foreach (var mime in acceptHeader)
            {
                if (mime.MediaType == "application/json")
                {
                    return "v2";
                }
                else if (mime.MediaType == "application/xml")
                {
                    return "v1";
                }
                else { return "v1"; }

            }
            return "v1";
        }

        #region Por QueryString

        //private HttpConfiguration _config;
        //public CustomControllerSelector(HttpConfiguration config) : base(config)
        //{
        //    _config = config;
        //}

        //public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        //{
        //    try
        //    {
        //        var controllers = GetControllerMapping();
        //        var routeData = request.GetRouteData();

        //        var controllerName = routeData.Values["controller"].ToString();

        //        HttpControllerDescriptor controllerDescriptor;

        //        if (GetVersionFromQueryString(request) == "v1")
        //        {
        //            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //            {
        //                return controllerDescriptor;
        //            }

        //        }
        //        else
        //        {
        //            controllerName = string.Concat(controllerName, "v2");
        //            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //            {
        //                return controllerDescriptor;
        //            }
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //private string GetVersionFromQueryString(HttpRequestMessage request)
        //{
        //    var version = HttpUtility.ParseQueryString(request.RequestUri.Query);
        //    return version[0] != null ? version[0] : "v1";

        //}

        #endregion

        #region Por CustomHeader

        //private HttpConfiguration _config;
        //public CustomControllerSelector(HttpConfiguration config) : base(config)
        //{
        //    _config = config;
        //}

        //public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        //{
        //    try
        //    {
        //        var controllers = GetControllerMapping();
        //        var routeData = request.GetRouteData();

        //        var controllerName = routeData.Values["controller"].ToString();

        //        HttpControllerDescriptor controllerDescriptor;

        //        if (GetVersionFromHeader(request) == "v1")
        //        {
        //            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //            {
        //                return controllerDescriptor;
        //            }

        //        }
        //        else
        //        {
        //            controllerName = string.Concat(controllerName, "v2");
        //            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //            {
        //                return controllerDescriptor;
        //            }
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //private string GetVersionFromHeader(HttpRequestMessage request)
        //{
        //    const string HEADER_NAME = "Version-Num";

        //    if (request.Headers.Contains(HEADER_NAME))
        //    {
        //        var versionHeader = request.Headers.GetValues(HEADER_NAME).FirstOrDefault();
        //        if (versionHeader != null)
        //        {
        //            return versionHeader;
        //        }
        //    }

        //    return "v1";
        //}

        #endregion

        #region Por Acceptheader - Mimetype xml vs json

        //private HttpConfiguration _config;
        //public CustomControllerSelector(HttpConfiguration config) : base(config)
        //{
        //    _config = config;
        //}

        //public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        //{
        //    try
        //    {
        //        var controllers = GetControllerMapping();
        //        var routeData = request.GetRouteData();

        //        var controllerName = routeData.Values["controller"].ToString();

        //        HttpControllerDescriptor controllerDescriptor;

        //        if (GetVersionFromAcceptHeader(request) == "v1")
        //        {
        //            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //            {
        //                return controllerDescriptor;
        //            }

        //        }
        //        else
        //        {
        //            controllerName = string.Concat(controllerName, "v2");
        //            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
        //            {
        //                return controllerDescriptor;
        //            }
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //private string GetVersionFromAcceptHeader(HttpRequestMessage request)
        //{
        //    var acceptHeader = request.Headers.Accept;

        //    foreach (var mime in acceptHeader)
        //    {
        //        if (mime.MediaType == "application/json")
        //        {
        //            return "v2";
        //        }
        //        else if (mime.MediaType == "application/xml")
        //        {
        //            return "v1";
        //        }
        //        else { return "v1"; }

        //    }
        //    return "v1";
        //}

        #endregion
    }
}