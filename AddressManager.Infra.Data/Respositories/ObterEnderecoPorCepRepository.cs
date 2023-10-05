using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models;
using Newtonsoft.Json;

namespace AddressManager.Infra.Data.Respositories
{
    public class ObterEnderecoPorCepRepository : IObterEnderecoPorCepRepository
    {
        public async Task<Endereco> ObterEnderecoPorCep(string cep)
        {
            Endereco endereco = null;

            var baseAddress = "https://viacep.com.br/ws/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = client.GetAsync($"{cep}/json/").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                endereco = JsonConvert.DeserializeObject<Endereco>(content);
                endereco.cep = endereco.cep.Replace("-", "");
                return endereco;
            }

            return endereco;
        }
    }
}
