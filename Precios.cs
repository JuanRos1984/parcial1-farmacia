namespace Farmacia;

public static class Precios
{
    public const decimal MontoMinimoDescuento = 2500m;

    public const decimal Itbis = 0.18m;

    // Suma cantidad por precio unitario de cada línea.
    public static decimal Subtotal(IEnumerable<Linea> lineas) =>
        lineas.Sum(l => l.Cantidad * l.PrecioUnitario);

    public static decimal Impuesto(decimal subtotal) =>
        Math.Round(subtotal * Itbis, 2);

    public static decimal Descuento(decimal subtotal) =>
        subtotal >= MontoMinimoDescuento ? Math.Round(subtotal * 5m / 100m, 2) : 0m;

    public static decimal CargoEnvio(decimal subtotal) =>
        subtotal >= 2000m ? 0m : 100m;
}
