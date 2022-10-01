using System;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
         
    }
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Location> Locations {get;set;}
       public DbSet<Participant> Participants{get;set;}
}
