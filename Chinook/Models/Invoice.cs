using System;

namespace Chinook.Data
{
    public class InvoiceCustomer
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int InvoiceId { get; internal set; }
        public DateTime InvoiceDate { get; internal set; }
        public string BillingCountry { get; internal set; }
    }
}