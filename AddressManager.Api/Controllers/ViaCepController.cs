using AddressManager.Application.DTOs;
using AddressManager.Application.interfaces;
using AddressManager.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AddressManager.Api.Controllers
{
    public class ObterEnderecoViaCepController : Controller
    {
        private readonly IObterEnderecoPorCepService _repository;
        private readonly IMapper _mapper;

        public ObterEnderecoViaCepController(IObterEnderecoPorCepService repository, IMapper mapper)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<EnderecoDTOSemId>> BuscaViaCep(string cep)
        {
            try
            {
                Endereco endereco = await _repository.ObterEnderecoPorCep(cep);

                if (endereco == null)
                {
                    return Content("Cep No Content");
                }
                
                return Ok(_mapper.Map<EnderecoDTOSemId>(endereco));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
