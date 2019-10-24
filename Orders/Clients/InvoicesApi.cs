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
            client.BaseAddress = new Uri(readConfig.GetSection("invoicesAddr").Value);

            var data = JsonConvert.SerializeObject(OrderList, Formatting.Indented);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            //CONTENT-TYPE header 
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");

            // Try sending http POST request.
            try
            {
                var response = client.PostAsync("/SaveOrdersDetails", request.Content);
                string result = response.Result.ToString();
                Logger.Info("Sucessfully sent HTTP request");
                return result;
            }
            catch (HttpRequestException ex)
            {
                Logger.Warn("Error sending HTTP request", ex);
                return ex.ToString();
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