using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureStore
{
    internal class DatabaseControl
    {
        public static List<Provider> GetProviderForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Provider.ToList();
            }
        }

        public static List<Turnover> GetTurnoverForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Turnover.Include(p => p.EmployeeEntity).ToList();
            }
        }
        public static List<Product> GetProductForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Product.Include(p => p.Product_Turnover_Entity).Include(p => p.Product_Supply_Entity).Include(p => p.ProviderEntity).ToList();
            }
        }

        public static List<Supply_Product> GetProduct_SupplyForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Supply_Product.Include(p => p.SupplyEntity).Include(p => p.ProductEntity).Include(p => p.ProductEntity.ProviderEntity).ToList();
            }
        }

        public static List<Product> GetProductEntityForView(int ProductId)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Product.Where(p => p.Product_Id == ProductId).ToList();
            }
        }

        public static List<Product> GetSupply_ProductForView(int ProviderId)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Product.Include(p => p.Product_Supply_Entity).Include(p => p.ProviderEntity).Where(p => p.ProviderEntity.Provider_Id == ProviderId).ToList();
            }
        }

        public static List<Employee> GetEmployeeForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Employee.ToList();
            }
        }

        public static List<Supply> GetSupplyForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Supply.Include(p => p.Supply_Product_Entity).Include(p => p.ProviderEntity).ToList();
            }
        }

        public static List<Turnover_Product> GetTurnover_ProductForView(int TurnoverId)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Turnover_Product.Include(p => p.ProductEntity).Include(p => p.TurnoverEntity).Where(p => p.Turnover_Key == TurnoverId).ToList();       
            }
        }

        public static void AddProduct(Product product)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Product.Add(product);
                ctx.SaveChanges();
            }
        }

        public static void AddTurnover(Turnover turnover)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Turnover.Add(turnover);
                ctx.SaveChanges();
            }
        }
        public static void RemoveTurnover(Turnover turnover)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Turnover.Remove(turnover);
                ctx.SaveChanges();
            }
        }
        public static void AddTurnover_Product(Turnover_Product turnover_Product)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Turnover_Product.Add(turnover_Product);
                ctx.SaveChanges();
            }
        }

        public static void RemoveProduct(Product product)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Product.Remove(product);
                ctx.SaveChanges();
            }
        }

        public static void AddProvider(Provider provider)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Provider.Add(provider);
                ctx.SaveChanges();
            }
        }

        public static void AddSupply(Supply supply)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Supply.Add(supply);
                ctx.SaveChanges();
            }
        }

        public static void AddSupply_Product(Supply_Product supply_Product)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Supply_Product.Add(supply_Product);
                ctx.SaveChanges();
            }
        }

        public static void AddEmployee(Employee employee)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Employee.Add(employee);
                ctx.SaveChanges();
            }
        }

        public static void RemoveEmployee(Employee employee)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Employee.Remove(employee);
                ctx.SaveChanges();
            }
        }

        public static void RemoveProvider(Provider provider)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Provider.Remove(provider);
                ctx.SaveChanges();
            }
        }

        public static void UpdateProduct(Product product)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                Product _product = ctx.Product.FirstOrDefault(p => p.Product_Id == product.Product_Id);

                if(product == null)
                {
                    return;
                }

                _product.Product_Name = product.Product_Name;
                _product.Product_Type = product.Product_Type;
                _product.Product_Amount = product.Product_Amount;
                _product.Expiration_Date = product.Expiration_Date;
                _product.Provider_Key = product.Provider_Key;
                _product.Product_Cost = product.Product_Cost;

                ctx.SaveChanges();
            }
        }

        public static void UpdateEmployee(Employee employee)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                Employee _employee = ctx.Employee.FirstOrDefault(p => p.Employee_Id == employee.Employee_Id);

                if (employee == null)
                {
                    return;
                }

                _employee.Employee_Name = employee.Employee_Name;
                _employee.Job_Title = employee.Job_Title;
                _employee.Login = employee.Login;
                _employee.Password = employee.Password;

                ctx.SaveChanges();
            }
        }

        public static void UpdateProvider(Provider provider)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                Provider _provider = ctx.Provider.FirstOrDefault(p => p.Provider_Id == provider.Provider_Id);

                if (provider == null)
                {
                    return;
                }

                _provider.Provider_Name= provider.Provider_Name;
                _provider.Provider_Phone = provider.Provider_Phone;
                _provider.Provider_Email = provider.Provider_Email;
                ctx.SaveChanges();
            }
        }
    }
}

