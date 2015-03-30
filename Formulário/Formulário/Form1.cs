using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Formulário
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Funcionario> FuncList = new List<Funcionario>();
        

        //Checar sexo
        string sex;

        //Funções para alteração da imagem do cadastro

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Formulário.Properties.Resources.Icon_maleAvatar;
            sex = "Masculino";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Formulário.Properties.Resources.Icon_femaleAvatar;
            sex = "Feminino";
        }

        //Função de alteração do salário

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) {
                if (textBox4.TextLength <= 3) {
                    textBox4.Text = "R$ ";
                }
            }
        }

        //Função de aviso de campos inválidos

        private void validBox(string name, string age, string job, string salary, string email, string num, string tel, string blood, string filho, string estCiv, string CEP, string ender, string sex)
        {
            if (name != "")
            {
                label18.Text = "";
            }
            else
            {
                label18.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (age != "")
            {
                label20.Text = "";
            }
            else
            {
                label20.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (job != "")
            {
                label19.Text = "";
            }
            else
            {
                label19.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (salary != "R$ ")
            {
                label22.Text = "";
            }
            else
            {
                label22.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (email != "")
            {
                label21.Text = "";
            }
            else
            {
                label21.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (num != "")
            {
                label28.Text = "";
            }
            else
            {
                label28.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if ((tel.Length >= 14) && (tel.Length <= 15))
            {
                label24.Text = "";
            }
            else
            {
                label24.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (blood != "")
            {
                label23.Text = "";
            }
            else
            {
                label23.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (estCiv != "")
            {
                label25.Text = "";
            }
            else
            {
                label25.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (CEP.Length == 9)
            {
                label29.Text = "";
            }
            else
            {
                label29.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (ender.Length >= 4)
            {
                label27.Text = "";
            }
            else
            {
                label27.Text = "*";
                label30.Text = "* Campo Inválido";
            }

            if (sex != null)
            {
                label26.Text = "";
            }
            else
            {
                label26.Text = "*";
                label30.Text = "* Campo Inválido";
            }
        }

        //Função do Botão de adicionar

        private void button3_Click(object sender, EventArgs e)
        {
            Funcionario func = new Funcionario();
            func.setAll(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox8.Text, textBox5.Text, comboBox1.Text, Convert.ToString(numericUpDown1.Value), comboBox2.Text, textBox9.Text, textBox7.Text, sex);
            
            if (func.getAllSet()) {
                label30.Text = "";
                FuncList.Add(func);
                func.saveText();
                listBox1.Items.Add(func.name);
            } else { 
                func = null;
                MessageBox.Show("Alguns campos de entrada são inválidos!");
                validBox(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox8.Text, textBox5.Text, comboBox1.Text, Convert.ToString(numericUpDown1.Value), comboBox2.Text, textBox9.Text, textBox7.Text, sex);
            }
        }
    }
}