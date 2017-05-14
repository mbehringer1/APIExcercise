using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace APIConsole
{
    /// <summary>
    /// Api Console application
    /// </summary>
    class Program
    {
        /// <summary>
        /// The URL argument
        /// </summary>
        const string urlArg = "--SERVER.URLS";
        /// <summary>
        /// The default URL
        /// </summary>
        const string defaultUrl = "http://localhost";

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //i.e.
            //dotnet run --server.urls "http://localhost:5100;http://localhost:5101;http://*:5102"
            bool urlArgFound = args.ToList().Any(a => a.ToUpper().Contains(urlArg));

            if (!urlArgFound)
            {
                LinkedList<string> ll = new LinkedList<string>(args);
                ll.AddLast(urlArg);
                ll.AddLast(defaultUrl);
                args = ll.ToArray();
            }

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                //.UseUrls("http://localhost")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}