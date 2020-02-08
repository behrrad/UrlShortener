
using Microsoft.AspNetCore.Mvc;
using urlShortener.Models;
using System.Text.RegularExpressions;
using System;    
using urlShortener.Services;
namespace urlShortener.Controllers
{
    [ApiController]
    [Route("/urls")]    
    public class ShortenerController : ControllerBase{
        public ShortenerService shortener;
        public ShortenerController(ShortenerService shortener){
            this.shortener = shortener;
        }

        private bool ValidateUrl(string url){
            url = url.Trim();
            Regex pattern = new Regex(@"^(?:((http|ftp|https)://))?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$");
            Match match = pattern.Match(url);
            if (match.Success == false || (url.Contains("..") || url.Contains("--") || url.Contains("_"))) {   
                return false;
            }
            return true;
        }
        [HttpPost]
        public IActionResult shortner([FromBody]SingleUrl longUrl){
            if(!ValidateUrl(longUrl.url)){
                return BadRequest("in url validate nist");
            }
            return Ok(new {shortUrl = shortener.setShortUrl(longUrl)} );
        }
    }
    [Route("/{*subdomain}")]
    [ApiController]
    public class UrlRedirect : ControllerBase{
        public ShortenerService shortener;
        public UrlRedirect(ShortenerService shortener){
            this.shortener = shortener;
        }
        private bool beginWithScheme(string url){
            url = url.Trim();
            Regex pattern = new Regex(@"^(http|https|ftp)://");
            Match match = pattern.Match(url);
            if (match.Success == false) {
                return false;
            }
            return true;
        }
        [HttpGet]
        public ActionResult<string> get(string subdomain){
            string longUrl = shortener.searchForShortUrl(subdomain);
            if(!String.Equals(longUrl, null)){
                if(beginWithScheme(longUrl)){
                    return Redirect(longUrl);
                }
                return Redirect("https://" + longUrl);
            }
            return NotFound("This url does not exist");
        }
    }
}