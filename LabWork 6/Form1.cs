using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWork_6_PascalTriangleEncryptionWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Выводим треугольник Паскаля 

            int level = Convert.ToInt32(textBox4.Text);
            textBox5.Text += level;
            int[][] triangle = new int[level][];
            triangle[0] = new int[] { 1 };
            for (int i = 1; i < triangle.Length; i++)
            {
                triangle[i] = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        triangle[i][j] = 1;
                    else
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
            }

            //Шифрование рус

            string alph = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZабвгдежзийклмнопрстуфхцчшщъыьэюяабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            char[] charAlph = alph.ToCharArray();
            char[] symbolsInText = { ',', '?', '!', '_' };
            string text = Convert.ToString(textBox1.Text);
            textBox3.Text += text;
            char[] charText = text.ToCharArray();
            string[] theWords = text.Split(' ');
            char[] newCharArray = new char [text.Length];
            for(int i = 0;i<charText.Length;i++)
            {
                for(int j = 0;j<symbolsInText.Length;j++)
                {
                    for(int h = 0;h<newCharArray.Length;h++)
                    {
                        if (charText[i] == symbolsInText[j])
                        {
                            newCharArray[h] += charText[i];
                        }
                    }
                }
            }
            




            for (int x = 0; x < theWords.Length; x++)
            {
                char[] word = theWords[x].ToCharArray();
                int rowIndex = word.Length - 1;
                int[] triangleRow = triangle[rowIndex];
                for (int y = 0; y < word.Length; y++)
                {
                    for (int i = 0; i < alph.Length; i++)
                    {
                        if (alph[i] == word[y])
                        {
                            int newSymbolIndex = (i + triangleRow[y]) % alph.Length;
                            char newSymbol = alph[newSymbolIndex];
                            word[y] = newSymbol;
                            break;
                        }
                    }
                }
                string charsStr = new string(word);
                theWords[x] = charsStr;
                for(int h = 0;h<newCharArray.Length;h++)
                {
                    textBox2.Text = textBox2.Text + theWords[x + h];
                    break;
                    
                }
                
            }




            //Дешифрование рус


            for (int x = 0; x < theWords.Length; x++)
            {
                char[] word = theWords[x].ToCharArray();
                int rowIndex = word.Length - 1;
                int[] triangleRow = triangle[rowIndex];
                for (int y = 0; y < word.Length; y++)
                {
                    for (int i = 0; i < alph.Length; i++)
                    {
                        if (alph[i] == word[y])
                        {
                            int newSymbolIndex = (i - triangleRow[y]) % alph.Length;
                            char newSymbol = alph[newSymbolIndex];
                            word[y] = newSymbol;
                            break;
                        }
                    }




                }
                string charsStr = new string(word);
                theWords[x] = charsStr;
                //textBox3.Text = textBox3.Text + theWords[x];
            }




            //Шифрование англ

            /*string alph2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] charAlph2 = alph.ToCharArray();
            for (int x = 0; x < theWords.Length; x++)
            {
                char[] word = theWords[x].ToCharArray();
                int rowIndex = word.Length - 1;
                int[] triangleRow = triangle[rowIndex];
                for (int y = 0; y < word.Length; y++)
                {
                    for (int i = 0; i < alph2.Length; i++)
                    {
                        if (alph2[i] == word[y])
                        {
                            int newSymbolIndex = (i + triangleRow[y]) % alph.Length;
                            char newSymbol = alph[newSymbolIndex];
                            word[y] = newSymbol;
                            break;
                        }
                    }




                }
                string charsStr = new string(word);
                theWords[x] = charsStr;
                textBox2.Text = textBox2.Text + " " + theWords[x] + " ";

            }*/

           
        }
        
        //Чистим форму
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

    }   } 



   

