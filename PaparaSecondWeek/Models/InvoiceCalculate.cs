using System;

namespace PaparaSecondWeek.Models
{
    /// <summary>
    /// OCP - Açık Kapalı İlkesine aykırı kullanım.
    /// </summary>
    public class InvoiceCalculate
    {
        public InvoiceType Type { get; set; }
        public double Tax { get; set; }
        public double CalculateTax()
        {
            if (Type == InvoiceType.Company)
                return Tax * 1.23; // %23 tax to company
            else if (Type == InvoiceType.Person)
                return Tax * 1.18; // %18 tax to people.
            
            throw new Exception();           
        }
    }

    public enum InvoiceType
    {
        Company,
        Person,        
    }

    /// <summary>
    /// OCP - Açık Kapalı İlkesine Uygun kullanım. Ek olarak SRP Tek Sorumluluk ilkesine de uyumlu.
    /// Bir sınıf davranışını değiştirmeden genişletebilmelisiniz.
    /// </summary>
    public abstract class BaseInvoice
    {
        public double Tax { get; set; }
        public abstract double CalculateTax();
    }


    public class InvoiceCompany : BaseInvoice
    {
        public override double CalculateTax()
        {
            return Tax * 1.23; // %23 tax to company
        }
    }

    public class InvoicePerson : BaseInvoice
    {
        public override double CalculateTax()
        {
            return Tax * 1.18; // %18 tax to people.
        }
    }
}
