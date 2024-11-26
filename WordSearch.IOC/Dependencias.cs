using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.DAL.DBContext;
using WordSearch.DAL.Repositorios.Contrato;
using WordSearch.DAL.Repositorios;
using WordSearch.DLL.Servicios.Contrato;
using WordSearch.DLL.Servicios;

namespace WordSearch.IOC
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BdSopaLetrasContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            }); 
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<DbContext, BdSopaLetrasContext>();

            services.AddScoped<ICaracteresService, CaracteresService>();

        }
    }
}
