using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppCalc.Models;
using System.Data.Entity;

namespace WebAppCalc
{
    public class Library : DbContext
    {
        // Your context has been configured to use a 'Library' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.Library' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Library' 
        // connection string in the application configuration file.
        public Library()
            : base("name=Library")
        {
            Database.SetInitializer<Library>(new CustomInitializer<Library>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        
        public virtual DbSet<DBUser> DBUsers { get; set; }
        public virtual DbSet<Expression> Expressions { get; set; }
        public virtual DbSet<ExchangeRates> Rates { get; set; }
    }
}