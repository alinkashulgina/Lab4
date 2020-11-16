using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class SpaceObject
    {
        public static Random rnd = new Random();
        public int Radius = 0;             //радиус (общее св-во для всех объектов космоса

        public virtual String GetInfo()    //virtual чтобы можно было переопределить в классах наследниках
        {
            var str = String.Format("\nРадиус: {0}", this.Radius);
            return str;
        }
    }

    public class Planet : SpaceObject
    {
        public bool Atmosphere = false;    //наличие атмосфера
        public int Attraction = 0;         //сила притяжения

        // ДОБАВИЛА ПЕРЕОПРЕДЛЕНИЕ
        public override String GetInfo()
        {
            var str = "Я планета";
            str += base.GetInfo();
            str += String.Format("\nНаличие атмосферы: {0}", this.Atmosphere);
            str += String.Format("\nСила притяжения: {0}", this.Attraction);
            return str;
        }

        // добавила статический метод генерации случайной планеты
        public static Planet Generate()
        {
            return new Planet
            {
                Radius = 2439 + rnd.Next() % 67472,       //радиус планеты от 2439 до 69911 
                Atmosphere = rnd.Next() % 2 == 0,    //наличие атмосферы true или false
                Attraction = 36 + rnd.Next() % 1404  //сила притяжения от 36 до 1440 
            };
        }
    }

    public enum StarType { white, blue, red };
    public class Star : SpaceObject
    {
        public int Density = 0;                     //плотность
        public StarType Color = StarType.white;     //цвет
        public int Temperature = 0;                //температура

        // ДОБАВИЛА ПЕРЕОПРЕДЛЕНИЕ
        public override String GetInfo()
        {
            var str = "Я звезда";
            str += base.GetInfo();
            str += String.Format("\nПлотность: {0}", this.Density);
            str += String.Format("\nЦвет: {0}", this.Color);
            str += String.Format("\nНаличие температура: {0}", this.Temperature);
            return str;
        }

        // добавила статический метод генерации случайной звезды
        public static Star Generate()
        {
            return new Star
            {
                Radius = 1 + rnd.Next() % 299,             //радиус планеты от 1 до 300
                Density = 1 + rnd.Next() % 1749999,        //плотность по отношению к воде от 1 до 1750000
                Color = (StarType)rnd.Next(3),             //цвет звезды
                Temperature = 2500 + rnd.Next() % 25500    //температура от 2500 до 28000
            };
        }
    }

    public enum CometType { ISON, PANSTARS, MCNAUGHT };
    public class Comet : SpaceObject
    {
        public int Time = 0;                         //период прохождения через солнечную систему
        public CometType Name = CometType.ISON;      //название

        // ДОБАВИЛ ПЕРЕОПРЕДЛЕНИЕ
        public override String GetInfo()
        {
            var str = "Я комета";
            str += base.GetInfo();
            str += String.Format("\nВремя: {0}", this.Time);
            str += String.Format("\nНазвание: {0}", this.Name);
            return str;
        }

        // добавила статический метод генерации случайной кометы
        public static Comet Generate()
        {
            return new Comet
            {
                Radius = 1 + rnd.Next() % 9,          //радиус планеты от 1 до 10
                Time = 1 + rnd.Next() % 1749999,        //плотность по отношению к воде от 1 до 1750000
                Name = (CometType)rnd.Next(3),          //название кометы
            };
        }

    }

  
}