using LabelLoader.Buservice;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace LabelLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            var list = new List<Message>();
            //{ "ItemName": "meat",
            // "Ingredients": ["diary","gluten","soy"] }

            var labelLoader = new LabelLoaderService(list, configuration["serviceBus:connectionString"]);
            labelLoader.SendMessagesAsync(JsonConvert.SerializeObject(new { ItemName = "meat", Ingredients = new List<string>() { "diary", "gluten", "soy" } }));
            labelLoader.SendMessagesAsync(JsonConvert.SerializeObject(new { ItemName = "ketchup", Ingredients = new List<string>() { "tomato", "sugar", "preservatives" } }));

        }
    }
}
