using System.Data.Entity;

namespace WordProcessor.Models
{
    public partial class WProcessorDBContext : DbContext
    {
        public WProcessorDBContext()
            : base("name=WordProcessorDB")
        {
        }

        public virtual DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.Input)
                .IsUnicode(false);
        }
    }
}
