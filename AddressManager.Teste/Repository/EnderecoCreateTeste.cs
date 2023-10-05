using AddressManager.Domain.Models;
using AddressManager.Domain.Models.Context;
using AddressManager.Infra.Data.Respositories;
using AddressManager.Teste.DataBaseInMemory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AddressManager.Teste.Repository
{
    public class EnderecoCreateTeste
    {
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

        public Endereco EnderecoNovo = new Endereco
        {
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
        public async Task RetornarExceptionEnderecoJaExistente()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData1.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    Assert.ThrowsAsync<Exception>(() => repository.Create(enderecoExistente));
                }
            }
        }

        [Fact]
        public async Task RetornarEnderecoCreateSucesso()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData1.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.Create(EnderecoNovo);

                    Assert.Equal(EnderecoNovo, enderecos);
                }
            }
        }
    }
}
