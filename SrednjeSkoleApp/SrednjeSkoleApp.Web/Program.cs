using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
    ***REMOVED***

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
***REMOVED***
***REMOVED***
