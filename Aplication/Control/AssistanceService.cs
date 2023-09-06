using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Entities.Models;
using Entities.Control;
using System.Net.Http.Json;

namespace Aplication.Control
{
    public interface IAssistanceService
    {        
        Task<bool> CheckAssistance(Captura datos);
        Task<List<Tblregistro>> GetAssistances();
    }

    public class AssistanceService : IAssistanceService
    {
        private readonly HttpClient _httpClient;
        private const string BaseURL = "http://192.168.7.103/api/";

        public AssistanceService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseURL);
        }


        public async Task<bool> CheckAssistance(Captura datos)
        {
            try
            {
                string json = JsonConvert.SerializeObject(datos);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = "Captura/Captura";
                var response = await _httpClient.PostAsync(_endPoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }       


        public async Task<List<Tblregistro>> GetAssistances()
        {
            try
            {                
                HttpResponseMessage response = await _httpClient.GetAsync("Registro/GetRegistro");
                response.EnsureSuccessStatusCode();

                List<Tblregistro> asistencias = await response.Content.ReadFromJsonAsync<List<Tblregistro>>();
                return asistencias;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
