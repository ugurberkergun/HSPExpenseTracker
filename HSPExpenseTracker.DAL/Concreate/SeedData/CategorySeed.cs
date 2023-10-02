using HSPExpenseTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.DAL.Concreate.SeedData
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 2, IsDeleted = false, ModifiedDate = DateTime.UtcNow, Name = "Sağlık Harcaması", RecordDate = DateTime.UtcNow },
                new Category { Id = 3, IsDeleted = false, ModifiedDate = DateTime.UtcNow, Name = "Okul Masrafları", RecordDate = DateTime.UtcNow },
                new Category { Id = 4, IsDeleted = false, ModifiedDate = DateTime.UtcNow, Name = "Eğlence", RecordDate = DateTime.UtcNow }
                );
        }
    }
}
