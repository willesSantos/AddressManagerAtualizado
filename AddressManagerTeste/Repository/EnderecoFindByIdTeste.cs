using AddressManager.Domain.Models;
using AddressManager.Domain.Models.Context;
using AddressManager.Infra.Data.Respositories;
using AddressManagerTeste.DataBaseInMemory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AddressManagerTeste.Repository
{
    public class EnderecoFindByIdTeste
    {
        [Fact]
        public async Task RetornarNullEnderecoInexistentee()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData.CreateCategories(application, true);

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
                AdressMockData.CreateCategories(application, true);

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
                AdressMockData.CreateCategories(application, true);

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