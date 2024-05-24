using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieWizardAPI.Data;
using MovieWizardAPI.Services;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using System.Collections.Generic;
using System.Linq;


namespace MovieWizardAPI.ServiceImpl
{
    public class GetImplementation : IDirectors
    {


        public List<Directors> getDirector(DirectorsDbContext DContext)
        {
            return DContext.Directors.ToList();

        }


    }
}