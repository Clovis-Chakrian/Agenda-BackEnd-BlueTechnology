using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var contact = modelBuilder.Entity<Contact>();
            contact.ToTable("contacts");
            contact.HasKey(attribute => attribute.Id);
            contact.Property(attribute => attribute.Id).HasColumnName("id").ValueGeneratedOnAdd();
            contact.Property(attribute => attribute.Name).HasColumnName("name").IsRequired();
            contact.Property(attribute => attribute.LastName).HasColumnName("last_name");
            contact.Property(attribute => attribute.Phone).HasColumnName("phone").IsRequired();
            contact.Property(attribute => attribute.Email).HasColumnName("email");
            contact.Property(attribute => attribute.CreatedAt).HasColumnName("created_at").IsRequired();
            contact.Property(attribute => attribute.LastUpdatedAt).HasColumnName("updated_at").IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}