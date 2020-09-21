using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Imgur;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;

namespace NikoMealBox.Controllers.WebAPI
{
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
            return "value";
        }

        // POST: api/Imgur
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Imgur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Imgur/5
        public void Delete(int id)
        {
        }

        // Test imgur upload
        public async System.Threading.Tasks.Task<string> UploadAsync()
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

            var filePath = "C:\\Users\\wayne\\Downloads\\ImgurAPI\\Imgur\\Picture\\abc.png";
            var fileStream = File.OpenRead(filePath);
            var imageUpload = await imageEndpoint.UploadImageAsync(fileStream);

            return imageUpload.Link;
        }
    }
}
