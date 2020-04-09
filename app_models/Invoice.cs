using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BillingManagement.Models
{
    public class Invoice: INotifyPropertyChanged
    {
        private Customer customer;
        private double subtotal;
        //public static int InvoiceId;
        public DateTime CreationDateTime { get; private set; }
        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }
        public double SubTotal
        {
            get => subtotal;
            set
            {
                subtotal = value;
                FedTax = (subtotal) * (5 / 100);
                ProvTax = (subtotal) * (9.975 / 100);
                Total = subtotal + ProvTax + FedTax;
                OnPropertyChanged();
            }
        }
        public double FedTax { get; set; }
        public double ProvTax { get; set; }
        public double Total { get; set; }
        public Invoice()
        {
            CreationDateTime = DateTime.Now;
        }
        public Invoice(Customer customer)
        {
            Customer = customer;
            CreationDateTime = DateTime.Now;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
