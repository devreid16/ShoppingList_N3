﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingList.Data
{
    // You can add profile data for the user by adding more properties to your ShoppingListUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ShoppingListUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ShoppingListUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ShoppingListDbContext : IdentityDbContext<ShoppingListUser>
    {
        public ShoppingListDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ShoppingListDbContext Create()
        {
            return new ShoppingListDbContext();
        }

        public DbSet<ShoppingListEntity> ShoppingList { get; set; }




    }
}