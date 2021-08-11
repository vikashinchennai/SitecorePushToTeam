using Sitecore.PushToTeams.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace Sitecore.PushToTeams.Pipeline
{
    public class PushToTeamsPipeLine
    {
        private static string ApiUrl;

        public async void Process(PushToTeamsArgs requestModel)
        {
            ApiUrl = Configuration.Settings.GetSetting("PushToTeamsAPi");
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "URL"))
                {
                    request.Content = GenerateBody(requestModel);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }

        private StringContent GenerateBody(PushToTeamsArgs request)
        {
            var response = new TeamsModel()
            {
                summary = request.Summary,
                sections = new List<Section>()
                {
                     new Section()
                     {
                          activityTitle=request.Title,
                           activitySubtitle=request.SubTitle,
                            facts=request.Facets?.Select(f=>new Fact(f.Key, f.Value))?.ToList()??new List<Fact>()
                     }
                }
            };

            return new StringContent(JsonConvert.SerializeObject(response));
        }
    }
}



