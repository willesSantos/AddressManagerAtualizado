using AddressManager.Application.interfaces;
using AddressManager.Domain.Models;
using AutoMapper;
using AddressManager.Domain.Interfaces;
using AddressManager.Application.DTOs;
using Newtonsoft.Json;

namespace AddressManager.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository repository, IMapper mapper) : this(repository)
        {
            _mapper = mapper;
        }

        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EnderecoDTO>> FindAll(int skip, int take)
        {
            var enderecos = await _repository.FindAll(skip, take);
            
            return _mapper.Map<List<EnderecoDTO>>(enderecos);
        }

        public async Task<EnderecoDTO> Create(EnderecoDTOSemId enderecoSEmIdDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoSEmIdDto);
            _repository.Create(endereco);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public async Task<EnderecoDTO> Update(EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            var enderecoAlterado = await _repository.Update(endereco);
            return _mapper.Map<EnderecoDTO>(enderecoAlterado);
        }
        public async Task<bool> Delete(EnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
            await _repository.Delete(endereco);
            return true;
        }

        public async Task<EnderecoDTO> FindById(int id)
        {
            Endereco endereco = await _repository.FindById(id);
            return _mapper.Map<EnderecoDTO>(endereco);
        }
    }
}
