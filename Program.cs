using GraphQlStorage.Abstraction;
using GraphQlStorage.Mapper;
using GraphQlStorage.Query;
using GraphQlStorage.Services;

namespace GraphQlStorage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient<StorageService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7040");
            });
            builder.Services.AddAutoMapper(typeof(MapperStore));
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<SimpleQuery>();

            builder.Services.AddHttpClient<IStorageServices, StorageService>();
            builder.Services.AddMemoryCache();
            var app = builder.Build();


            app.MapGraphQL();
            app.Run();
        }
    }
}
