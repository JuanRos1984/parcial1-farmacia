# Facturación de la farmacia

Sistema de facturación de una farmacia de barrio. Calcula subtotal, ITBIS, descuentos y
cargo de envío de una compra.

## Ejecutar las pruebas

```
dotnet build
dotnet run -- pruebas
```

Las pruebas imprimen `OK` o `FALLA` por caso y terminan con «Todas las pruebas pasan.»
cuando no falla ninguna.

## Ramas en curso

- `feature/descuento-seguro-medico`: descuento por compra grande.
- `feature/envio-a-domicilio`: cargo de envío.
- `hotfix/cantidades-invalidas`: arreglo urgente para rechazar líneas con cantidad cero o negativa. Tiene
  mezclados experimentos de la impresora de tickets.

Las tres están terminadas, pero ninguna se ha integrado a `main`.

## Decisiones del dueño

Estas reglas mandan sobre cualquier valor que aparezca en el código o en una rama:

- **El monto mínimo para aplicar descuento es RD$ 2,500.**
- El descuento por compra grande es del 5 %.
- El envío cuesta RD$ 100 y es gratis desde RD$ 2,000.
- El arreglo urgente de cantidades inválidas va a `main`. Los experimentos de la impresora
  (carpeta `experimentos/`) no van a `main`.
