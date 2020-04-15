using BillingManagement.Business;
using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class InvoiceListViewModel:BaseViewModel
    {
		private ObservableCollection<Invoice> invoices;

		public ObservableCollection<Invoice> Invoices
		{
			get { return invoices; }
			set
			{
				invoices = value;
				OnPropertyChanged();
			}
		}

		private Invoice selectedInvoice;

		public Invoice SelectedInvoice
		{
			get { return selectedInvoice; }
			set
			{
				selectedInvoice = value;
				invoiceViewModel.Invoice = selectedInvoice;
				OnPropertyChanged();
			}
		}

		InvoicesDataService invoiceDataService;
		InvoiceViewModel invoiceViewModel;

		public InvoiceListViewModel(InvoiceViewModel ivm)
		{
			InitValues();

			invoiceViewModel = ivm;
		}

		private void InitValues()
		{
			invoiceDataService = new InvoicesDataService();
			Invoices = new ObservableCollection<Invoice>(invoiceDataService.GetAll());
		}
	}
}
