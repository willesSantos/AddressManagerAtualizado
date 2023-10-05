using AddressManager.Domain.Models.Context;
using AddressManager.Domain.Models;
using AddressManager.Infra.Data.Respositories;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using AddressManager.Teste.DataBaseInMemory;

namespace AddressManager.Teste.Repository
{
    public class EnderecoFindByIdTeste
    {
        [Fact]
        public async Task RetornarNullEnderecoInexistentee()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData1.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.FindById(3);

                    Assert.Null(enderecos);
                }
            }
        }

        [Fact]
        public async Task RetornarTipoEndereco()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData1.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.FindById(2);

                    Assert.IsType<Endereco>(enderecos);
                }
            }
        }

        [Fact]
        public async Task RetornarFalseEnderecoExistente()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData1.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.FindById(2);

                    Assert.NotNull(enderecos);
                }
            }
        }
    }
}
