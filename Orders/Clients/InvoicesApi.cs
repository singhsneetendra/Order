using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using NLog;
using Orders.Models;

namespace Orders.Clients
{
    public class InvoicesApi
    {
        public static string CreateOrder(List<ObjectType> OrderList)
        {
            // Setup logger.
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "logs/httpreq.log" };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            NLog.LogManager.Configuration = config;
            NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

            // Start building httpd client. 
            var client = new HttpClient();
            // ACCEPT header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Get base url from appsettings.json.
            var readConfig = GetConfiguration();
            string url = readConfig.GetSection("invoicesAddr").Value;
            if (url is null)
            {
                Logger.Warn("Error sending HTTP request not able to read from config url for Invoices api host to send post request to save invoice.");
                return ("Error sending HTTP request to Invoices api and saved Orders.");

            }
            client.BaseAddress = new Uri(url);

            var data = JsonConvert.SerializeObject(OrderList, Formatting.Indented);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            //CONTENT-TYPE header 
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");

            // Try sending http POST request.
            try
            {
                var response = client.PostAsync("/SaveOrdersDetails", request.Content);
                string responseDetails = response.Result.ToString();
                Logger.Info("Sucessfully sent HTTP request to api Invoices with repsonse" + responseDetails);
                return ("Sucessfully sent HTTP request to api Invoices");
            }
            catch (HttpRequestException ex)
            {
                Logger.Warn("Error sending HTTP request", ex);
                return ("Error sending HTTP request to Invoices api and saved Orders.");
            }
        }

        // setup builder to read  config.
        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}