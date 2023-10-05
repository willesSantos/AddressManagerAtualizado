using AddressManager.Domain.Models;
using AddressManager.Infra.Data.Respositories;
using Xunit;

namespace AddressManagerTeste.Repository
{
    public class EnderecoBuscaViaCepTeste
    {
        [Fact]
        public async Task RetornarNuloQuandoNãoExistirCep()
        {
            var repository = new ObterEnderecoPorCepRepository();

            var endereco = await repository.ObterEnderecoPorCep("1111");

            Assert.Null(endereco);
        }

        [Fact]
        public async Task RetornarEnderecoComCepExistente()
        {
            var repository = new ObterEnderecoPorCepRepository();

            var endereco = await repository.ObterEnderecoPorCep("04960110");

            Assert.NotNull(endereco);
        }

        [Fact]
        public async Task RetornarTipoEndereco()
        {
            var repository = new ObterEnderecoPorCepRepository();

            var endereco = await repository.ObterEnderecoPorCep("04960110");

            Assert.IsType<Endereco>(endereco);
        }
    }
}