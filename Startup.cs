using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using QulixTask.Repositories;
using QulixTask.RepositoryImp;
using QulixTask.ServiceImp;
using QulixTask.Services;
using QulixTask.Settings;
using QulixTask.Utils;

namespace QulixTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
            IMongoDatabase database = new MongoClient(settings.DbConnectionUrl).GetDatabase(settings.DatabaseName); 
            services.AddSingleton<IMongoDatabase>(database);

            IAuthorRepository authorRepository = new AuthorRepository(database);
            IPhotoRepository photoRepository = new PhotoRepository(database);
            ITextRepository textRepository = new TextRepository(database);
            IRatingRepository ratingRepository = new RatingRepository(database);

            services.AddSingleton<IAuthorRepository>(authorRepository);
            services.AddSingleton<IPhotoRepository>(photoRepository);
            services.AddSingleton<ITextRepository>(textRepository);
            services.AddSingleton<IRatingRepository>(ratingRepository);

            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<ITextService, TextService>();
            services.AddSingleton<IRatingService, RatingService>();
            services.AddSingleton<IPhotoService, PhotoService>();
            DatabaseInitializer databaseInitializer = new DatabaseInitializer(photoRepository, authorRepository, textRepository);
            databaseInitializer.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
