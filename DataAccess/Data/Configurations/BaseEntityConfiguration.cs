namespace DataAccess.Data.Configurations
{
    internal class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedOn)
                   .HasDefaultValueSql("GETDATE()")
                   .ValueGeneratedOnAdd();
            builder.Property(d => d.LastModifiedOn)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
