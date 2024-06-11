using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BoozeClues.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace BoozeClues.Data
{
    public class BoozeCluesDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;

        public DbSet<UserProfile> UserProfiles { get; set; }

        public BoozeCluesDbContext(DbContextOptions<BoozeCluesDbContext> context, IConfiguration config) : base(context)
        {
            _configuration = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
            {
                new IdentityUser
                {
                    Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    UserName = "Administrator",
                    Email = "admina@strator.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                    UserName = "JohnDoe",
                    Email = "john@doe.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                    UserName = "JaneSmith",
                    Email = "jane@smith.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                    UserName = "AliceJohnson",
                    Email = "alice@johnson.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                    UserName = "BobWilliams",
                    Email = "bob@williams.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                    UserName = "EveDavis",
                    Email = "Eve@Davis.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
                },
            });

            modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
            {
                new UserProfile
                {
                    Id = 1,
                    IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    FirstName = "Admina",
                    LastName = "Strator",
                    CreateDateTime = new DateTime(2022, 1, 25),
                    
                },
                new UserProfile
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    CreateDateTime = new DateTime(2023, 2, 2),
                    IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                    
                },
                new UserProfile
                {
                    Id = 3,
                    FirstName = "Jane",
                    LastName = "Smith",
                    CreateDateTime = new DateTime(2022, 3, 15),
                    IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                    
                },
                new UserProfile
                {
                    Id = 4,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    CreateDateTime = new DateTime(2023, 6, 10),
                    IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                    
                },
                new UserProfile
                {
                    Id = 5,
                    FirstName = "Bob",
                    LastName = "Williams",
                    CreateDateTime = new DateTime(2023, 5, 15),
                    IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                    
                },
                new UserProfile
                {
                    Id = 6,
                    FirstName = "Eve",
                    LastName = "Davis",
                    CreateDateTime = new DateTime(2022, 10, 18),
                    IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                    
                }
            });

            // modelBuilder.Entity<Demotion>().HasData(
            //     new Demotion { Id = 1, AdminId = 1, UserProfileId = 2 }
            // );
            // modelBuilder.Entity<Demotion>()
            //     .HasOne(d => d.Admin)
            //     .WithMany(up => up.AdminDemotions)
            //     .HasForeignKey(d => d.AdminId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Demotion>()
            //     .HasOne(d => d.UserProfile)
            //     .WithMany(up => up.UserProfileDemotions)
            //     .HasForeignKey(d => d.UserProfileId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Comment>()
            //     .HasOne(c => c.Author)
            //     .WithMany(up => up.Comments)
            //     .HasForeignKey(c => c.AuthorId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Comment>()
            //     .HasOne(c => c.Post)
            //     .WithMany(p => p.Comments)
            //     .HasForeignKey(c => c.PostId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Post>()
            //     .HasOne(p => p.Author)
            //     .WithMany(up => up.Posts)
            //     .HasForeignKey(p => p.AuthorId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Post>()
            //     .HasOne(p => p.Category)
            //     .WithMany(c => c.Posts)
            //     .HasForeignKey(p => p.CategoryId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<PostTag>()
            //     .HasOne(pt => pt.Post)
            //     .WithMany(p => p.PostTags)
            //     .HasForeignKey(pt => pt.PostId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<PostTag>()
            //     .HasOne(pt => pt.Tag)
            //     .WithMany(t => t.PostTags)
            //     .HasForeignKey(pt => pt.TagId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<ReactionPost>()
            //     .HasOne(rp => rp.Post)
            //     .WithMany(p => p.ReactionPosts)
            //     .HasForeignKey(rp => rp.PostId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<ReactionPost>()
            //     .HasOne(rp => rp.Reaction)
            //     .WithMany(r => r.ReactionPosts)
            //     .HasForeignKey(rp => rp.ReactionId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<ReactionPost>()
            //     .HasOne(rp => rp.UserProfile)
            //     .WithMany(up => up.ReactionPosts)
            //     .HasForeignKey(rp => rp.UserProfileId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Subscription>()
            //     .HasOne(s => s.Subscriber)
            //     .WithMany(up => up.Subscriptions)
            //     .HasForeignKey(s => s.SubscriberId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Category>()
            //     .HasMany(c => c.Posts)
            //     .WithOne(p => p.Category)
            //     .OnDelete(DeleteBehavior.SetNull);

            // modelBuilder.Entity<Subscription>()
            //     .HasOne(s => s.Author)
            //     .WithMany(up => up.Subscriptions)
            //     .HasForeignKey(s => s.AuthorId)
            //     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


