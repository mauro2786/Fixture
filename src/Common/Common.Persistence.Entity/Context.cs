using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence.Entity
{
    public class Context : DbContext
    {

        public Context(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<Context>(null);
            //  this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = true;
            //this.Configuration.LazyLoadingEnabled = true;
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var entityConfigurationPost = modelBuilder.Entity<Post>();
            //entityConfigurationPost.HasKey(i => i.Id);
            //entityConfigurationPost.Property(i => i.Title).HasMaxLength(100).IsRequired();
            //entityConfigurationPost.Property(i => i.Body).IsRequired();
            //entityConfigurationPost.Property(i => i.CreatedDate);
            //entityConfigurationPost.Property(i => i.Published);
            //entityConfigurationPost.Property(i => i.Deleted);
            ////entityConfigurationPost.HasRequired(i => i.Author);
            //entityConfigurationPost.Property(i => i.UserId);
            //entityConfigurationPost.HasRequired(i => i.User);
            //entityConfigurationPost.HasMany(i => i.Categories)
            //    .WithMany(i => i.Posts)
            //    .Map(x =>
            //    {
            //        x.ToTable("PostCategories");
            //        x.MapLeftKey("Post_Id");
            //        x.MapRightKey("Category_Id");
            //    });

            //var entityConfigurationComment = modelBuilder.Entity<Comment>();
            //entityConfigurationComment.HasKey(i => i.Id);
            //entityConfigurationComment.Property(i => i.Content).HasMaxLength(250).IsRequired();
            //entityConfigurationComment.Property(i => i.CreatedDate).IsRequired();
            //entityConfigurationComment.Property(i => i.PostId);
            //entityConfigurationComment.Property(i => i.UserId);
            //entityConfigurationComment.HasRequired(i => i.User);


            //var entityConfigurationCategory = modelBuilder.Entity<Category>();
            //entityConfigurationCategory.HasKey(i => i.Id);
            //entityConfigurationCategory.Property(i => i.Name).HasMaxLength(100).IsRequired();
            //entityConfigurationCategory.Property(i => i.Deleted);
            //entityConfigurationCategory.Ignore(i => i.IsSelected);
            //entityConfigurationCategory.HasMany(i => i.Posts);

            //var entityConfigurationUser = modelBuilder.Entity<UserProfile>();
            //entityConfigurationUser.HasKey(i => i.UserId);
            //entityConfigurationUser.Property(i => i.UserName).HasMaxLength(25);
            //entityConfigurationUser.Property(i => i.FirstName);
            //entityConfigurationUser.Property(i => i.LastName);
            //entityConfigurationUser.Property(i => i.Email);
            //entityConfigurationUser.Property(i => i.Subscribed);
        }
    }
}
