using System;
using System.Collections.Generic;
using Chinook.Models;
using System.Data.SqlClient;
using Dapper;

namespace Chinook.Data
{
    public class CustomerRepository
    {
        const string ConnectionString = "Server = localhost; Database=Chinook; Trusted_Connection=True;";

        public List<Customer> GetByCountry(string country)
        {
            var sql = @"
                select 
                    FirstName, 
                    LastName, 
                    CustomerId, 
                    Country
                from Customer
                where Customer.Country = @Country";

            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();

                var cmd = db.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("Country", country);

                var reader = cmd.ExecuteReader();
                var customers = new List<Customer>();
                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        CustomerId = (int)reader["CustomerId"],
                        Country = (string)reader["Country"]
                    };

                    customers.Add(customer);
                }

                return customers;
            }
        }

        public IEnumerable<InvoiceCustomer> GetInvoicesByCountry(string country)
        {
            var query = @"
                        select FirstName, LastName, InvoiceId, InvoiceDate, BillingCountry
                        from Invoice
	                        join Customer
		                        on Invoice.CustomerId = Customer.CustomerId
                        where Country = @Country";

            using (var db = new SqlConnection(ConnectionString))
            {
                var invoiceCustomers = db.Query<InvoiceCustomer>(query, new { Country = country });

                return invoiceCustomers;
            }
        }
    }
}
