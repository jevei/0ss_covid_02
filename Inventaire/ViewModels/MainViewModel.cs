using BillingManagement.UI.ViewModels.Commands;
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
		CustomerListViewModel customerListViewModel;
		public ChangeViewCommand ChangeViewCommand { get; set; }
		public MainViewModel()
		{
			ChangeViewCommand = new ChangeViewCommand(ChangeView);
			invoiceViewModel = new InvoiceViewModel();
			invoiceListViewModel = new InvoiceListViewModel(invoiceViewModel);

			customerViewModel = new CustomerViewModel();
			customerListViewModel = new CustomerListViewModel(customerViewModel);

			LeftViewModel = customerListViewModel;
			CentralViewModel = customerViewModel;

		}
		private void ChangeView(string vm)
		{
			switch (vm)
			{
				case "invoice":
					LeftViewModel = invoiceListViewModel;
					CentralViewModel = invoiceViewModel;
					break;
				case "customer":
					LeftViewModel = customerListViewModel;
					CentralViewModel = customerViewModel;
					break;
			}
		}
	}
}
