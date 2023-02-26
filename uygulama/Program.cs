using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using uygulama.Context;
using uygulama.JwtAyar;

namespace uygulama
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


          
            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();

         

            var app = builder.Build();

        
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
    }
