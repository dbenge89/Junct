using IdentityServer4.EntityFramework.Options;
using Junct.WASM.Hosted.Server.Models;
using Junct.WASM.Hosted.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Junct.WASM.Hosted.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<CalendarDay> CalendarDays { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
