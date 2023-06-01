using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAppTemplate.Properties.Models;

namespace WebAppTemplate.Properties.Data;

public class Context : DbContext {

    //Dodaj wszystkie modele
    public DbSet<ModelA> ModelAs { get; set; }
    //...

    public Context(DbContextOptions options) : base(options) {

    }

    public Context() {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //Jeśli chcesz uporządkować w bazie możesz dodać DefaultSchema
        modelBuilder.HasDefaultSchema("SchemaName");

        //Dodawaj kolejne modele
        modelBuilder.Entity<ModelA>(entity => {
            entity.HasKey(d => d.ID); //klucz główny
            //Dodawaj kolejne pola
            entity.Property(d => d.ID)
                .ValueGeneratedNever(); //Wyłączenie auto-numeracji (może powodować problemy przy kolejnych migrajach)
            entity.Property(d => d.Name)
                .HasMaxLength(100).IsRequired(); //Dodaj wymagane ograniczenia
            entity.Property(d => d.Surname)
                .HasMaxLength(100).IsRequired();

            //Data seeding - dodawanie danych testowych
            entity.HasData(new List<ModelA> {
                new ModelA {
                    ID = 1,
                    Name = "Name",
                    Surname = "Surname"
                }
                //itd...
                
                //Tworzenie relacji
                //WYSTARCZY Z JEDNEJ STRONY RELACJI!!
                /*entity.HasOne<Medicament>(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionsMedicaments)
                .HasForeignKey(pm => pm.IdMedicament)
                .OnDelete(DeleteBehavior.Cascade);*/
                //Jeśli one-to-many: HasOne.WithMany jeśli na diagramie mamy końcówkę wiele; HasMany.WithOne jeśli mam końcówkę jeden
            });
        });
        
        //itd dla każdego modelu...
    }
}