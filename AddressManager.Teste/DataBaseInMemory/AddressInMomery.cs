using AddressManager.Domain.Models.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace AddressManager.Teste.DataBaseInMemory
{
    public class AddressInMomery : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            try
            {
                var root = new InMemoryDatabaseRoot();

                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<SqlContext>));

                    services.AddDbContext<SqlContext>(options =>
                        options.UseInMemoryDatabase("DefaultConnection", root));
                });

                return base.CreateHost(builder);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
