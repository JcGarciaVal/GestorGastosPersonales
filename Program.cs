using GestorGastosPersonales;

GastosServices _services = new GastosServices();
bool sistema = true;
Console.WriteLine("¡Bienvenido a tu CLI de Gastos!");
{
    while (sistema)
{
    Console.WriteLine("¿Que desea hacer?");
    Console.WriteLine("1. Agregar gasto.");
    Console.WriteLine("2. Mostras gastos.");
    Console.WriteLine("3. Mostrar gastos diarios.");
    Console.WriteLine("4. Ver categorias diarias.");
    Console.WriteLine("5. Eliminar Gasto");
    Console.WriteLine("6. Salir");
    Console.Write("Que desea seleccionar: ");
    if(!int.TryParse(Console.ReadLine(), out int seleccion) 
    || seleccion > 6 
    || seleccion < 1)
    {
        Console.WriteLine("\nNumero no valido\n");
        continue;
    }

    switch (seleccion)
    {
        case 1:
            Console.WriteLine("\n---- Agregar costo: ----");
            decimal costoDecimal;
            Console.Write("\t Monto: ");
            while(!decimal.TryParse(Console.ReadLine(), out costoDecimal) || costoDecimal <= 0)
                {
                    Console.Write("\t [!] Ingrese un monto decimal válido mayor a 0: ");
                }
                
            Console.WriteLine("\t Seleccione categoria");
            Console.WriteLine("\t\t 1. Gasto Fijo");
            Console.WriteLine("\t\t 2. Gasto Variable");
            Console.WriteLine("\t\t 3. Gasto Emergencia");
            Console.WriteLine("\t\t 4. Gasto Hormiga");
            Console.Write("Seleccione categoria: ");

            int selectCategoria;
            while(!int.TryParse(Console.ReadLine(), out selectCategoria)
            || selectCategoria > 4 || selectCategoria < 1)
            {
                Console.WriteLine("\t Categoria no valida.");
                Console.Write("Seleccione categoria: ");
            }
            Categoria categoria = selectCategoria switch
            {
                1 => Categoria.Fijos,
                2 => Categoria.Variables,
                3 => Categoria.Emergencia,
                4 => Categoria.Hormiga,
                _ => Categoria.Hormiga
            };
            
            string? descripcion;
            Console.Write("\tDescripcion: ");
            descripcion = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(descripcion))
            {
                Console.Write("\t [!] Ingrese una nueva descripcion: ");
                descripcion = Console.ReadLine();
            }


            var gastoIngresar = new Gasto
            {
                Costo = costoDecimal,
                Categoria = categoria,
                Descripcion = descripcion,
            };

                if (_services.AgregarGasto(gastoIngresar))
                {
                    Console.WriteLine("\n -----------Gasto Ingresado---------\n");
                }
                else
                {
                    Console.WriteLine("\n -----------Gasto No ingresado---------\n");
                }
                
            
        break;

        case 2:
            Console.WriteLine("\n---------- Gastos diarios-------------");
            _services.MostrarGastos();
            Console.WriteLine("-----------------------------------\n");
        break;

        case 3:
            decimal total = _services.GastoDiarioTotal();
            Console.WriteLine($"\n Gasto total diario: {total} \n");
        break;

        case 4:
            Console.WriteLine("\n---------Categorias-------------");
            _services.MostrarCategoriaFiltro();
            Console.WriteLine("\n-------------------------------\n");
        break;

        case 5:
            int idSeleccionado; 
            Console.WriteLine("\n--------------Lista----------------------\n");
            _services.MostrarGastos();
            Console.WriteLine("\n-----------------------------------------\n");
            Console.Write("Selecione un id: ");
            while (!int.TryParse(Console.ReadLine(), out idSeleccionado) 
                || idSeleccionado <= 0)
                {
                    Console.WriteLine("\t Id invalida.");
                    Console.Write("Seleccione nuevo Id: ");
                }
                if (_services.EliminarGasto(idSeleccionado))
                {
                    Console.WriteLine("¡Gasto eliminado!\n");
                }
                else
                {
                    Console.WriteLine("Gasto no eliminado\n");
                }
        break;

        case 6:
            sistema = false;
            Console.WriteLine("\n\t \t ¡Hasta pronto!");
        break;
    }
    }
}
