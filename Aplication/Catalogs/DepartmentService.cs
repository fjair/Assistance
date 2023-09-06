using Entities.Catalogs;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Aplication.Catalogs
{

    public interface IDepartmentService
    {
        Task<List<Tbldepartamento>> GetDepartments();
        Task<Tbldepartamento> GetDepartmentById(int id);
        Task<bool> PostDepartament(Tbldepartamento departamento);
        Task<bool> PutDepartament(Tbldepartamento departmento);
    }

    public class DepartmentService: IDepartmentService
    {
        private readonly HttpClient _httpClient;
        private const string BaseURL = "http://192.168.7.103/api/Departamento/";

        public DepartmentService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        public async Task<List<Tbldepartamento>> GetDepartments()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("GetDepartamento");
                response.EnsureSuccessStatusCode();

                List<Tbldepartamento> departmentos = await response.Content.ReadFromJsonAsync<List<Tbldepartamento>>();
                return departmentos.OrderBy(x => x.DepartamentoId).ToList();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public async Task<Tbldepartamento> GetDepartmentById(int id)
        {
            try
            {
                return (await GetDepartments())
                    .FirstOrDefault(x => x.DepartamentoId == id);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public async Task<bool> PostDepartament(Tbldepartamento departmento)
        {
            try
            {
                string json = JsonConvert.SerializeObject(departmento);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = "PostDepartamento";
                var response = await _httpClient.PostAsync(_endPoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }


        public async Task<bool> PutDepartament(Tbldepartamento departmento)
        {
            try
            {
                string json = JsonConvert.SerializeObject(departmento);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = $"PutDepartamento/{departmento.Departamento}";
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
