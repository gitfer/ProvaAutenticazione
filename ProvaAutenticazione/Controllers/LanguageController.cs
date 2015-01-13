using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;

namespace ProvaAutenticazione.Controllers
{
    [AllowAnonymous]
    public class LanguageController : ApiController
    {
        public object Get(string lang)
        {

            ResourceManager rm = new ResourceManager("ProvaAutenticazione.Language_"+lang, this.GetType().Assembly);
            ResourceSet resourceSet = rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            
            //ResourceSet resourceSet = Language.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            Dictionary<string, string> dic=resourceSet.Cast<DictionaryEntry>()
           .ToDictionary(x => x.Key.ToString(),
                         x => x.Value.ToString());


            var entries = dic.Select(d =>
                string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
            var traduzione = "{" + string.Join(",", entries) + "}";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(traduzione));
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Language_"+lang+".json"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            result.Content.Headers.ContentLength = stream.Length;

            return result;
            return JsonConvert.SerializeObject(resourceSet);

var jsonString = JsonConvert.SerializeObject(resourceSet);
            string allText = System.IO.File.ReadAllText(
                @"C:\Users\Fede\SPA\ProvaAutenticazione\ProvaAutenticazione\Language.json");

            object jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(allText);
            return jsonObject;
        }
    }
}
