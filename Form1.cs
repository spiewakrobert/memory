using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory
{
    public partial class Form1 : Form
    {
        bool[] czy_przyciski_maja_kolor = new bool[17];
        Color[] kolory = new Color[17];
        // zakrytwanie oraz odkrywanie przyciskow jesli jest true to zakryty jesli false to odkryty
        bool[] zakryte = new bool[17];
        bool czy_pierwszy_klik = true;
        // zliczanie ruchow
        int ruchy = 0;
        int numer_pierwszego = 0;
        int numer_drugiego = 0;

        public Form1()
        {
            InitializeComponent();
            // przyporzadkowanie kolorow na starcie gry
            losuj_przycisk(Color.Red);
            losuj_przycisk(Color.Red);
            losuj_przycisk(Color.Blue);
            losuj_przycisk(Color.Blue);
            losuj_przycisk(Color.Pink);
            losuj_przycisk(Color.Pink);
            losuj_przycisk(Color.Green);
            losuj_przycisk(Color.Green);
            losuj_przycisk(Color.LightCoral);
            losuj_przycisk(Color.LightCoral);
            losuj_przycisk(Color.Gold);
            losuj_przycisk(Color.Gold);
            losuj_przycisk(Color.Khaki);
            losuj_przycisk(Color.Khaki);
            losuj_przycisk(Color.White);
            losuj_przycisk(Color.White);

            for (int i = 1; i < 17; i++)
            {
                zakryte[i] = true;
            }
            //koloruj_przyciski();


        }
        // sprawdzenie czy wystapila para oraz sprawdzenie czy wszystkie pary zostaly odkryte
        private void sprawdz()
        {
            ruchy = ruchy + 1;
            if (kolory[numer_pierwszego] == kolory[numer_drugiego])
            {
                MessageBox.Show("Para odgadnieta! Liczba ruchow: " + ruchy);
                zakryte[numer_pierwszego] = false;
                zakryte[numer_drugiego] = false;
            }
            else
            {
                MessageBox.Show("Niestety, probuj dalej!");
            }
            int odkryte = 0;
            for (int g=1; g<17; g++)
            {
                if (zakryte[g]== false)
                {
                    odkryte++;
                }
            }
            if (odkryte==16) { MessageBox.Show("Odkryto wszystkie pary, GRATKI "); }
        }
   


        private void losuj_przycisk(Color kolor)
        {
            Random gen = new Random();
            int numer_pola = gen.Next(1, 17);
            //w tablicy mowiącej o tym ktore przyciski maja juz wyznaczone kolory wstawiamy wartosc true.
            while (czy_przyciski_maja_kolor[numer_pola] == true)
            {
                numer_pola = gen.Next(1, 17);
            }
            czy_przyciski_maja_kolor[numer_pola] = true;
            kolory[numer_pola] = kolor;
        }


        // kolorowanie przyciskow jesli jest kalse to jest niezakryty wowczas pokazuje sie wylosowany kolor w przecienym wypadku jest gray
        private void koloruj_przyciski()
        {
            if (zakryte[1] == false) { button1.BackColor = kolory[1]; } else { button1.BackColor = Color.Gray; }
            if (zakryte[2] == false) { button2.BackColor = kolory[2]; } else { button2.BackColor = Color.Gray; }
            if (zakryte[3] == false) { button3.BackColor = kolory[3]; } else { button3.BackColor = Color.Gray; }
            if (zakryte[4] == false) { button4.BackColor = kolory[4]; } else { button4.BackColor = Color.Gray; }
            if (zakryte[5] == false) { button5.BackColor = kolory[5]; } else { button5.BackColor = Color.Gray; }
            if (zakryte[6] == false) { button6.BackColor = kolory[6]; } else { button6.BackColor = Color.Gray; }
            if (zakryte[7] == false) { button7.BackColor = kolory[7]; } else { button7.BackColor = Color.Gray; }
            if (zakryte[8] == false) { button8.BackColor = kolory[8]; } else { button8.BackColor = Color.Gray; }
            if (zakryte[9] == false) { button9.BackColor = kolory[9]; } else { button9.BackColor = Color.Gray; }
            if (zakryte[10] == false) { button10.BackColor = kolory[10]; } else { button10.BackColor = Color.Gray; }
            if (zakryte[11] == false) { button11.BackColor = kolory[11]; } else { button11.BackColor = Color.Gray; }
            if (zakryte[12] == false) { button12.BackColor = kolory[12]; } else { button12.BackColor = Color.Gray; }
            if (zakryte[13] == false) { button13.BackColor = kolory[13]; } else { button13.BackColor = Color.Gray; }
            if (zakryte[14] == false) { button14.BackColor = kolory[14]; } else { button14.BackColor = Color.Gray; }
            if (zakryte[15] == false) { button15.BackColor = kolory[15]; } else { button15.BackColor = Color.Gray; }
            if (zakryte[16] == false) { button16.BackColor = kolory[16]; } else { button16.BackColor = Color.Gray; }

        }

        // metody odpowiadajace za klikniecie

        private void button1_Click(object sender, EventArgs e)
        {
            // zabezpieczenie przed klliknieciem na ten sam przycisk
            if (button1.BackColor != kolory[1])
            {
                // zamiana bcak kolor na kolor z wylosowanych kolorow
                button1.BackColor = kolory[1];
                // zawsze wystepuje pierwsze klikniecie
                if (czy_pierwszy_klik == true)
                {
                // drugie klikniecie
                    numer_pierwszego = 1;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 1;
                    czy_pierwszy_klik = true;
                    // sprawdzenie czy wystapila para
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor != kolory[2])
            {
                button2.BackColor = kolory[2];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 2;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 2;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor != kolory[3])
            {
                button3.BackColor = kolory[3];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 3;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 3;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor != kolory[4])
            {
                button4.BackColor = kolory[4];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 4;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 4;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor != kolory[5])
            {
                button5.BackColor = kolory[5];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 5;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 5;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor != kolory[6])
            {
                button6.BackColor = kolory[6];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 6;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 6;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor != kolory[7])
            {
                button7.BackColor = kolory[7];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 7;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 7;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor != kolory[8])
            {
                button8.BackColor = kolory[8];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 8;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 8;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor != kolory[9])
            {
                button9.BackColor = kolory[9];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 9;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 9;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor != kolory[10])
            {
                button10.BackColor = kolory[10];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 10;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 10;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }



        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor != kolory[11])
            {
                button11.BackColor = kolory[11];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 11;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 11;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.BackColor != kolory[12])
            {
                button12.BackColor = kolory[12];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 12;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 12;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }


        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.BackColor != kolory[13])
            {
                button13.BackColor = kolory[13];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 13;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 13;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }


        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.BackColor != kolory[14])
            {
                button14.BackColor = kolory[14];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 14;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 14;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }


        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.BackColor != kolory[15])
            {
                button15.BackColor = kolory[15];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 15;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 15;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.BackColor != kolory[16])
            {
                button16.BackColor = kolory[16];
                if (czy_pierwszy_klik == true)
                {
                    numer_pierwszego = 16;
                    czy_pierwszy_klik = false;
                }
                else
                {
                    numer_drugiego = 16;
                    czy_pierwszy_klik = true;
                    sprawdz();
                    koloruj_przyciski();
                }
            }

        }


    }
}
