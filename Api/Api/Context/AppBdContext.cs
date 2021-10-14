using Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Context
{
    public class AppBdContext : DbContext
    {

        public AppBdContext(DbContextOptions<AppBdContext> options): base (options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

    }
}
