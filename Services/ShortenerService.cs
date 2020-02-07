using urlShortener.Models;
using System.Linq;
using System;    
using System.Text; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace urlShortener.Services
{
    static class Constants{
        public static int size = 8;
    }
    
    public class ShortenerService
    {
        public AppDbContext dbContext { get; set; }

        public ShortenerService (AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        private string RandomString()  
        {  
            StringBuilder builder = new StringBuilder();  
            Random random = new Random();  
            char ch;  
            int isLowerCase = 0;
            for (int i = 0; i < Constants.size; i++)  
            {  
                isLowerCase = Convert.ToInt32(Math.Floor(2 * random.NextDouble()));
                if(isLowerCase == 1){
                    isLowerCase = 32;
                }
                else{
                    isLowerCase = 0;
                }
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65 + isLowerCase)));  
                builder.Append(ch);  
            } 
            return builder.ToString();  
        } 

        public string setShortUrl(SingleUrl longUrl)
        {
            string shortUrl ;
            Task<bool> search;
            do{
                shortUrl = RandomString();
                search = dbContext.Urls.AnyAsync(p => p.shortUrl == shortUrl);
                search.Wait();
            }while(search.Result);


            Url newUrl = new Url(longUrl.url, shortUrl);

            dbContext.Urls.Add(newUrl); 
            dbContext.SaveChanges();   
            return shortUrl;
        }
        public string searchForShortUrl(string shortUrl){
            var search = dbContext.Urls.AnyAsync(p => p.shortUrl == shortUrl);
            search.Wait();
            if(!search.Result){
                return null;
            }
            var record = dbContext.Urls.Where(p => p.shortUrl == shortUrl).Single();
            string longUrl = record.longUrl;
            return longUrl; 
        }
    }
}