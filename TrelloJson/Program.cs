using System;
using System.IO;
using System.Web.Script.Serialization;

namespace TrelloJson
{
    class Program
    {
        static void Main(params string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: TrelloJson.exe <trellojsonoutput.json>");
                return;
            }
            // store all data from the given file into a data variable
            var data = File.ReadAllText(args[0]);

            // deserialize data. After deserialization, our object json will be 
            // populated with information from JSON file
            var serializer = new JavaScriptSerializer();
            var json = serializer.Deserialize<Trello>(data);

            json.PopulateLists();

            // write some information about our objects we just populated from
            // JSON file to do a proof of concept
            Console.WriteLine("Board {0} has {1} lists, {2} cards, {3} actions", 
                json.Name,
                json.Lists.Count,
                json.Cards.Count,
                json.Actions.Count);

            //json.Dump();
            json.DumpHtml();
            
            // optionally, write some data to file using our objects
            //var sb = new StringBuilder();
            //sb.AppendLine("Name|Created|Modified|Archived|List");
            //foreach (var card in json.Cards)
            //{
            //    sb.AppendLine(card.ToString() + "|" + json.ListName(card.IdList));
            //}
            //File.WriteAllText(JsonFile + ".output.txt", sb.ToString());
        }
    }

}
