using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class MainViewModel:BaseViewModel
    {
		private BaseViewModel leftViewModel;

		public BaseViewModel LeftViewModel
		{
			get { return leftViewModel; }
			set
			{
				leftViewModel = value;
				OnPropertyChanged();
			}
		}

		private BaseViewModel centralViewModel;

		public BaseViewModel CentralViewModel
		{
			get { return centralViewModel; }
			set
			{
				centralViewModel = value;
				OnPropertyChanged();
			}
		}

		InvoiceListViewModel invoiceListViewModel;
		InvoiceViewModel invoiceViewModel;

		CustomerViewModel customerViewModel;
		CustomerListViewModel custumerListViewModel;

		public MainViewModel()
		{
			invoiceViewModel = new InvoiceViewModel();
			invoiceListViewModel = new InvoiceListViewModel(invoiceViewModel);

			customerViewModel = new CustomerViewModel();
			custumerListViewModel = new CustomerListViewModel(customerViewModel);

			LeftViewModel = invoiceListViewModel;
			CentralViewModel = invoiceViewModel;

		}
	}
}
