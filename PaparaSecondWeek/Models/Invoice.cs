namespace PaparaSecondWeek.Models
{
    public class Invoice
    {
        private readonly IEmail _email;
        public Invoice(IEmail email)
        {
            _email = email;
        }

        public void Create()
        {
            // Invoice Create 
            ///...
            _email.Send();
        }

        /// <summary>
        /// SRP - Tek Sorumluluk İlkesi
        /// Invoice sınıfında sadece ilgili method ve propertiler olmalı başka işler olmamalı.
        /// </summary>
        //public void SendMail()
        //{
        //    // Invoice Send Mail
        //}
    }
}
