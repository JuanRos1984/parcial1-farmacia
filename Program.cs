using System.Globalization;
using Farmacia;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

if (args.Contains("pruebas"))
    return Pruebas.Ejecutar();

var compra = new List<Linea> { new("Acetaminofén 500 mg", 2, 185m), new("Alcohol 16 oz", 1, 120m) };
Console.WriteLine(Reporte.Resumen(compra));
return 0;
