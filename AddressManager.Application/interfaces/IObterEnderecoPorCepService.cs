using AddressManager.Domain.Models;

namespace AddressManager.Application.interfaces
{
    public interface IObterEnderecoPorCepService
    {
        Task<Endereco> ObterEnderecoPorCep(string cep);
    }
}
