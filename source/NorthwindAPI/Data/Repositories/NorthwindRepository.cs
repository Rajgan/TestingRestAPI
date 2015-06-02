namespace NorthwindAPI.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using NorthwindAPI.Data.Entities;

    public class NorthwindRepository : INorthwindRepository
    {
        NorthwindDbContext _dbContext;

        #region constructor
        public NorthwindRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region INorthwindRepository implementation

        #region customer entity actions
        public IQueryable<Customer> GetCustomers()
        {
            return _dbContext.Customers;
        }

        public Customer GetCustomer(String customerID)
        {
            return _dbContext.Customers
                .Where(c => c.CustomerID == customerID)
                .FirstOrDefault();
        }

        public void CreateCustomer(Customer newCustomer)
        {
            _dbContext.Customers.Add(newCustomer);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customerToUpdate)
        {
            _dbContext.Customers.Attach(customerToUpdate);
            _dbContext.Entry<Customer>(customerToUpdate).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        #endregion

        #region order entity actions
        public IQueryable<Order> GetOrders(String customerID)
        {
            return _dbContext.Orders
                .Where(o => o.CustomerID == customerID);
        }
        public Order GetOrder(String customerID, int orderID)
        {
            return _dbContext.Orders
                .Where(o => o.CustomerID == customerID && o.OrderID == orderID)
                .FirstOrDefault();
        }
        #endregion

        #region product entity actions
        public IQueryable<Product> GetProducts()
        {
            return _dbContext.Products;
        }
        public Product GetProduct(int productID)
        {
            return _dbContext.Products
                .Where(p => p.ProductID == productID)
                .FirstOrDefault();
        }
        public Product CreateProduct(Product newProduct)
        {
            var newRecord = _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return newRecord;
        }
        public void UpdateProduct(Product productToUpdate)
        {
            _dbContext.Products.Attach(productToUpdate);
            _dbContext.Entry<Product>(productToUpdate).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        #endregion

        #region supplier entity actions
        public IQueryable<Supplier> GetSuppliers()
        {
            return _dbContext.Suppliers;
        }
        public Supplier GetSupplier(int supplierID)
        {
            return (from s in _dbContext.Suppliers
                    where s.SupplierID == supplierID
                    select s).FirstOrDefault();
        }
        public Supplier CreateSupplier(Supplier newSupplier)
        {
            var newRecord = _dbContext.Suppliers.Add(newSupplier);
            _dbContext.SaveChanges();
            return newRecord;
        }
        public void UpdateSupplier(Supplier supplierToUpdate)
        {
            _dbContext.Suppliers.Attach(supplierToUpdate);
            _dbContext.Entry<Supplier>(supplierToUpdate).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        #endregion

        #region shipper entity actions
        public IQueryable<Shipper> GetShippers()
        {
            return _dbContext.Shippers;
        }
        public Shipper GetShipper(int shipperID)
        {
            return _dbContext.Shippers
                .Where(s => s.ShipperID == shipperID)
                .FirstOrDefault();
        }
        public Shipper CreateShipper(Shipper entity)
        {
            var newRecord = _dbContext.Shippers.Add(entity);
            _dbContext.SaveChanges();
            return newRecord;
        }
        public void UpdateShipper(Shipper entity)
        {
            _dbContext.Shippers.Attach(entity);
            _dbContext.Entry<Shipper>(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        #endregion

        #endregion
    }
}