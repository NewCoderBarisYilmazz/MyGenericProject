using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericProject.ApiRepository
{
    public static class ApiRepo
    {
          static string url = "https://localhost:7287/api/";
        public static async Task<string> GetAllAsync (string methodName,string controller,string? token)
        {
            using (HttpClient client=new())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }
                var res=await client.GetAsync(url+controller+"/"+methodName);
                return await res.Content.ReadAsStringAsync();
            }

        }

        public static async Task<string> GetTokenAsync<T>(string methodName, string controller, T model) where T : class, new()
        {
            using (HttpClient client = new())
            {
                var jsonModel = JsonConvert.SerializeObject(model);
                StringContent stringContent = new(jsonModel, Encoding.UTF8, "application/json");
                var uri = url + controller + "/"+methodName;
                var res = await client.PostAsync(uri,stringContent);
                return await res.Content.ReadAsStringAsync();
            }

        }



        public static  async Task<bool> AddAsync<T>(string methodName,string controller,T model,string? token) where T : class,new()
        {
            using (HttpClient client=new())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }
                var jsonModel=JsonConvert.SerializeObject(model);
                StringContent stringContent=new(jsonModel,Encoding.UTF8,"application/json");
                  var res=await client.PostAsync(url+controller+"/"+methodName,stringContent);
                if (res.IsSuccessStatusCode)
                    return true;
                return false;
                
            }
        
        
        }


    }
}
