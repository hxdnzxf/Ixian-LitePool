﻿using System;
using Owin;
using System.Web.Http;
using System.Net.Http;
using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;

[assembly: OwinStartup(typeof(LP.Pool.Startup))]
namespace LP.Pool
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "default",
                routeTemplate: "api/{controller}"
                );

            appBuilder.UseWebApi(config);

            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true,
                DefaultFilesOptions = { DefaultFileNames = { "index.html" } },
                FileSystem = new PhysicalFileSystem("wwwroot")
            };

            appBuilder.UseFileServer(options);
        }
    }
}
