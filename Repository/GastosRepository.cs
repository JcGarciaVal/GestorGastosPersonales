using System.Text.Json;

namespace GestorGastosPersonales;

public class GastosRepository
{
    private readonly string _ruta = Path.Combine(Directory.GetCurrentDirectory(), "Data", "gastos.json");
    public GastosRepository()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_ruta)!);
    }
    public List<Gasto> LeerJson()
    {
        if (!File.Exists(_ruta))
        {
            return new List<Gasto>();
        } 

        string json = File.ReadAllText(_ruta);
        
        return JsonSerializer.Deserialize<List<Gasto>>(json) ??
        new List<Gasto>();     
    }
    public void GuardarJson(List<Gasto> gastos)
    {
        var json = JsonSerializer.Serialize(gastos, new JsonSerializerOptions
        {
         WriteIndented = true   
        });

        File.WriteAllText(_ruta, json);
    }
}