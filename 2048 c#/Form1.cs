using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_c_
{
    public partial class game : Form
    {

        public int[,] map = new int[4, 4];
        public Label[,] numBoxes = new Label[4, 4];
        public PictureBox[,] blockBox = new PictureBox[4, 4];


        private int score = 0;


        public game()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(keyBEvent);
            createMap();
            generateBox();

        }


        //Создание "карты" 4х4
        private void createMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    PictureBox mapBlock = new PictureBox();

                    mapBlock.Location = new Point(24 + 56 * j, 100 + 56 * i);
                    mapBlock.Size = new Size(50, 50);
                    mapBlock.BackColor = Color.Gray;

                    this.Controls.Add(mapBlock);

                }
            }
        }


        //Генерация блока
        private void generateBox()
        {
            Random random = new Random();
            int a = random.Next(0, 4);
            int b = random.Next(0, 4);

            while (blockBox[a, b] != null)
            {

                a = random.Next(0, 4);
                b = random.Next(0, 4);

            }


            blockBox[a, b] = new PictureBox();
            numBoxes[a, b] = new Label();

            numBoxes[a, b].Text = "2";
            numBoxes[a, b].Font = new Font(new FontFamily("Microsoft Sans Serif"), 15);


            blockBox[a, b].Controls.Add(numBoxes[a, b]);
            blockBox[a, b].Location = new Point(24 + 56 * b, 100 + 56 * a);
            blockBox[a, b].Size = new Size(50, 50);
            blockBox[a, b].BackColor = Color.Yellow;

            this.Controls.Add(blockBox[a, b]);
            blockBox[a, b].BringToFront();

            map[a, b] = 1;

        }


        //Зависимость цвета от числа на блоке
        private void changeColor(int sum, int a, int b)
        {
            if (sum % 1024 == 0) blockBox[a, b].BackColor = Color.Pink;
            else if (sum % 512 == 0) blockBox[a, b].BackColor = Color.Red;
            else if (sum % 256 == 0) blockBox[a, b].BackColor = Color.DarkViolet;
            else if (sum % 128 == 0) blockBox[a, b].BackColor = Color.Blue;
            else if (sum % 64 == 0) blockBox[a, b].BackColor = Color.Brown;
            else if (sum % 32 == 0) blockBox[a, b].BackColor = Color.Coral;
            else if (sum % 16 == 0) blockBox[a, b].BackColor = Color.Cyan;
            else if (sum % 8 == 0) blockBox[a, b].BackColor = Color.Maroon;
            else blockBox[a, b].BackColor = Color.Green;
        }


        //Перемещение блоков.
        private void keyBEvent(object sender, KeyEventArgs e)
        {

            bool ifBoxMoved = false;

            // перемещается на 56
            switch (e.KeyCode.ToString()) 
            {

                //------//

                case "Right":
                    for (int w = 0; w < 4; w++)
                    {
                        for (int h = 2; h >= 0; h--)
                        {
                            if (map[w, h] == 1)                     //Поиск занятой ячейки.
                            {

                                for (int i = h + 1; i < 4; i++)
                                {

                                    if (map[w, i] == 0)
                                    {

                                        ifBoxMoved = true;

                                        map[w, i] = 1;              //запоминание занятой ячейки.
                                        map[w, i - 1] = 0;          //сброс предыдущей ячейки.

                                        blockBox[w, i] = blockBox[w, i - 1];        //смещение блока.
                                        blockBox[w, i - 1] = null;

                                        numBoxes[w, i] = numBoxes[w, i - 1];
                                        numBoxes[w, i - 1] = null;

                                        blockBox[w, i].Location = new Point(blockBox[w, i].Location.X + 56,
                                                                           blockBox[w, i].Location.Y);
                                    }
                                    else
                                    {

                                        int countA = int.Parse(numBoxes[w, i].Text);                //определение значение соседних блоков
                                        int countB = int.Parse(numBoxes[w, i - 1].Text);

                                        if (countA == countB)                                       //сравнение значений
                                        {

                                            score += (countA + countB);                             //прибавка очков
                                            ScoreCount.Text = "Score: " + score;

                                            changeColor((countA + countB), w, i);                               //замена цвета

                                            numBoxes[w, i].Text = (countA + countB).ToString();     //удваивание значения

                                            map[w, i - 1] = 0;

                                            this.Controls.Remove(blockBox[w, i - 1]);               //Удаление предыдушего блока
                                            this.Controls.Remove(numBoxes[w, i - 1]);               //Удаление числа от прошлого блока

                                            blockBox[w, i - 1] = null;
                                            numBoxes[w, i - 1] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                break;

                //------//

                case "Left":
                    for (int w = 0; w < 4; w++)
                    {
                        for (int h = 1; h < 4; h++)
                        {
                            if (map[w, h] == 1)                     //Поиск занятой ячейки.
                            {

                                for (int i = h - 1; i >= 0; i--)
                                {

                                    if (map[w, i] == 0)
                                    {

                                        ifBoxMoved = true;

                                        map[w, i] = 1;              //запоминание занятой ячейки.
                                        map[w, i + 1] = 0;          //сброс предыдущей ячейки.

                                        blockBox[w, i] = blockBox[w, i + 1];        //смещение блока.
                                        blockBox[w, i + 1] = null;

                                        numBoxes[w, i] = numBoxes[w, i + 1];
                                        numBoxes[w, i + 1] = null;

                                        blockBox[w, i].Location = new Point(blockBox[w, i].Location.X - 56,
                                                                            blockBox[w, i].Location.Y);
                                    } else
                                      {

                                        int countA = int.Parse(numBoxes[w, i].Text);                //определение значение соседних блоков
                                        int countB = int.Parse(numBoxes[w, i + 1].Text);

                                        if (countA == countB)                                       //сравнение значений
                                        {

                                            score += (countA + countB);                             //прибавка очков
                                            ScoreCount.Text = "Score: " + score;

                                            changeColor((countA + countB), w, i);                               //замена цвета

                                            numBoxes[w, i].Text = (countA + countB).ToString();     //удваивание значения

                                            map[w, i + 1] = 0;

                                            this.Controls.Remove(blockBox[w, i + 1]);               //Удаление предыдушего блока
                                            this.Controls.Remove(numBoxes[w, i + 1]);               //Удаление числа от прошлого блока

                                            blockBox[w, i + 1] = null;
                                            numBoxes[w, i + 1] = null;

                                        }
                                    }
                                }
                            }
                        }
                    }
                break;

                //------//

                case "Up":
                    for (int w = 1; w < 4; w++)
                    {
                        for (int h = 0; h < 4; h++)
                        {
                            if (map[w, h] == 1)                     //Поиск занятой ячейки.
                            {

                                for (int i = w - 1; i >= 0; i--)
                                {

                                    if (map[i, h] == 0)
                                    {

                                        ifBoxMoved = true;

                                        map[i, h] = 1;              //запоминание занятой ячейки.
                                        map[i + 1, h] = 0;          //сброс предыдущей ячейки.

                                        blockBox[i, h] = blockBox[i + 1, h];        //смещение блока.
                                        blockBox[i + 1, h] = null;

                                        numBoxes[i, h] = numBoxes[i + 1, h];
                                        numBoxes[i + 1, h] = null;

                                        blockBox[i, h].Location = new Point(blockBox[i, h].Location.X,
                                                                            blockBox[i, h].Location.Y - 56);
                                    }
                                    else
                                    {

                                        int countA = int.Parse(numBoxes[i, h].Text);                //определение значение соседних блоков
                                        int countB = int.Parse(numBoxes[i + 1, h].Text);

                                        if (countA == countB)                                       //сравнение значений
                                        {

                                            score += (countA + countB);                             //прибавка очков
                                            ScoreCount.Text = "Score: " + score;

                                            changeColor((countA + countB), i, h);                               //замена цвета

                                            numBoxes[i, h].Text = (countA + countB).ToString();     //удваивание значения

                                            map[i + 1, h] = 0;

                                            this.Controls.Remove(blockBox[i + 1, h]);               //Удаление предыдушего блока
                                            this.Controls.Remove(numBoxes[i + 1, h]);               //Удаление числа от прошлого блока

                                            blockBox[i + 1, h] = null;
                                            numBoxes[i + 1, h] = null;

                                        }
                                    }
                                }
                            }
                        }
                    }
                break;

                //------//

                case "Down":
                    for (int w = 2; w >= 0; w--)
                    {
                        for (int h = 0; h < 4; h++)
                        {
                            if (map[w, h] == 1)                     //Поиск занятой ячейки.
                            {

                                for (int i = w + 1; i < 4; i++)
                                {

                                    if (map[i, h] == 0)
                                    {

                                        ifBoxMoved = true;

                                        map[i, h] = 1;              //запоминание занятой ячейки.
                                        map[i - 1, h] = 0;          //сброс предыдущей ячейки.

                                        blockBox[i, h] = blockBox[i - 1, h];        //смещение блока.
                                        blockBox[i - 1, h] = null;

                                        numBoxes[i, h] = numBoxes[i - 1, h];
                                        numBoxes[i - 1, h] = null;

                                        blockBox[i, h].Location = new Point(blockBox[i, h].Location.X,
                                                                            blockBox[i, h].Location.Y + 56);
                                    }
                                    else
                                    {

                                        int countA = int.Parse(numBoxes[i, h].Text);                //определение значение соседних блоков
                                        int countB = int.Parse(numBoxes[i - 1, h].Text);

                                        if (countA == countB)                                       //сравнение значений
                                        {

                                            score += (countA + countB);                             //прибавка очков
                                            ScoreCount.Text = "Score: " + score;

                                            changeColor((countA + countB), i, h);                               //замена цвета

                                            numBoxes[i, h].Text = (countA + countB).ToString();     //удваивание значения

                                            map[i - 1, h] = 0;

                                            this.Controls.Remove(blockBox[i - 1, h]);               //Удаление предыдушего блока
                                            this.Controls.Remove(numBoxes[i - 1, h]);               //Удаление числа от прошлого блока

                                            blockBox[i - 1, h] = null;
                                            numBoxes[i - 1, h] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }

            if (ifBoxMoved) { generateBox(); }

        }
    }


}
