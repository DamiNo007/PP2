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
        public bool isempty=true;
        public char sign;
        public int k = 1;

        CalcBase calc;
        
        public Form1()
        {            
            InitializeComponent();
            calc = new CalcBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            int x = 65;
            int y = 50;
            textBox1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            textBox1.Location = new Point(10, 2);
            textBox1.Size = new Size(255, 50);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button();
                    if (i == 0 && j == 0)
                    {
                        btn.Text = "MS";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(specific_function_Click);
                        btn.BackColor = Color.LightCoral;
                    }

                    else if (i == 0 && j == 1)
                    {
                        btn.Text = "MR";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(specific_function_Click);
                        btn.BackColor = Color.LightCoral;
                    }

                    else if (i == 0 && j == 2)
                    {
                        btn.Text = "M+";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(specific_function_Click);
                        btn.BackColor = Color.LightCoral;

                    }
                    else if (i == 0 && j == 3)
                    {
                        btn.Text = "M-";
                        Controls.Add(btn);
                        btn.BackColor = Color.LightCoral;
                    }

                    else if(i==1 && j == 0)
                    {
                        btn.Text = "%";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightGray;
                    }
                    else if (i == 1 && j == 1)
                    {
                        btn.Text = "sqrt";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightGray;

                    }
                    else if (i == 1 && j == 2)
                    {
                        btn.Text = "x^2";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightGray;
                    }

                    else if (i == 1 && j == 3)
                    {
                        btn.Text = "1/x";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightGray;
                    }

                    else if(i==2 && j==0)
                    {
                        btn.Text = "CE";
                        Controls.Add(btn);
                        btn.BackColor = Color.LightGray;
                    }

                    else if (i==2 && j == 1)
                    {
                        btn.Text = "C";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(specific_function_Click);
                        btn.BackColor = Color.LightGray;
                    }

                    else if(i==2 && j == 2)
                    {
                        btn.Text = "<-";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(specific_function_Click);
                        btn.BackColor = Color.LightGray;
                    }
                    else if(i==2 && j == 3)
                    {
                        btn.Text = "/";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightYellow;
                    }


                    else if(j==3 && i == 3)
                    {
                        btn.Text = "x";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightYellow;
                    }
                    else if(j==3 && i == 4)
                    {
                        btn.Text = "-";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightYellow;

                    }
                    else if(j==3 && i == 5)
                    {
                        btn.Text = "+";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(operation_Click);
                        btn.BackColor = Color.LightYellow;
                    }
                    else if(j==3 && i==6)
                    {
                        btn.Text = "=";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(result_Click);
                        btn.BackColor = Color.LightYellow;
                    }
                    else if(i==6 && j == 0)
                    {
                        btn.Text = "+/-";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(specific_function_Click);
                    }
                    else if(i==6 && j == 1)
                    {
                        btn.Text = "0";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(number_Click);
                    }
                    else if(i==6 && j == 2)
                    {
                        btn.Text = ",";
                        Controls.Add(btn);
                        btn.Click += new System.EventHandler(number_Click);
                    }
                    else
                    {
                        btn.Text = k.ToString();
                        btn.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                        Controls.Add(btn);
                        k++;
                        btn.Click += new System.EventHandler(number_Click);
                    }


                    btn.Size = new Size(60, 45);
                    btn.Location = new Point(10 + x * j, 60 + y * i);
                    Controls.Add(btn);
                 }
            }    
        }


        private void number_Click(object sender, EventArgs e)
        { 
            if(!isempty)
            {
                textBox1.Clear();
                isempty = true;
            }
            Button btn = sender as Button;
            textBox1.Text += btn.Text;
        }

        public void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.first_number = float.Parse(textBox1.Text);
            if (btn.Text == "x^2" || btn.Text=="sqrt")
            {
                calc.operation = btn.Text;
                calc.Calculate();
                textBox1.Text = calc.result + "";
            }

            else
            {
                calc.operation = btn.Text;
                textBox1.Text += btn.Text;
            }
            
            isempty = false;
        }

        public void specific_function_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "<-")
            {
                if (textBox1.Text.Length == 1)
                    textBox1.Text = "0";
                else
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                isempty = false;
            }
            else if(btn.Text=="MS")
            {
                calc.memory.Add(float.Parse(textBox1.Text));
            }
            else if(btn.Text=="MR")
            {
                calc.memory_add=float.Parse(textBox1.Text);
                textBox1.Clear();
                calc.Calculate();
                textBox1.Text = calc.memory[calc.memory.Count - 1].ToString();
            }

            else if (btn.Text == "M+")
            {
                textBox1.Clear();
                calc.operation = "M+";         
            }
            else if (btn.Text == "C")
            {
                calc = new CalcBase();
                textBox1.Text = calc.first_number.ToString();
                isempty=false;
            }
            else if (btn.Text == "+/-")
            {
                textBox1.Text = ((-1) * (float.Parse(textBox1.Text))).ToString();
            }
            
        }

        public void result_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.second_number = float.Parse(textBox1.Text);
            textBox1.Clear();
            calc.Calculate();
            textBox1.Text = calc.result+"";
            isempty = false;
        }
    }
}
