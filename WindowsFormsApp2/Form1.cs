using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        //указываю тип SpaceObject
        List<SpaceObject> SpaceObjectList = new List<SpaceObject>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();     //сюда, чтобы при запуске приложения что-то показывалось на форме
        }

        private void btnRefil_Click(object sender, EventArgs e)
        {
            this.SpaceObjectList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 9; ++i)       //т.к 8 планет в Солнечной системе
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 (ну остаток от деления на 3)
                {
                    case 0: // если 0, то планета
                        this.SpaceObjectList.Add(Planet.Generate());
                        break;
                    case 1: // если 1 то звезда
                        this.SpaceObjectList.Add(Star.Generate());
                        break;
                    case 2: // если 2 то комета
                        this.SpaceObjectList.Add(Comet.Generate());
                        break;
                        // появление других чисел маловероятно
                }
            }
            ShowInfo();    //чтобы при запуске приложения что-то показывалось на форме
        }

        //функция выводит информацию о количестве объектов космоса на форму
        private void ShowInfo()
        {
            // заведем счетчики под каждый тип
            int planetsC = 0;
            int starsC = 0;
            int cometsC = 0;

            foreach (var SpaceObject in this.SpaceObjectList)
            {
                //чтобы проверить какой именно в списке объект космоса
                if (SpaceObject is Planet) //читается почти как чистый инглиш, "если SpaceObject есть Планета"
                {
                    planetsC += 1;
                }
                else if (SpaceObject is Star)
                {
                    starsC += 1;
                }
                else if (SpaceObject is Comet)
                {
                    cometsC += 1;
                }
            }
            //ну и вывести все это надо на форму
            txtInfo.Text = "Планета\tЗвезда\tКомета"; 
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", planetsC, starsC, cometsC);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.SpaceObjectList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                return;
            }

            // взяли первый объект космоса
            var SpaceObject = this.SpaceObjectList[0];
            // тут вам не реальность, взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что если хочешь удалить, делай это сам
            this.SpaceObjectList.RemoveAt(0);

            // ну а теперь выведем объект космоса (вместо if`ов)
            txtOut.Text = SpaceObject.GetInfo();

            // обновим информацию о количестве объекта космоса на форме
            ShowInfo();
        }
    }
}
