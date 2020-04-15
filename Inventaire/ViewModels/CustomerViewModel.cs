using app_models;
using BillingManagement.Business;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
	{
		private Customer customer;
		private String customerCIs;

		public Customer Customer
		{
			get { return customer; }
			set
			{
				customer = value;
				OnPropertyChanged();
			}
		}

		public string CustomerCIs {
			get { return customerCIs; }
			set
			{
				customerCIs = value;
				OnPropertyChanged();
			}
		}
	}
}
