using app_models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace BillingManagement.Models
{
    public class Invoice: INotifyPropertyChanged
    {
        private Customer customer;
        private double subtotal;
        private double total;
        private double fedTax;
        private double provTax;
        static int nextId;
        public int InvoiceId { get; private set; }
        public DateTime CreationDateTime { get; }
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
                OnPropertyChanged();
                OnPropertyChanged(nameof(FedTax));
                OnPropertyChanged(nameof(ProvTax));
                OnPropertyChanged(nameof(Total));
            }
        }
        //public double FedTax => (SubTotal) * (5 / 100);
        //public double ProvTax => (subtotal) * (9.975 / 100);
        public double Total 
        {
            get => subtotal + ProvTax + FedTax; 
            set
            {
                total = value;
            }
        }
        public double ProvTax
        {
            get => (subtotal) * (9.975 / 100);
            set
            {
                provTax = value;
            }
        }

        public double FedTax
        {
            get => (subtotal) * (5.00 / 100);
            set
            {
                fedTax = value;
            }
        }

        public Invoice()
        {
            InvoiceId = Interlocked.Increment(ref nextId);
            CreationDateTime = DateTime.Now;
        }
        public string Info => $"{CreationDateTime}, {Total}";
        private string infoC;
        public string InfoC
        {
            get => Customer.Info;
            set
            {
                infoC = value;
                OnPropertyChanged();
            }
        }
        public Invoice(Customer customer)
        {
            InvoiceId = Interlocked.Increment(ref nextId);
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
