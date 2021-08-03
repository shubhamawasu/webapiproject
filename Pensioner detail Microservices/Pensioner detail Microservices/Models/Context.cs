using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pensioner_detail_Microservices.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<PensionerDetails> Pensioners { get; set; }


    }
}
