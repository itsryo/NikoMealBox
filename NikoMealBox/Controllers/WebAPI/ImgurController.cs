using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Imgur;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NikoMealBox.Controllers.WebAPI
{
    [RoutePrefix("api/[Controller]/[action]")]
    public class ImgurController : ApiController
    {
        // GET: api/Imgur
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Imgur/5
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST: api/Imgur
        public HttpResponseMessage Post([FromBody] string value)
        {
            //範例
            JObject request = JObject.Parse(value);
            string name = request["name"].ToString();
            string gender = request["gender"].ToString();
            var result = new
            {
                newname = name,
                newgender = gender,
            };
            return Request.CreateResponse(HttpStatusCode.OK, result , GlobalConfiguration.Configuration.Formatters.JsonFormatter);
        }

        // PUT: api/Imgur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Imgur/5
        public void Delete(int id)
        {
        }

        // Upload: api/Imgur/UploadAsync
        [HttpPost]
        public async System.Threading.Tasks.Task<HttpResponseMessage> UploadAsync([FromBody]Object base64json)
        {
            var apiclient = new ApiClient("1b1ed0a9fc10214", "36ebd8d5c71376376eebc39a6246ca429c297f50");
            var httpclient = new HttpClient();
            var token = new OAuth2Token
            {
                AccessToken = "0f65225be43e28aa15faf8797d2c16660e8443f7",
                RefreshToken = "b8e8f552f0b4050995372a210890959703ee3ccf",
                AccountId = 110824071,
                AccountUsername = "WayneLens",
                ExpiresIn = 315360000,
                TokenType = "bearer",
            };

            apiclient.SetOAuth2Token(token);
            var imageEndpoint = new ImageEndpoint(apiclient, httpclient);

            //反序
            JObject request = JObject.Parse(base64json.ToString());
            byte[] data = System.Convert.FromBase64String(request["base64"].ToString());
            MemoryStream ms = new MemoryStream(data);
            var imageUpload = await imageEndpoint.UploadImageAsync(ms);
            var response = new
            {
                imageUrl = imageUpload.Link,
            };

            return Request.CreateResponse(HttpStatusCode.OK, response, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
        }

    }
}
