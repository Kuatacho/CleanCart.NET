using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product(string name, decimal price, int stockLevel, string imageUrl) : IEntityId<Guid>
    {
        //implementacion de la interfaz IEntityId<Guid>, el id se va generar automaticamente al crear una nueva instancia de Product
        public Guid Id { get; private set; } = Guid.NewGuid();

        //Propiedades estables inmutables tras la creación del objeto
        public string Name { get;} = name;
        public decimal Price { get; } = price;
        public string ImageUrl { get; } = imageUrl;

        //Propiedad cuya modificacion requiere validacion de negocio
        public int StockLevel { get; private set; } = stockLevel;

        // Regla negocio, el nivle de stock jamas puede ir negativo

        public void UpdateStockLevel(int stockLevel)
        {
            if (stockLevel < 0)
            {
                throw new ArgumentException("Stock level cannot be negative.");
            }
            StockLevel = stockLevel;
        }
         


    }
}
