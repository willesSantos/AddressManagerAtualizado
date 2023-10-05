using AddressManager.Domain.Models.Context;
using AddressManager.Domain.Models;
using AddressManager.Infra.Data.Respositories;
using Microsoft.Extensions.DependencyInjection;
using AddressManagerTeste.DataBaseInMemory;
using Xunit;

namespace AddressManagerTeste.Repository
{
    public class EnderecoUpdateTeste
    {
        public Endereco endereco = new Endereco
        {
            id = 3,
            cep = "04960110",
            Logradouro = "Nova Rua barao",
            Complemento = "teste",
            Bairro = "Jardim Capela",
            Localidade = "teste",
            Uf = "SP",
            Ibge = "2",
            Gia = "2",
            Ddd = "11",
            Siafi = "2"
        };

        public Endereco enderecoExistente = new Endereco
        {
            id = 1,
            cep = "04960110",
            Logradouro = "Nova Rua barao",
            Complemento = "teste",
            Bairro = "Jardim Capela",
            Localidade = "teste",
            Uf = "SP",
            Ibge = "2",
            Gia = "2",
            Ddd = "11",
            Siafi = "2"
        };

        [Fact]
        public async Task RetornarEnderecoAtualizado()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.Update(enderecoExistente);

                    Assert.Equal(enderecoExistente, enderecos);
                }
            }
        }

        [Fact]
        public async Task RetornarExceptionEnderecoNaoEncontrado()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    Assert.ThrowsAsync<Exception>(() => repository.Update(endereco));
                }
            }
        }
    }
}
