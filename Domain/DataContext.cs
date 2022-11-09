using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Domain
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Catalogo> Catalogo { get; set; }
    }
}