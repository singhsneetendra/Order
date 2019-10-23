using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NLog;

namespace Orders.Models
{
    public class Order
    {
        public static (bool, string) ValidateOrderList(List<ObjectType> OrderList)
        {
            // Setup Logger.
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "logs/Vaidation.log" };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            NLog.LogManager.Configuration = config;
            NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

            if (OrderList == null)
            {
                Logger.Warn("No input provided in POST! OR Orderlist has invalid Orders(Individual order is not proper JsonObject) - Please Check 'Example Value Schema'");
                return (false, "No input provided in POST! OR Orderlist has invalid Orders(Individual order is not proper JsonObject) - Please Check 'Example Value Schema'");
            }

            // Validata each element in orderlist.
            foreach (var JsonObj in OrderList)
            {
                if (Convert.ToInt32(JsonConvert.SerializeObject(JsonObj.ObjectID)) == 0)
                {
                    Logger.Warn("Illegal value for field ObjectID ( should be a number greater than 0)");
                    return (false, "Illegal value for field ObjectID ( should be a number greater than 0 )");
                }
                if (JsonConvert.SerializeObject(JsonObj.ObjectName) == null)
                {
                    Logger.Warn("Illegal value for field ObjectName ( should be a valid string )");
                    return (false, "Illegal value for field ObjectName ( should be a valid string )");
                }
                if (Convert.ToDecimal(JsonConvert.SerializeObject(JsonObj.ObjectPrice)) == 0)
                {
                    Logger.Warn("Illegal value for field ObjectPrice (should be a decimal greater than 0)");
                    return (false, "Illegal value for ObjecPrice (should be a decimal greater than 0)");
                }
                if (JsonConvert.SerializeObject(JsonObj.ObjectQuantity) == null)
                {
                    Logger.Warn("Illegal value for field ObjectQuantity ( should be decimal number greater than 0 or some string like - '12 Pieces') ");
                    return (false, "Illegal value for ObjectQuantity ( should be decimal number greater than 0 or some string like - '12 Pieces') ");
                }
            }
            Logger.Info("All orders are valid");
            return (true, "All Orders are Valid");
        }
    }
}