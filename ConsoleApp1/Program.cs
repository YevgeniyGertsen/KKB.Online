using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subaru car = new Subaru();

            car.EngineType = 1;
            car.EngineVolume = 1200;
            car.Model = "Outback";
            car.Weight = 2500;

            //Engine en = new Engine();
        }
    }

    public class MyArr
    {
        int[] arr;
        public int length;

        public MyArr(int size)
        {
            arr = new int[size];
            length = size;
        }

        public int this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
    }

    public class Book
    {
        public Book(string Name)
        {
            this.Name = Name;
            sName = "";
        }

        public int Age;
        public string Name { get; set; }

        private string sName_ = "";
        public string sName
        {
            get
            {
                return sName_;
            }
            set
            {
                if (value.Length <= 2)
                    sName_ = "***";
                else
                    sName_ = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Library
    {
        private Book[] books;
        public Library()
        {
            books = new Book[]
            {
                new Book("Отцы и дети"),
                new Book("Евгений онегин"),
                new Book("Война и мир")
            };
        }

        public int Length
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }//var data = Library[i]
            set { books[index] = value; }//Library[i] = new Book();
        }
    }

    public class Number
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public int SomeValue { get; set; }

        //public static explicit operator Number(Money m)
        //{
        //    return new Number { Amount = m.Amount };
        //}
        public static implicit operator Number(Money m)
        {
            return new Number { Amount = m.Amount };
        }
    }

    public class Money
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }

        public Money(decimal Amount, string Unit)
        {
            this.Amount = Amount;
            this.Unit = Unit;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Unit != b.Unit)
                throw new InvalidOperationException("Нельзя");

            return new Money(a.Amount + b.Amount, a.Unit);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                this.Amount, this.Unit);
        }

        //==
        public override bool Equals(object obj)
        {
            return ((Money)obj).Amount == this.Amount;
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Amount == b.Amount;
        }
        public static bool operator !=(Money a, Money b)
        {
            return a.Amount != b.Amount;
        }

    }

    public class Counter
    {
        public int Second { get; set; }

        public static implicit operator Counter(int x)
        {
            return new Counter { Second = x };
        }

        public static explicit operator int(Counter counter)
        {
            return counter.Second;
        }

        public virtual void M1()
        {

        }
    }



    public abstract class Engine
    {
        public Engine() : this(0, 0)
        {

        }
        public Engine(int EngineVolume, int Weight) : this(EngineVolume, Weight, "")
        {

        }
        public Engine(int EngineVolume, int Weight, string Model) : this(EngineVolume, Weight, Model, 0)
        {

        }
        public Engine(int EngineVolume, int Weight, string Model, int EngineType)
        {
            this.EngineVolume = EngineVolume;
            this.Weight = Weight;
            this.Model = Model;
            this.EngineType = EngineType;

            //Price = 1000;
        }

        public int EngineVolume { get; set; }
        public int Weight { get; set; }
        public string Model { get; set; }
        public int EngineType { get; set; }
        protected double Price { get; set; } = 1000;
        private string SerialNumber { get; set; } = "SN00000";
        

        public string GetModelName
        {
            get
            {
                return string.Format("Engine model: {0}", Model);
            }
        }

        public abstract void Work();
        public virtual int Discount()
        {
            return 5;
        }
    }

    public class Subaru : Engine
    {
        public Subaru() : this(0, 0)//: base()
        {
        }

        public Subaru(int EngineVolume, int Weight) :base(EngineVolume, Weight)
        {

        }

        public new string Model { get; set; }

        public override void Work()
        {
           //do something
        }

        public override int Discount()
        {
            return 10;
            //return base.Discount()+10;
        }

        public double Depreciation()
        {
            return base.Price * 0.2;
        }
    }
}
