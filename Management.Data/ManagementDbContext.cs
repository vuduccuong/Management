using Management.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data
{
    public class ManagementDbContext: IdentityDbContext<ApplicationUser>
    {
        public ManagementDbContext() : base("Management")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }

        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }

        public DbSet<Tag> Tags { set; get; }

        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }

        public DbSet<Error> Errors { set; get; }

        //Database Do an
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<Route> Cars { set; get; }
        public DbSet<Driver> Drivers { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Router> Routers { set; get; }
        public DbSet<Seat> Seats { set; get; }
        public DbSet<SeatNo> SeatNos { set; get; }
        public DbSet<Ticket> Tickets { set; get; }


        //Phương thức tạo mới chính nó
        public static ManagementDbContext Create()
        {
            return new ManagementDbContext(); 
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);

        }

    }
}
