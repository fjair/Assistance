using Entities.Catalogs;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Aplication.Catalogs
{
    public interface IJobService
    {
        Task<List<Tblpuesto>> GetJobs();
        Task<bool> PostJob(Tblpuesto puesto);
        Task<bool> PutJob(Tblpuesto puesto);
    }

    public class JobService: IJobService
    {
        private readonly HttpClient _httpClient;
        private const string BaseURL = "http://192.168.7.103/api/Puesto/";

        public JobService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        public async Task<List<Tblpuesto>> GetJobs()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("GetPuesto");
                response.EnsureSuccessStatusCode();

                List<Tblpuesto> puestos = await response.Content.ReadFromJsonAsync<List<Tblpuesto>>();
                return puestos.OrderBy(x => x.PuestoId).ToList();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public async Task<bool> PostJob(Tblpuesto puesto)
        {
            try
            {
                string json = JsonConvert.SerializeObject(puesto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = "PostPuesto";
                var response = await _httpClient.PostAsync(_endPoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }


        public async Task<bool> PutJob(Tblpuesto puesto)
        {
            try
            {
                string json = JsonConvert.SerializeObject(puesto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = $"PutPuesto/{puesto.PuestoId}";
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
