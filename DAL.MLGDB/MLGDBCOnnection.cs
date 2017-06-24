using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.MLGDB
{
    public class MLGDBCOnnection
    {
    }
    public class MLGDBContext:DbContext
    {
        public MLGDBContext():base("name=MLGDBConnectionString")
        { }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
    public class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }
        public int BlogId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string URL { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        [Column(TypeName ="ntext")]
        public string Content { get; set; }
        public virtual Blog Blog { get; set; }

    }
}
