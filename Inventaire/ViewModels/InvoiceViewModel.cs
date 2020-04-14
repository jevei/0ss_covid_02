using BillingManagement.Business;
using BillingManagement.Models;
using System.Collections.ObjectModel;

namespace BillingManagement.UI.ViewModels
{
    public class InvoiceViewModel : BaseViewModel
    {
        readonly InvoicesDataService invoicesDataService = new InvoicesDataService();

        private ObservableCollection<Invoice> invoices;
        private Invoice selectedInvoice;
        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }
        public Invoice SelectedInvoice
        {
            get => selectedInvoice;
            set
            {
                selectedInvoice = value;
                OnPropertyChanged();
            }
        }
        public InvoiceViewModel()
        {
            /*InvoiceDataService invoiceDS = new InvoiceDataService();
            Invoices = new ObservableCollection<Invoice>(invoiceDS.GetAll());*/
            Invoices = new ObservableCollection<Invoice>(invoicesDataService.GetAll());
        }
    }
}
