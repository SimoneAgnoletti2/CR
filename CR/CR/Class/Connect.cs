using CR.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CR.Class
{
    public class Connect : IConnect
    {
        public HttpResponseMessage response;
        private string ResponseJSon = "";

        public HttpClient ClientConnectionAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTAwMiwiaWRlbiI6IjQzODIyNjUzNTQ3Njg4NzU1MiIsIm1kIjp7InVzZXJuYW1lIjoiaXptYWVsemlndXJhdCIsImtleVZlcnNpb24iOjMsImRpc2NyaW1pbmF0b3IiOiI5ODA0In0sInRzIjoxNTMwMDE5NDY1OTI0fQ.1Y-QrCbHdbz_AK-OYY4F6i32f58Z4bc6A_kJ0cOiVCE");
            return client;
        }

        public async Task<string> DatiRequestAsync(string apiCall, List<Parameter> parameter)
        {
            string json = "";
            string call = "";

            call = ComposeCall(apiCall, parameter);

            try
            {
                var httpClient = ClientConnectionAsync();
                HttpResponseMessage response = httpClient.GetAsync(call).Result;



                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
                return json;
            }
            catch(Exception ex)
            {
                json = ex.Message.ToString();
                return json;
            }
        }

        public async Task<Player> GetPlayer(string tag)
        {
            try
            {
                List<Parameter> Parametri = new List<Parameter>();
                Parametri.Add(new Parameter("tag", "2Q2QU8LU"));
                Parametri.Add(new Parameter("tag", "8L9L9GL"));
                var response = await DatiRequestAsync("player", Parametri);
                Player player = JsonConvert.DeserializeObject<Player>(response);
                return player;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Player>> GetComparePlayers(List<string> tag)
        {
            try
            {
                List<Parameter> Parametri = new List<Parameter>();
                Parametri.Add(new Parameter("tag", "2Q2QU8LU"));
                Parametri.Add(new Parameter("tag", "8LJCVPVJ"));
                var response = await DatiRequestAsync("player", Parametri);
                List<Player> player = JsonConvert.DeserializeObject<List<Player>>(response);
                return player;
            }
            catch
            {
                return null;
            }
        }


        private string ComposeCall(string apiCall, List<Parameter> parameter)
        {
            string url = "";
            url = Constant.Uri + apiCall + "/";
            for (int i = 0; i < parameter.Count; i++)
            {
                if (i == 0)
                {
                    url += parameter[i].Value;
                }
                else
                {
                    url += "," + parameter[i].Value;
                }
            }
            return url;

        }
    }
}
