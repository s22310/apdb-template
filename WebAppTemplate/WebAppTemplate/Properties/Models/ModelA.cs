namespace WebAppTemplate.Properties.Models; 

public class ModelA {
    //Główne pola
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    
    //Relacje

    //public virtual ModelB ModelB { get; set; } = null!;
    public virtual ICollection<ModelB> ModelBs { get; set; } = new List<ModelB>();
}