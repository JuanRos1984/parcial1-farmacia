namespace Farmacia;

public static class Pruebas
{
    private static readonly List<Linea> Compra = new()
    {
        new("Acetaminofén 500 mg", 2, 185m),
        new("Alcohol 16 oz", 1, 120m),
    };

    public static int Ejecutar()
    {
        var casos = new List<(string Nombre, bool Paso)>
        {
            ("El subtotal suma cantidad por precio", Precios.Subtotal(Compra) == 490m),
            ("El ITBIS es el 18 % del subtotal", Precios.Impuesto(100m) == 18m),
            ("El resumen muestra el total", Reporte.Resumen(Compra).Contains("Total")),
            ("Descuento del 5 % en compras grandes", Precios.Descuento(20000m) == 1000m),
            ("Sin descuento en compras pequeñas", Precios.Descuento(100m) == 0m),
            ("Sin descuento justo debajo del mínimo", Precios.Descuento(2499m) == 0m),
            ("Descuento desde el mínimo de 2500", Precios.Descuento(2500m) == 125m),
            ("Envío de 100 por debajo de 2000", Precios.CargoEnvio(100m) == 100m),
            ("Envío gratis desde 2000", Precios.CargoEnvio(2000m) == 0m),
            ("El resumen con envío muestra el envío", Reporte.ResumenConEnvio(Compra).Contains("Envío")),
            ("Rechaza cantidad cero", RechazaCantidad(0)),
            ("Rechaza cantidad negativa", RechazaCantidad(-1)),
        };

        int fallas = 0;
        foreach (var (nombre, paso) in casos)
        {
            Console.WriteLine($"{(paso ? "OK   " : "FALLA")} {nombre}");
            if (!paso) fallas++;
        }
        Console.WriteLine(fallas == 0 ? "Todas las pruebas pasan." : $"{fallas} prueba(s) fallan.");
        return fallas == 0 ? 0 : 1;
    }

    private static bool RechazaCantidad(int cantidad)
    {
        try
        {
            _ = new Linea("Prueba", cantidad, 1m);
            return false;
        }
        catch (ArgumentException)
        {
            return true;
        }
    }
}
