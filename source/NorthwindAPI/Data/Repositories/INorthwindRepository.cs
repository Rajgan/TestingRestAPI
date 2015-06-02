namespace NorthwindAPI.Data.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using NorthwindAPI.Data.Entities;

    public interface INorthwindRepository
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(String customerID);
        void CreateCustomer(Customer newCustomer);
        void UpdateCustomer(Customer customerToUpdate);

        IQueryable<Order> GetOrders(String customerID);
        Order GetOrder(String customerID, int orderID);

        IQueryable<Supplier> GetSuppliers();
        Supplier GetSupplier(int supplierID);
        Supplier CreateSupplier(Supplier newSupplier);
        void UpdateSupplier(Supplier supplierToUpdate);

        IQueryable<Shipper> GetShippers();
        Shipper GetShipper(int shipperID);
        Shipper CreateShipper(Shipper entity);
        void UpdateShipper(Shipper entity);

        IQueryable<Product> GetProducts();
        Product GetProduct(int productID);
        Product CreateProduct(Product newProduct);
        void UpdateProduct(Product productToUpdate);
    }
}
