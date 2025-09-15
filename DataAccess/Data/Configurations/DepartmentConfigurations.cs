namespace DataAccess.Data.Configurations
{
    internal class DepartmentConfigurations : BaseEntityConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("varchar(50)");
            builder.Property(D => D.Code).HasColumnType("varchar(10)");

            builder.HasMany(D => D.Employees)
                .WithOne(D => D.Department)
                .HasForeignKey(E => E.DepartmentId)
                .OnDelete(deleteBehavior: DeleteBehavior.SetNull);

            base.Configure(builder);
        }
    }
}
