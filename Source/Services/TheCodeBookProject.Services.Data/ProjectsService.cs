﻿namespace TheCodeBookProject.Services.Data
{
    using System.Linq;

    using Contracts;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Data.Repositories.Contracts;

    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<Project> projects;

        public ProjectsService(IRepository<Project> projects)
        {
            this.projects = projects;
        }

        public IQueryable<Project> GetAll()
        {
            return this.projects.All();
        }

        public IQueryable<Project> GetByUserId(string userId)
        {
            return this.projects.All().Where(p => p.Developers.Any(d => d.Id == userId));
        }

        public int SaveChanges()
        {
            return this.projects.SaveChanges();
        }
    }
}