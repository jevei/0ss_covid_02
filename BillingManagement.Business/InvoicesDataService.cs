using app_models;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BillingManagement.Business
{
    public class InvoiceDataService : IDataService<Invoice>
    {
        readonly List<Invoice> invoices;
        readonly List<Customer> customers;

        public InvoiceDataService(CustomersDataService customerDS)
        {
            customers = customerDS.GetAll().ToList();

            Random rnd = new Random();

            foreach (Customer c in customers)
            {
                c.Invoices = new ObservableCollection<Invoice>();

                var nbInvoices = rnd.Next(1, 4);

                for (int i = 0; i < nbInvoices; i++)
                {
                    var index = rnd.Next(invoices.Count);
                    var ci = invoices[index];
                    ci.Customer = c;
                    c.Invoices.Add(ci);
                }
            }
        }
        public InvoiceDataService()
        {
            //initValues();
        }
        /*private void initValues()
        {
            Random rnd = new Random();


            foreach (var customer in _customers.GetAll())
            {
                int nbInvoices = rnd.Next(10);

                for (int i = 0; i < nbInvoices; i++)
                {
                    var invoice = new Invoice(customer);
                    invoice.SubTotal = rnd.NextDouble() * 100 + 50;
                    customer.Invoices.Add(invoice);
                }
            }
        }*/
        public IEnumerable<Invoice> GetAll()
        {
            foreach (Invoice c in invoices)
            {
                yield return c;
            }
        }
    }
}
