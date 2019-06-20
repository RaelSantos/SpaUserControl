using SpaUserControl.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SpaUserControl.Infraestruture.Data.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            // Mapeando a propriedade Id
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Mapeando a propriedade Nome
            Property(x => x.Nome).HasMaxLength(60).IsRequired();

            // Mapeando a propriedade Email - O método HasColumnAnnotion configura a propriedade Email como unica, não poderemos ter Email duplicados na base. 
            Property(x => x.Email).HasMaxLength(160)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true}))
                .IsRequired();

            //Mapeando a propriedade Password
            Property(x => x.Password).HasMaxLength(32).IsFixedLength();

        }
    }
}
