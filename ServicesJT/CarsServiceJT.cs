using EvaluacionP3JT.ModelsJT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionP3JT.ServicesJT
{
    public class CarsServiceJT
    {
        public async Task<CarsJT> GetImage(DateTime dt)
        {
            CarsJT dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.api-ninjas.com/v1/cars?&api_key=XYyK8LuhRBrMCAqzIp+yag==38uMSAcz4WMaJb49";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<CarsJT>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;
        }
    }

}
