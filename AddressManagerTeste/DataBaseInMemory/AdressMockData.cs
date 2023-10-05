using AddressManager.Domain.Models;
using AddressManager.Domain.Models.Context;
using Microsoft.Extensions.DependencyInjection;

namespace AddressManagerTeste.DataBaseInMemory
{
    public class AdressMockData
    {
        public static async Task CreateCategories(AddressInMomery application, bool criar)
        {
            try
            {
                using (var scope = application.Services.CreateScope())
                {
                    var provider = scope.ServiceProvider;
                    using (var addessDbContext = provider.GetRequiredService<SqlContext>())
                    {
                        await addessDbContext.Database.EnsureCreatedAsync();

                        if (criar)
                        {
                            await addessDbContext.endereco.AddAsync(new Endereco
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
                            });

                            await addessDbContext.endereco.AddAsync(new Endereco
                            {
                                id = 2,
                                cep = "08570670",
                                Logradouro = "Rua Vereador",
                                Complemento = "teste",
                                Bairro = "Jardim Santa Helena",
                                Localidade = "teste",
                                Uf = "SP",
                                Ibge = "2",
                                Gia = "2",
                                Ddd = "11",
                                Siafi = "2"
                            });
                            await addessDbContext.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
