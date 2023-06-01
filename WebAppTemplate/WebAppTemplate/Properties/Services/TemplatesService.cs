using Microsoft.EntityFrameworkCore;
using WebAppTemplate.Properties.Data;
using WebAppTemplate.Properties.Models.DTOs;

namespace WebAppTemplate.Properties.Services; 

//Stwórz interfejs zawierający potrzebne metody
public interface ITemplatesService {
    Task<IEnumerable<ModelAGET>> GetTemplates();
    
}
//Stwórz serwis implementujący interfejs i korzystający z contextu bazy danych
public class TemplatesService : ITemplatesService {
    private readonly Context _context;
    
    public TemplatesService(Context context) {
        _context = context;
    }
    
    //Implementuj kolejne metody interfejsu
    public async Task<IEnumerable<ModelAGET>> GetTemplates() {
        var modelAs = await _context.ModelAs
            .Select(d => new ModelAGET() {
                Name = d.Name,
                Surname = d.Surname
            }).ToListAsync();
        return modelAs;
    }
    //itd...
}
