using AddressManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManager.Domain.Interfaces
{
    public interface IObterEnderecoPorCepRepository
    {
        Task<Endereco> ObterEnderecoPorCep(string cep);
    }
}
