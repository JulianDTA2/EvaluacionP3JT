using EvaluacionP3JT.ModelsJT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EvaluacionP3JT.ServicesJT
{
    public class CarApiServiceJT
    {
        private const string ApiUrl = "https://api.api-ninjas.com/v1/cars";
        private const string ApiKey = "XYyK8LuhRBrMCAqzIp+yag==38uMSAcz4WMaJb49";

        private readonly HttpClient _httpClient;

        public CarApiServiceJT()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
        }

        public async Task<List<CarsJT>> GetCarsAsync(string model)
        {
            var url = $"{ApiUrl}?model={model}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CarsJT>>(json);
        }
    }

}
