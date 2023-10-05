using AddressManager.Domain.Models;
using AddressManager.Domain.Models.Context;
using AddressManager.Infra.Data.Respositories;
using AddressManager.Teste.DataBaseInMemory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AddressManager.Teste.Repository
{
    public class EnderecoDeleteTeste
    {
        Endereco endereco = new Endereco
        {
            id = 3,
            cep = "04960110",
            Logradouro = "Rua barao",
            Complemento = "teste",
            Bairro = "Jardim Capela",
            Localidade = "teste",
            Uf = "SP",
            Ibge = "2",
            Gia = "2",
            Ddd = "11",
            Siafi = "2"
        };

        Endereco enderecoExistente = new Endereco
        {
            id = 1,
            cep = "04960110",
            Logradouro = "Rua barao",
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
        public async Task RetornarTrueEnderecoExiste()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData1.CreateEnderecos(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.Delete(enderecoExistente);

                    Assert.True(enderecos);
                }
            }
        }

        [Fact]
        public async Task RetornarExcecaoEnderecoInexistente()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData1.CreateEnderecos(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    Assert.ThrowsAsync<Exception>(() => repository.Delete(endereco));
                }
            }
        }
    }
}