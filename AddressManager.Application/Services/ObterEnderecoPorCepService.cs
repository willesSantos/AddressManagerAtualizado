using AddressManager.Application.interfaces;
using AddressManager.Domain.Interfaces;
using AddressManager.Domain.Models;
using AutoMapper;

namespace AddressManager.Application.Services
{
    public class ObterEnderecoPorCepService : IObterEnderecoPorCepService
    {
        private readonly IMapper _mapper;
        private readonly IObterEnderecoPorCepRepository _enderecoRepository;

        public ObterEnderecoPorCepService(IMapper mapper, IObterEnderecoPorCepRepository enderecoRepository)
        {
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> ObterEnderecoPorCep(string cep)
        {
            Endereco endereco = await _enderecoRepository.ObterEnderecoPorCep(cep);
            
            return endereco;
        }
    }
}
