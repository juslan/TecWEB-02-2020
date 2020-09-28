using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;

namespace VideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        [HttpGet]
        public CompanyModel[] GetCompanies()
        {
            return new CompanyModel[] 
            {
                new CompanyModel(){Id=1,Name="FromSoftware",Country="japan",FundationDate = new DateTime(1993,12,12),CEO="Mizayaki"},
                new CompanyModel(){Id=2,Name="Blizzard",Country="US",FundationDate = new DateTime(1993,12,12),CEO="none"}
            };
        }
        public CompanyModel GetCompany()
    }
}
