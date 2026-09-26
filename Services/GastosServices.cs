using System.Data.Common;

namespace GestorGastosPersonales;

public class GastosServices
{
    private readonly GastosRepository _data = new GastosRepository();
    public bool AgregarGasto(Gasto gasto)
    {
        if(
            gasto.Costo <= 0 ||
            string.IsNullOrWhiteSpace(gasto.Descripcion)
        )
        {
            return false;
        }

        var lista = _data.LeerJson();

        var ultimoId = lista.Any()
        ? lista.Max(gasto=> gasto.Id)
        : 0;
        

        var nuevoGasto = new Gasto
        {
            Id = ultimoId + 1,
            Costo = gasto.Costo,
            Categoria = gasto.Categoria,
            Descripcion = gasto.Descripcion,
            Fecha = DateTime.Today
        };

        lista.Add(nuevoGasto);
        _data.GuardarJson(lista);
            
        return true;
    }

    public void MostrarGastos()
    {
        var gastos = _data.LeerJson();
        foreach(var gasto in gastos)
        {
            Console.WriteLine($"{gasto.Id} - {gasto.Descripcion,-15}  -  {gasto.Costo,5}  -  {gasto.Categoria,-10}  -  {gasto.Fecha} ");
        }
    }

    public decimal GastoDiarioTotal()
    {
        var gastos = _data.LeerJson();

        return gastos
            .Where(g=> g.Fecha.Date == DateTime.Today)
            .Sum(t=> t.Costo);
    }

    public void MostrarCategoriaFiltro()
    {
        var gastos = _data.LeerJson();

        var grupos = gastos
        .Where(g=> g.Fecha.Date == DateTime.Today)
        .GroupBy(g=> g.Categoria)
        .Select(grupo=> new
        {
           Categoria = grupo.Key,
           Gastos = grupo.Select(g=> new
           {
               Descripcion = g.Descripcion,
               Costo = g.Costo
           }),
           Total = grupo.Sum(g=> g.Costo)
        })
        .ToList();

        foreach (var grupo in grupos)
        {
            Console.WriteLine($"\nCategoría: {grupo.Categoria}\n");
            Console.WriteLine($"{"Descricion", -20} {"Costo",10}");
            Console.WriteLine($"{"-----------------------", -20} {"------------", 10}");
            foreach(var gasto in grupo.Gastos)
            {
                Console.WriteLine($"{gasto.Descripcion, -20} {gasto.Costo, 10}");
            }

            Console.WriteLine($"\n{"Total: ", 27} {grupo.Total}");
        }
    }

    public bool EliminarGasto(int id)
    {
        var gastos = _data.LeerJson();
        var eliminar = gastos.FirstOrDefault(g=> g.Id == id);

        if(eliminar == null)
        {
            return false;
        }

        gastos.Remove(eliminar);
        _data.GuardarJson(gastos);
        return true;
    } 
}