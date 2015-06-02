namespace NorthwindAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using NorthwindAPI.Data.Entities;

    public static class ModelFactory
    {
        public static IEnumerable<CustomerModel> GetCustomers(IQueryable<Customer> customers)
        {
            return (from c in customers
                    select new CustomerModel()
                    {
                        CustomerID = c.CustomerID,
                        Address = c.Address,
                        City = c.City,
                        CompanyName = c.CompanyName,
                        ContactName = c.ContactName,
                        ContactTitle = c.ContactTitle,
                        Country = c.Country,
                        Fax = c.Fax,
                        Phone = c.Phone,
                        PostalCode = c.PostalCode
                    });
        }
        public static CustomerModel GetCustomer(Customer c)
        {
            return new CustomerModel()
            {
                CustomerID = c.CustomerID,
                Address = c.Address,
                City = c.City,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Country = c.Country,
                Fax = c.Fax,
                Phone = c.Phone,
                PostalCode = c.PostalCode
            };
        }
        public static IEnumerable<OrderModel> GetOrders(IQueryable<Order> orders)
        {
            return (from o in orders
                    select new OrderModel
                    {
                        OrderID = o.OrderID,
                        OrderDate = o.OrderDate,
                        EmployeeID = o.EmployeeID,
                        Freight = o.Freight,
                        RequiredDate = o.RequiredDate,
                        ShipAddress = o.ShipAddress,
                        ShipCity = o.ShipCity,
                        ShipCountry = o.ShipCountry,
                        ShipName = o.ShipName,
                        ShippedDate = o.ShippedDate,
                        ShipVia = new ShipperModel()
                        {
                            CompanyName = o.Shipper.CompanyName,
                            Phone = o.Shipper.Phone,
                            ShipperID = o.Shipper.ShipperID
                        },
                        ShipPostalCode = o.ShipPostalCode,
                        ShipRegion = o.ShipRegion,
                        OrderDetails = (from od in o.OrderDetails
                                        select new OrderDetailModel()
                                        {
                                            Discount = od.Discount,
                                            Quantity = od.Quantity,
                                            UnitPrice = od.UnitPrice,
                                            Product = new ProductModel()
                                            {
                                                ProductID = od.Product.ProductID,
                                                Category = new CategoryModel()
                                                {
                                                    CategoryID = od.Product.Category.CategoryID,
                                                    CategoryName = od.Product.Category.CategoryName,
                                                    Description = od.Product.Category.Description,
                                                    Picture = od.Product.Category.Picture
                                                },
                                                Discontinued = od.Product.Discontinued,
                                                ProductName = od.Product.ProductName,
                                                QuantityPerUnit = od.Product.QuantityPerUnit,
                                                ReorderLevel = od.Product.ReorderLevel,
                                                Supplier = new SupplierModel()
                                                {
                                                    SupplierID = od.Product.Supplier.SupplierID,
                                                    Address = od.Product.Supplier.Address,
                                                    City = od.Product.Supplier.City,
                                                    CompanyName = od.Product.Supplier.CompanyName,
                                                    ContactName = od.Product.Supplier.ContactName,
                                                    ContactTitle = od.Product.Supplier.ContactTitle,
                                                    Country = od.Product.Supplier.Country,
                                                    Fax = od.Product.Supplier.Fax,
                                                    HomePage = od.Product.Supplier.HomePage,
                                                    Phone = od.Product.Supplier.Phone,
                                                    PostalCode = od.Product.Supplier.PostalCode,
                                                    Region = od.Product.Supplier.Region
                                                },
                                                UnitPrice = od.Product.UnitPrice,
                                                UnitsInStock = od.Product.UnitsInStock,
                                                UnitsOnOrder = od.Product.UnitsOnOrder
                                            }
                                        })
                    });
        }
        public static OrderModel GetOrder(Order o)
        {
            return new OrderModel
                    {
                        OrderID = o.OrderID,
                        OrderDate = o.OrderDate,
                        EmployeeID = o.EmployeeID,
                        Freight = o.Freight,
                        RequiredDate = o.RequiredDate,
                        ShipAddress = o.ShipAddress,
                        ShipCity = o.ShipCity,
                        ShipCountry = o.ShipCountry,
                        ShipName = o.ShipName,
                        ShippedDate = o.ShippedDate,
                        ShipVia = new ShipperModel()
                        {
                            CompanyName = o.Shipper.CompanyName,
                            Phone = o.Shipper.Phone,
                            ShipperID = o.Shipper.ShipperID
                        },
                        ShipPostalCode = o.ShipPostalCode,
                        ShipRegion = o.ShipRegion,
                        OrderDetails = (from od in o.OrderDetails
                                        select new OrderDetailModel()
                                        {
                                            Discount = od.Discount,
                                            Quantity = od.Quantity,
                                            UnitPrice = od.UnitPrice,
                                            Product = new ProductModel()
                                            {
                                                ProductID = od.Product.ProductID,
                                                Category = new CategoryModel()
                                                {
                                                    CategoryID = od.Product.Category.CategoryID,
                                                    CategoryName = od.Product.Category.CategoryName,
                                                    Description = od.Product.Category.Description,
                                                    Picture = od.Product.Category.Picture
                                                },
                                                Discontinued = od.Product.Discontinued,
                                                ProductName = od.Product.ProductName,
                                                QuantityPerUnit = od.Product.QuantityPerUnit,
                                                ReorderLevel = od.Product.ReorderLevel,
                                                Supplier = new SupplierModel()
                                                {
                                                    SupplierID = od.Product.Supplier.SupplierID,
                                                    Address = od.Product.Supplier.Address,
                                                    City = od.Product.Supplier.City,
                                                    CompanyName = od.Product.Supplier.CompanyName,
                                                    ContactName = od.Product.Supplier.ContactName,
                                                    ContactTitle = od.Product.Supplier.ContactTitle,
                                                    Country = od.Product.Supplier.Country,
                                                    Fax = od.Product.Supplier.Fax,
                                                    HomePage = od.Product.Supplier.HomePage,
                                                    Phone = od.Product.Supplier.Phone,
                                                    PostalCode = od.Product.Supplier.PostalCode,
                                                    Region = od.Product.Supplier.Region
                                                },
                                                UnitPrice = od.Product.UnitPrice,
                                                UnitsInStock = od.Product.UnitsInStock,
                                                UnitsOnOrder = od.Product.UnitsOnOrder
                                            }
                                        })
                    };
        }
        public static IEnumerable<ProductModel> GetProducts(IQueryable<Product> entities)
        {
            return (from p in entities
                    select new ProductModel
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        Category = new CategoryModel
                        {
                            CategoryID = p.Category.CategoryID,
                            CategoryName = p.Category.CategoryName,
                            Description = p.Category.Description,
                            Picture = p.Category.Picture
                        },
                        Discontinued = p.Discontinued,
                        QuantityPerUnit = p.QuantityPerUnit,
                        ReorderLevel = p.ReorderLevel,
                        Supplier = new SupplierModel
                        {
                            Address = p.Supplier.Address,
                            City = p.Supplier.City,
                            CompanyName = p.Supplier.CompanyName,
                            ContactName = p.Supplier.ContactName,
                            ContactTitle = p.Supplier.ContactTitle,
                            Country = p.Supplier.Country,
                            Fax = p.Supplier.Fax,
                            HomePage = p.Supplier.HomePage,
                            Phone = p.Supplier.Phone,
                            PostalCode = p.Supplier.PostalCode,
                            Region = p.Supplier.Region,
                            SupplierID = p.Supplier.SupplierID
                        },
                        UnitPrice = p.UnitPrice,
                        UnitsInStock = p.UnitsInStock,
                        UnitsOnOrder = p.UnitsOnOrder
                    });
        }
        public static ProductModel GetProduct(Product p)
        {
            return new ProductModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Category = new CategoryModel
                {
                    CategoryID = p.Category.CategoryID,
                    CategoryName = p.Category.CategoryName,
                    Description = p.Category.Description,
                    Picture = p.Category.Picture
                },
                Discontinued = p.Discontinued,
                QuantityPerUnit = p.QuantityPerUnit,
                ReorderLevel = p.ReorderLevel,
                Supplier = new SupplierModel
                {
                    Address = p.Supplier.Address,
                    City = p.Supplier.City,
                    CompanyName = p.Supplier.CompanyName,
                    ContactName = p.Supplier.ContactName,
                    ContactTitle = p.Supplier.ContactTitle,
                    Country = p.Supplier.Country,
                    Fax = p.Supplier.Fax,
                    HomePage = p.Supplier.HomePage,
                    Phone = p.Supplier.Phone,
                    PostalCode = p.Supplier.PostalCode,
                    Region = p.Supplier.Region,
                    SupplierID = p.Supplier.SupplierID
                },
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder
            };
        }
        public static IEnumerable<SupplierModel> GetSuppliers(IQueryable<Supplier> suppliers)
        {
            return (from s in suppliers
                    select new SupplierModel
                    {
                        Address = s.Address,
                        City = s.City,
                        CompanyName = s.CompanyName,
                        ContactName = s.ContactName,
                        ContactTitle = s.ContactTitle,
                        Country = s.Country,
                        Fax = s.Fax,
                        HomePage = s.HomePage,
                        Phone = s.Phone,
                        PostalCode = s.PostalCode,
                        Region = s.Region,
                        SupplierID = s.SupplierID
                    });
        }
        public static SupplierModel GetSupplier(Supplier s)
        {
            return new SupplierModel
            {
                Address = s.Address,
                City = s.City,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                Country = s.Country,
                Fax = s.Fax,
                HomePage = s.HomePage,
                Phone = s.Phone,
                PostalCode = s.PostalCode,
                Region = s.Region,
                SupplierID = s.SupplierID
            };
        }
        public static IEnumerable<ShipperModel> GetShippers(IQueryable<Shipper> shippers)
        {
            return (from s in shippers
                    select new ShipperModel
                    {
                        ShipperID = s.ShipperID,
                        CompanyName = s.CompanyName,
                        Phone = s.Phone
                    });
        }
        public static ShipperModel GetShipper(Shipper s)
        {
            return new ShipperModel
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            };
        }
    }
}