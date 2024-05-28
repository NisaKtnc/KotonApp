using Koton.DAL.Abstract;
using Koton.DAL.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.DAL.Extensions
{
    public static class DataLayerExtensions
    {
        //Veri erişim katmanını genişletmek için kullandığım bir uzantı.
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
