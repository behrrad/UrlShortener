using urlShortener.Models;
using System.Linq;
using System;    
using System.Text; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace urlShortener.Services
{
    public class ShortenerService
    {
        public AppDbContext dbContext { get; set; }

        public ShortenerService (AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }
    }
}