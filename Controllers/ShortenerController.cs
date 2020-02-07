using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using urlShortener.Models;
using System.Text.RegularExpressions;
using System;    
using System.Text; 
namespace urlShortener.Controllers
{
    [ApiController]
    [Route("/urls")]    
    public class ShortenerController : ControllerBase{
    }
}