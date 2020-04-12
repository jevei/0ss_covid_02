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
        public double FedTax => (SubTotal) * (5 / 100);
        public double ProvTax => (subtotal) * (9.975 / 100);
        public double Total => subtotal + ProvTax + FedTax;
        public Invoice()
        {
            InvoiceId = Interlocked.Increment(ref nextId);
            CreationDateTime = DateTime.Now;
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
