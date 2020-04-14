using BillingManagement.Business;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            InvoiceDataService invoiceDS = new InvoiceDataService();
            Invoices = new ObservableCollection<Invoice>(invoiceDS.GetAll());
        }

        public ObservableCollection<Invoice> Invoices { get; set; }
    }
}
