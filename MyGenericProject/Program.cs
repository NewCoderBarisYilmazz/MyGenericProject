using MyGenericProject.ApiRepository;

namespace MyGenericProject
{
    internal class Program
    {
        static  void Main(string[] args)
        {

            Task.Delay(2000).Wait();
           string res = "";
            while (string.IsNullOrEmpty(res))
            {
                 res = ApiRepo.GetTokenAsync("giris", "Kullanici", new TokenModel { UserName = "MyProject", Password = "Deneme123" }).Result;
                Console.WriteLine(res);
            }
            if (!string.IsNullOrEmpty(res))
            {
                Console.WriteLine(ApiRepo.GetAllAsync("getall", "category", res).Result  );
            }
          var sonuc=  ApiRepo.AddAsync("addcategory", "Category", new AddModel
            {
                CategoryName = "Category1",
                Descrption = "ApiDeneme"
            },res).Result;
            Console.ReadLine();
        }
    }


   

}