using BillingManagement.Business;
using BillingManagement.Models;
using System.Collections.ObjectModel;

namespace BillingManagement.UI.ViewModels
{
    public class InvoiceViewModel : BaseViewModel
    {
		private Invoice invoice;

		public Invoice Invoice
		{
			get { return invoice; }
			set
			{
				invoice = value;
				OnPropertyChanged();
			}
		}
	}
}
