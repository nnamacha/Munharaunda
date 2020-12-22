using Microsoft.EntityFrameworkCore;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Munharaunda.Infrastucture.Database
{
    public class MunharaundaDbContext: DbContext
    {
        public MunharaundaDbContext(DbContextOptions<MunharaundaDbContext> options) : base(options)
        {

        }

        public DbSet<Funeral> Funeral { get; set; }
        public DbSet<IdentityTypes> IdentityTypes { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileTypes> ProfileTypes { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<StatusesHistory> StatusesHistory { get; set; }
        public DbSet<TransactionCodes> TransactionCodes { get; set; }
        public DbSet<TransactionCodesHistory> TransactionCodesHistory { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionsArchive> TransactionsArchive { get; set; }

    }
}


