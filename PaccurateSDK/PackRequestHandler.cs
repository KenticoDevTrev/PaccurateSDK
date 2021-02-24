using Newtonsoft.Json;
using Paccurate.Models;
using System.IO;
using System.Net;

namespace Paccurate
{
    public class PackRequestHandler
    {
        private JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            NullValueHandling = NullValueHandling.Ignore        };

        public PackRequestHandler()
        {

        }

        public PackRequestHandler(PackRequest Request)
        {
            this.Request = Request;
        }

        /// <summary>
        /// The Paccurate Pack Request
        /// </summary>
        public PackRequest Request { get; set; }

        public PackResponseHandler GetResponse()
        {
            using (var client = new WebClient())
            {
                client.Headers.Clear();
                //Define request data format  
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                var data = JsonConvert.SerializeObject(Request, SerializerSettings);

                PackResponseHandler Response = null;
                try
                {
                    string result = client.UploadString("http://api.paccurate.io/", data);
                    Response = new PackResponseHandler(result);
                }
                catch (WebException ex)
                {
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        Response = new PackResponseHandler(streamReader.ReadToEnd(), true);
                    }
                }

                return Response;
            }
        }
    }
}
