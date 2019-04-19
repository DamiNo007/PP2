using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALCULATOR_PRO
{
    public partial class Form1 : Form
    {
        Calculator calc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calc = new Calculator(new ChangeTextDelegate(ChangeText));
            textBox1.Size = new Size(219, 50);
            int x = textBox1.Location.X-9;
            int y = 55;
            int k = 0;
            int n = 0;
            int sz = 55;
            int d = 8; // Расстояние между кнопками
            for(int i =0; i<7; i++)
            {
                for(int j=0; j<4; j++)
                {
                    k++;
                    Button btn = new Button();

                    if (j==3 || i==0 || i==1||i==2 || i==6)
                    {
                        btn.Font = new Font("Microsoft Sans Serif", 10F);
                        btn.Text = BtnText(k);
                    }
                        
                    else
                    {
                        btn.Font = new Font("Microsoft Sans Serif", 20F);
                        n++;
                        btn.Text = n.ToString();
                    }
                    
                    btn.Size = new Size(sz, sz-10);
                    btn.Location = new Point(j * sz + x + d, i * (sz-10) + y + d);
                    btn.Click += Btn_Clicked;
                    Controls.Add(btn);
                }
            }       
        }

            
            public void ChangeText(string text)
            {
                textBox1.Text = text;
            }

            public String BtnText(int k)
            {
                if (k == 1)
                    return "MS";
                if (k == 2)
                    return "MR";
                if (k == 3)
                    return "M+";
                if (k == 4)
                    return "M-";
                if (k == 5)
                    return "%";
                if (k == 6)
                    return "sqrt";
                if (k == 7)
                    return "x^2";
                if (k == 8)
                    return "1/x";
                if (k == 9)
                    return "CE";
                if (k == 10)
                    return "C";
                if (k == 11)
                    return "<-";
                if (k == 12)
                    return "/";
                if (k == 16)
                    return "*";
                if (k == 20)
                    return "-";
                if (k == 24)
                    return "+";
                if (k == 25)
                    return "+/-";
                if (k == 26)
                    return "0";
                if (k == 27)
                    return ",";
                if (k == 28)
                    return "=";

                return "";
            }

        public void Btn_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.Process(btn.Text);
        }
    }
}
