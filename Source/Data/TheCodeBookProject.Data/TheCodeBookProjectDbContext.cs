﻿namespace TheCodeBookProject.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TheCodeBookProjectDbContext : IdentityDbContext<User>
    {
        private const string DbConnectionName = "DefaultConnection";

        public TheCodeBookProjectDbContext()
            : base(DbConnectionName, throwIfV1Schema: false)
        {
        }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public static TheCodeBookProjectDbContext Create()
        {
            return new TheCodeBookProjectDbContext();
        }
    }
}
