using Entities.Catalogs;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Aplication.Catalogs
{

    public interface ILocationService
    {
        Task<List<Tblzona>> GetLocations();
        Task<bool> PostLocation(Tblzona zona);
        Task<bool> PutLocation(Tblzona zona);
    }

    public class LocationService: ILocationService
    {
        private readonly HttpClient _httpClient;
        private const string BaseURL = "http://192.168.7.103/api/Zona/";

        public LocationService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        public async Task<List<Tblzona>> GetLocations()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("GetZona");
                response.EnsureSuccessStatusCode();

                List<Tblzona> zonas = await response.Content.ReadFromJsonAsync<List<Tblzona>>();
                return zonas;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public async Task<bool> PostLocation(Tblzona zona)
        {
            try
            {
                string json = JsonConvert.SerializeObject(zona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = "PostZona";
                var response = await _httpClient.PostAsync(_endPoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }


        public async Task<bool> PutLocation(Tblzona zona)
        {
            try
            {
                string json = JsonConvert.SerializeObject(zona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = $"PostZona/{zona.ZonaId}";
                var response = await _httpClient.PutAsync(_endPoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
