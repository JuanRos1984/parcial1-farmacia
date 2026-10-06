namespace Farmacia;

public static class Precios
{
    public const decimal MontoMinimoDescuento = 2500m;
    public const decimal PorcentajeDescuento = 5m;
    public const decimal CostoEnvio = 100m;
    public const decimal EnvioGratisDesde = 2000m;
    public const decimal Itbis = 0.18m;

    // Suma cantidad por precio unitario de cada línea.
    public static decimal Subtotal(IEnumerable<Linea> lineas) =>
        lineas.Sum(l => l.Cantidad * l.PrecioUnitario);

    public static decimal Impuesto(decimal subtotal) =>
        Math.Round(subtotal * Itbis, 2);

    public static decimal Descuento(decimal subtotal) =>
        subtotal >= MontoMinimoDescuento ? Math.Round(subtotal * PorcentajeDescuento / 100m, 2) : 0m;

    public static decimal CargoEnvio(decimal subtotal) =>
        subtotal >= EnvioGratisDesde ? 0m : CostoEnvio;
}