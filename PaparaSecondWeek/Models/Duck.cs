namespace PaparaSecondWeek.Models
{
    /// <summary>
    /// LSP - Liskov Değiştirme İlkesine aykırı bir örnek.
    /// </summary>
    public abstract class Duck
    {
        public abstract void Swim();
        public abstract void Fly();
    }

    public class MallarDuck : Duck
    {
        public override void Fly()
        {
            // Yaban ördeği uçabilir
        }

        public override void Swim()
        {
            // Yaban ördeği yüzebilir.
        }
    }

    public class RubberDuck : Duck
    {
        public override void Fly()
        {
            // Lastik ördeğim uçamaz
            throw new System.NotImplementedException();
        }

        public override void Swim()
        {
           // Lastik ördeğim yüzebilir.
        }
    }

    /// <summary>
    /// LSP Liskov Değiştirme İlkesine uygun. Tüm ördekler yüzebilir ama uçamayabilirler.
    /// </summary>
    public abstract class BaseDuck
    {
        /// <summary>
        /// Tüm ördekler kesinlikle yüzebilir.
        /// </summary>
        public abstract void Swim();

    }

    public interface IFlyable
    {
        void Fly();
    }

    public class GreenHeadMallarDuck : BaseDuck, IFlyable
    {
        public void Fly()
        {
            // Yeşil Başlı Yaban Ördeğim Uçabilir.
        }

        public override void Swim()
        {
            // Yeşil Başlı Yaban Ördeğim Yüzebilir.
        }
    }

    public class YellowRubberDuck : BaseDuck
    {
        public override void Swim()
        {
           // Benim sarı lastik ördeğim yüzebilir ama uçamaz.
        }
    }

    /// <summary>
    /// ISP - Arayüz Ayrım İlkesine uygun
    /// </summary>
    public interface IDuck
    {
        //void Fly(); Silince sorun kalmadı.
        void Swim();        
    }

    public interface IDuckFlyable : IDuck
    {
        void Fly();
    }

    public class BlackHeadDuck : IDuck
    {
        public void Fly()
        {
            // Siyah başlı ördeğim uçabilir.
        }

        public void Swim()
        {
           // Siyah başlı ördeğim yüzebilir.
        }
    }

    public class YellowHeadRubberDuck : IDuck
    {
        // IDucktan Fly i sildiğimiz için sorun kalmadı.
        //public void Fly()
        //{
        //    // Sarı kafalı lastik ördeğim uçamaz method gereksiz kaldı.
        //}

        public void Swim()
        {
            // Sarı kafalı ördeğim yüzebilir.
        }
    }

    public class BlackHeaderMallarDuck : IDuckFlyable
    {
        public void Fly()
        {
            throw new System.NotImplementedException();
        }

        public void Swim()
        {
            throw new System.NotImplementedException();
        }
    }

}
