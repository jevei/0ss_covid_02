using app_models;
using BillingManagement.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class CustomerListViewModel: BaseViewModel
	{
		private ObservableCollection<Customer> customers;
		private string selectedCustomerCIs;
		public ObservableCollection<Customer> Customers
		{
			get { return customers; }
			set
			{
				customers = value;
				OnPropertyChanged();
			}
		}

		private Customer selectedCustomer;

		public Customer SelectedCustomer
		{
			get { return selectedCustomer; }
			set
			{
				selectedCustomer = value;
				customerViewModel.Customer = selectedCustomer;
				OnPropertyChanged();
			}
		}
		public string SelectedCustomerCIs
		{
			get
			{
				if (selectedCustomer != null)
				{
					var CI = new StringBuilder();
					foreach (var CIs in SelectedCustomer.ContactInfos)
					{
						CI.AppendLine(CIs.ContactType.ToString() + " : " + CIs.Contact.ToString());
					}

					return CI.ToString();
				}
				else
					return "";
			}
			set
			{
				selectedCustomerCIs = value;
				customerViewModel.CustomerCIs = selectedCustomerCIs;
				OnPropertyChanged();
			}
		}
		CustomersDataService customerDataService;
		CustomerViewModel customerViewModel;

		public CustomerListViewModel(CustomerViewModel vm)
		{
			InitValues();

			customerViewModel = vm;
		}

		private void InitValues()
		{
			customerDataService = new CustomersDataService();
			Customers = new ObservableCollection<Customer>(customerDataService.GetAll());
		}

	}
}
