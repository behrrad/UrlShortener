namespace urlShortener.Models
{
    public class Url
    {
        public string longUrl { get; set; }
        public string shortUrl { get; set; }
        public Url(string longUrl, string shortUrl){
            this.longUrl = longUrl;
            this.shortUrl = shortUrl;
        }
    }
}