using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;

namespace HMS_WebApi_v1._0
{
    public class Startup 
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
           // services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
        }
    
    }

}