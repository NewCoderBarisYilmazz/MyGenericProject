using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace New.Context.EntityModel
{
    public class Category : IEntityTypeConfiguration<Category>
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }



        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x=>x.Id).HasColumnName("CategoryId");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.CategoryName).HasMaxLength(15);

        }
    }
}
