using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Northwind.AggregatesModel.ProductAggregate
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReoderLevel { get; set; }
        public bool Discontinued { get; set; }

        public void Create( string ProductName, 
                           int SupplierID, int CategoryID, 
                           string QuantityPerUnit, double UnitPrice, 
                           int UnitsInStock, int UnitsOnOrder, 
                           int ReoderLevel)
        {
            this.ProductName = ProductName;
            this.SupplierID = SupplierID;
            this.CategoryID = CategoryID;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitPrice = UnitPrice;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReoderLevel = ReoderLevel;
        }

        public void Update(int ProductID,string ProductName,
                           int SupplierID, int CategoryID,
                           string QuantityPerUnit, double UnitPrice,
                           int UnitsInStock, int UnitsOnOrder,
                           int ReoderLevel, bool Discontinued)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.SupplierID = SupplierID;
            this.CategoryID = CategoryID;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitPrice = UnitPrice;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReoderLevel = ReoderLevel;
            this.Discontinued = Discontinued;
        }

        public void Delete(int ProductID)
        {
            this.ProductID = ProductID;
        }
    }
}
