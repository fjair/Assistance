using Entities.Catalogs;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Aplication.Catalogs
{
    public interface IShiftService
    {
        Task<List<Tblturno>> GetShifts();
        Task<bool> PostShift(Tblturno turno);
        Task<bool> PutShift(Tblturno turno);
    }

    public class ShiftService : IShiftService
    {
        private readonly HttpClient _httpClient;
        private const string BaseURL = "http://192.168.7.103/api/Turno/";

        public ShiftService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        public async Task<List<Tblturno>> GetShifts()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("GetTurno");
                response.EnsureSuccessStatusCode();

                List<Tblturno> turnos = await response.Content.ReadFromJsonAsync<List<Tblturno>>();
                return turnos;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        public async Task<bool> PostShift(Tblturno turno)
        {
            try
            {
                string json = JsonConvert.SerializeObject(turno);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = "PostTurno";
                var response = await _httpClient.PostAsync(_endPoint, content);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }


        public async Task<bool> PutShift(Tblturno turno)
        {
            try
            {
                string json = JsonConvert.SerializeObject(turno);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var _endPoint = $"PutTurno/{turno.TurnoId}";
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
