using AddressManager.Domain.Models;
using AddressManager.Domain.Models.Context;
using AddressManager.Infra.Data.Respositories;
using AddressManagerTeste.DataBaseInMemory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AddressManagerTeste.Repository
{
    public class EnderecoFindAllTeste
    {

        [Fact]
        public async Task RetornarTipoListaDeEnderecos()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.FindAll(0, 2);

                    Assert.IsType<List<Endereco>>(enderecos);
                }
            }
        }


        [Fact]
        public async Task RetornaListaDeEnderecosNaovazios()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.FindAll(0, 2);

                    Assert.NotNull(enderecos);
                }
            }
        }

        [Fact]
        public async Task RetornarVazioListaDeEnderecosPosicaoInexistente()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.FindAll(3, 2);

                    Assert.Empty(enderecos);
                }
            }
        }

        [Fact]
        public async Task retornarListaDeEndereco()
        {
            using (var application = new AddressInMomery())
            {
                AdressMockData.CreateCategories(application, true);

                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    var dbContext = provider.GetRequiredService<SqlContext>();
                    var repository = new EnderecoRepository(dbContext);

                    var enderecos = await repository.FindAll(0, 2);

                    Assert.Equal(enderecos.Count(), 2);
                }
            }
        }
    }
}