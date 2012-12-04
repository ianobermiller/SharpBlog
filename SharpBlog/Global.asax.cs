using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Raven.Client;
using Raven.Client.Document;
using SharpBlog.Controllers;
using SharpBlog.Models;
using SharpBlog.ViewModels;

namespace SharpBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            BeginRequest += (sender, args) =>
            {
                HttpContext.Current.Items[Constants.RavenSessionKey] = RavenController.DocumentStore.OpenSession();
            };

            EndRequest += (sender, args) =>
            {
                using (var session = (Raven.Client.IDocumentSession)HttpContext.Current.Items[Constants.RavenSessionKey])
                {
                    if (session == null)
                        return;

                    if (Server.GetLastError() != null)
                        return;

                    session.SaveChanges();
                }
            };
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDocumentStore();

            RavenController.DocumentStore = DocumentStore;

            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            Mapper.CreateMap<PostAdd, Post>().ForMember(pa => pa.DocumentId, opt => opt.Ignore());
        }

        public static IDocumentStore DocumentStore { get; private set; }

        private static void InitializeDocumentStore()
        {
            if (DocumentStore != null) return; // prevent misuse

            DocumentStore = new DocumentStore
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();

            DocumentStore.Conventions.FindIdentityProperty = prop =>
            {
                return prop.Name == "DocumentId";
            };
        }
    }
}