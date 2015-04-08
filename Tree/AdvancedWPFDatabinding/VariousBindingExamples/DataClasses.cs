using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VariousBindingExamples
{
    #region Customer

    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public static List<Customer> CreateCustomers()
        {
            return new List<Customer>
            {
                new Customer 
                {
                    Name="Customer 1",
                    Orders=new List<Order>
                    {
                        new Order
                        {
                            Desc="Big Order",
                            OrderDetails=new List<OrderDetail>
                            {
                                new OrderDetail { Product="Glue", Quantity=21 },
                                new OrderDetail { Product="Fudge", Quantity=32 }
                            }
                        },
                        new Order
                        {
                            Desc="Little Order",
                            OrderDetails=new List<OrderDetail>
                            {
                                new OrderDetail { Product="Ham", Quantity=1 },
                                new OrderDetail { Product="Yarn", Quantity=2 }
                            }
                        }
                    }
                },
                new Customer 
                {
                    Name="Customer 2",
                    Orders=new List<Order>
                    {
                        new Order
                        {
                            Desc="First Order",
                            OrderDetails=new List<OrderDetail>
                            {
                                new OrderDetail { Product="Mousetrap", Quantity=4 }
                            }
                        }
                    }
                },
            };
        }
    }

    #endregion // Customer

    #region Era

    public class Era
    {
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
    }

    #endregion // Era

    #region FullName

    public class FullName
    {
        public string FirstName { get; set; }
        public char MiddleInitial { get; set; }
        public string LastName { get; set; }
    }

    #endregion // FullName

    #region Order

    public class Order
    {
        public string Desc { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public override string ToString()
        {
            return this.Desc;
        }
    }

    #endregion // Order

    #region OrderDetail

    public class OrderDetail
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
    }

    #endregion // OrderDetail

    #region Person

    class Person
    {
        public string Name { get; set; }
    }

    #endregion // Person

    #region SmartEra

    public class SmartEra 
        : System.ComponentModel.IDataErrorInfo
    {
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }

        #region IDataErrorInfo Members

        public string Error
        {
            get { return null; }
        }

        public string this[string property]
        {
            get 
            {
                string msg = null;
                switch (property)
                {
                    case "StartDate":
                        if (DateTime.Now < this.StartDate)
                            msg = "Start date must be in the past.";
                        break;

                    case "Duration":
                        if (this.Duration.Ticks == 0)
                            msg = "An era must have a duration.";
                        break;

                    default:
                        throw new ArgumentException(
                            "Unrecognized property: " + property);
                }
                return msg;
            }
        }

        #endregion // IDataErrorInfo Members
    }

    #endregion // SmartEra
}