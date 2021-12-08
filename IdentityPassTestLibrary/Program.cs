using IdentityPassTestLibrary.V1.API.Implementations;
using IdentityPassTestLibrary.V1.API.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddScoped<IBvnVerficationTypes, BvnVerficationTypes>()
                .BuildServiceProvider();


            var verify = serviceProvider.GetService<IBvnVerficationTypes>();
            Console.WriteLine(verify.VerfifyBvnInfoLevel1("54651333604", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false));

           
        }
    }
}
