using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppCalc.Models;
using System.Data.Entity;

namespace WebAppCalc
{
    public class CustomInitializer<T> : DropCreateDatabaseAlways<Library>
    {
        protected override void Seed(Library context)
        {
            context.DBUsers.Add(
                new DBUser
                {
                    FullName = "full name",
                    Password="qwerty",
                    UserName="admin",
                    Email="x@x.ua"
                });            

            context.SaveChanges();
        }
    }
}