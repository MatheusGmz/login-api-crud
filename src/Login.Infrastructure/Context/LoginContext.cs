using Login.Domain.Entities;
using Login.Domain.ValueObjects;
using Login.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Login.Infrastructure.Context
{
    public class LoginContext : DbContext
    {
        private readonly ConfigurationKeys _configurationKeys;

        public LoginContext(ConfigurationKeys configurationKeys)
        {
            _configurationKeys = configurationKeys;
        }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_configurationKeys.DbConnection);
            base.OnConfiguring(optionBuilder);
        }
    }
}
