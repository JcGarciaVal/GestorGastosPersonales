namespace GestorGastosPersonales;
public class Gasto
{
    public int Id {get; set; } = 0;
    public decimal Costo { get; set; }   
    public Categoria Categoria { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
}