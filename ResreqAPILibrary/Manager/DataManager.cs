using Newtonsoft.Json;
using ResreqAPILibrary.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResreqAPILibrary.Manager
{
    public class DataManager
    {
        public T DeserializeUserData<T>(string jsonPath) where T : ICommonModel
        {
            return JsonConvert.DeserializeObject<T>(GetContentFromJson(jsonPath));
        }
 
        public string GetContentFromJson(string jsonPath)
        {
            var path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, jsonPath); ;
            return File.ReadAllText(path);
        }
    }
}
