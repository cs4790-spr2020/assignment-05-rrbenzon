using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStore.Entities
{
    public class BlabMap
    {
        public BlabMap(EntityTypeBuilder<Blab> entityBuilder)
        {
            //entityBuilder.HasKey(t => t.UserID);
            entityBuilder.Property(t => t.DTTM).IsRequired();
            entityBuilder.Property(t => t.Message);
        }
    }
}