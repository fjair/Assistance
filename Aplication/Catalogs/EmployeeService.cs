using Entities.Catalogs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Aplication.Catalogs
{
    public interface IEmployeeService
    {
        Task<List<Tblempleado>> GetEmployees();
        Task<bool> PostEmployee(Tblempleado empleado);
        Task<bool> PutEmployee(Tblempleado empleado);
    }

    public class EmployeeService: IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private const string BaseURL = "http://192.168.7.103/api/Empleados/";

        public EmployeeService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        public async Task<List<Tblempleado>> GetEmployees()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("GetEmpleado");
                response.EnsureSuccessStatusCode();

                List<Tblempleado> empleados = await response.Content.ReadFromJsonAsync<List<Tblempleado>>();
                return empleados.OrderBy(x => x.EmpleadoId).ToList();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public async Task<bool> PostEmployee(Tblempleado empleado)
        {
            try
            {
                string json = JsonConvert.SerializeObject(empleado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = "PostEmpleado";
                var response = await _httpClient.PostAsync(_endPoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }


        public async Task<bool> PutEmployee(Tblempleado empleado)
        {
            try
            {
                string json = JsonConvert.SerializeObject(empleado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = $"PutEmpleado/{empleado.EmpleadoId}";
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
