using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Core.IRepository;
using StudentManagement.Core.IService;
using StudentManagement.Repository;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Utility
{
    public  class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services
            services.AddScoped<IStudentServices, StudentServices>();
            #endregion

            #region Repository
            services.AddScoped<IStudentRepository, StudentRepository>();
            #endregion
        }
    }
}
