using Newtonsoft.Json;
using Paccurate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Paccurate
{
    public class PackResponseHandler
    {
        private JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            NullValueHandling = NullValueHandling.Ignore
        };

        public PackResponseHandler()
        {

        }

        public PackResponseHandler(string ResponseJson, bool IsError = false)
        {
            // Determine if the response is an error or not.
            var serializer = JsonSerializer.Create(SerializerSettings);
            using (StringReader sr = new StringReader(ResponseJson))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    ResponseErrored = IsError;
                    if (!IsError)
                    {
                        
                        Response = JsonConvert.DeserializeObject<PackResponse>(ResponseJson);

                    }
                    else
                    {
                        ResponseError = JsonConvert.DeserializeObject<Error>(ResponseJson);

                    }
                }
            }
        }

        public PackResponse Response { get; set; }

        public Error ResponseError { get; set; }

        public bool ResponseErrored { get; set; }
    }
}
