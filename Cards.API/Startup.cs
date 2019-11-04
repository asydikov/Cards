
using System.Text;
using AutoMapper;
using Cards.API.Middleware;
using Cards.Core.Auth;
using Cards.Core.EF;
using Cards.Core.Mappers;
using Cards.Core.Repositories;
using Cards.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Cards.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("jwt").GetValue<string>("secretKey"))),
                    ValidIssuer = Configuration.GetSection("jwt").GetValue<string>("issuer"),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };

            });

            services.AddScoped<IJwtHandler, JwtHandler>();
            services.Configure<SqlSettings>(Configuration.GetSection("sql"));
            services.AddEntityFrameworkSqlServer().AddDbContext<CardContext>();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt =>
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUSerService, UserService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRepeatRateService, RepeatRateService>();
            services.AddScoped<IRepeatRateRepository, RepeatRateRepository>();
            services.AddScoped<IModeService, ModeService>();
            services.AddScoped<IModeRepository, ModeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();

            services.AddSingleton<IMapper>(_ => AutoMapperConfig.GetMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMiddleware<ErrorHandlerMiddleware>();

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
