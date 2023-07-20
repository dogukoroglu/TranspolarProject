using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-GPMKKC5N\\SQLEXPRESS;database=TranspolarDB;integrated security=true;TrustServerCertificate=True;");
		}

		public DbSet<About> Abouts { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<FeaturedService> FeaturedServices { get; set; }
		public DbSet<HomeFeature> HomeFeatures { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<Question> Questions{ get; set; }
		public DbSet<Question2> Questions2{ get; set; }
		public DbSet<Service> Services{ get; set; }
		public DbSet<ServiceAbout> ServicesAbouts{ get; set; }
		public DbSet<Staff> Staffs{ get; set; }
		public DbSet<SubAbout> SubAbouts{ get; set; }
		public DbSet<Testimonial> Testimonials{ get; set; }
		public DbSet<SocialMedia> SocialMedias{ get; set; }
		public DbSet<About2> About2s{ get; set; }
		public DbSet<ServiceRequest> ServiceRequests{ get; set; }
		public DbSet<SupportMessage> SupportMessages{ get; set; }
		public DbSet<Contact2> Contact2s{ get; set; }
		public DbSet<ContactMessage> ContactMessages{ get; set; }
	}
}
