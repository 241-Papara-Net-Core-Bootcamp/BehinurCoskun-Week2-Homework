namespace PaparaSecondWeek.Models
{

    /// <summary>
    /// DIP Bağımlılığı Tersine Çevirme İlkesi
    /// </summary>
    public interface IPayment
    {
        void DoPayment();
        void Refund();
        void UsePoint();
    }

    public interface IRefund
    {
        void Refund();
    }
    /// <summary>
    /// IPayment içersindeki tüm methodlara muhtaç kaldık yani bağımlı olduk. Oysaki sadece Ödeme yapacaktım.
    /// IRefunda bağımlı kalmadan iade işlemi yaptık.
    /// </summary>
    public class PaymentWithCreditCard : IPayment
    {
        private readonly IRefund _refund;
        public PaymentWithCreditCard(IRefund refund)
        {
            _refund = refund;
        }
        public void DoPayment()
        {
            // Kredi kartı ile ödeme işlemi yaptım.
        }

        public void Refund()
        {
            _refund.Refund();   
        }

        public void UsePoint()
        {
            throw new System.NotImplementedException();
        }
    }   

    public class PaymentWithBankCard
    {
        private readonly IPayment _payment;
        public PaymentWithBankCard(IPayment payment)
        {
            _payment = payment;
        }

        public void DoPayment()
        {
            _payment.DoPayment();
        }
    }

    public class PaymentWithEFT : IPayment
    {
        private readonly IPayment _payment;
        public PaymentWithEFT(IPayment payment)
        {
            _payment = payment;
        }

        public void DoPayment()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// EFT işleminde İade yok ama iadeyi yazmak zorunda kaldım. IPaymente bağlıyım.
        /// </summary>
        public void Refund()
        {
            //_payment.Refund();
        }

        ///EFT işleminde puan kullanımı yok ama method yazılı duruyor.IPaymente bağlıyım.
        public void UsePoint()
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// İade ve Puan kullanıma methodlarınu kullanmadan ve Ipayment beni zorlamadan sadece Ödeme yaptım.
    /// </summary>
    public class PaymentWithHavale 
    {
        private readonly IPayment _payment;
        public PaymentWithHavale(IPayment payment)
        {
            _payment=payment;
        }

        public void HavaleYap()
        {
            _payment.DoPayment();
        }
    }
}
