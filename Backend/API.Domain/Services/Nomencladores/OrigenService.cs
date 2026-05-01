using API.Data.Entidades.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Exceptions;
using API.Domain.Interfaces.Nomencladores;
using API.Domain.Validators.Nomencladores;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Web.Helpers;

namespace API.Domain.Services.Nomencladores
{
    public class OrigenService : BasicService<Origen, OrigenValidator>, IOrigenService
    {

        public OrigenService(IUnitOfWork<Origen> repositorios, IHttpContextAccessor httpContext) : base(repositorios, httpContext)
        {
        }

       
    }
}