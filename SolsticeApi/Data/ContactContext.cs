using Microsoft.EntityFrameworkCore;
using SolsticeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }

}
