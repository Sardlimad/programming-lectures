﻿namespace TuEnvio
{
    public interface IProduct
    {
        // Precio base del producto
        int Price { get; }

        // Descripción del producto
        string Description { get; }
    }

    public interface IPromotion<TProduct> where TProduct : IProduct
    {
        // Devuelve un porciento de descuento aplicable a un producto determinado
        // según la cantidad que haya en el carrito de compras.
        double Discount(TProduct product, int count);
    }

    public interface IFilter<T>
    {
        // Devuelve `true` si el elemento cumple con el filtro.
        bool Apply(T item);
    }

    public interface IShoppingCart<TProduct>
    {
        // Añadir un nuevo producto al carrito.
        void Add(TProduct product, int count);

        // Eliminar todos los elementos de un producto del carrito.
        bool Remove(TProduct product);

        // Devuelve la cantidad de elementos de un producto determinado.
        int Count(TProduct product);

        // Devuelve la cantidad total de elementos que cumplen con un filtro determinado.
        int Count(IFilter<TProduct> filter);

        // Cantidad total de elementos en el carrito.
        int Total { get; }

        // Adiciona una promoción que debe ser tenida en cuenta a partir de ahora para calcular el costo.
        // Devuelve `true` si la promoción aplica a algún producto existente.
        // Cada producto puede tener una sola promoción.
        void AddPromotion(IPromotion<TProduct> promotion);

        // Calcula el costo total de los productos en el carrito,
        // teniendo en cuenta todas las promociones.
        int Cost { get; }
    }
}
