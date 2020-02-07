using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using urlShortener.Models;
using System.Text.RegularExpressions;
using System;    
using System.Text; 
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
            Regex pattern = new Regex(@"^(?:((http(s)|ftp)://))?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$");
            Match match = pattern.Match(url);
            if (match.Success == false) {
                return false;
            }
            return true;
        }
        [HttpPost]
        public ActionResult<string> shortner([FromBody]SingleUrl longUrl){
            if(!ValidateUrl(longUrl.url)){
                return BadRequest("in url validate nist");
            }
            
            return Ok(shortener.setShortUrl(longUrl));
        }
    }
}