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

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"UserFiles.txt");
            
            while ((line = file.ReadLine()) != null)
            {
                Funcionario f = new Funcionario();
                f.fromString(line);
                FuncList.Add(f);
                Funcionários.Items.Add(f.getName() + "                                              ID:" + f.getID());
            }

            file.Close();
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
                if (SalaryBox.TextLength <= 3) {
                    SalaryBox.Text = "R$ ";
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
            func.setAll(NameBox.Text, AgeBox.Text, JobBox.Text, SalaryBox.Text, EmailBox.Text, NumBox.Text, TelBox.Text, BloodBox.Text, Convert.ToString(FilhoBox.Value), EstCivBox.Text, CEPBox.Text, EnderBox.Text, sex);
            validBox(NameBox.Text, AgeBox.Text, JobBox.Text, SalaryBox.Text, EmailBox.Text, NumBox.Text, TelBox.Text, BloodBox.Text, Convert.ToString(FilhoBox.Value), EstCivBox.Text, CEPBox.Text, EnderBox.Text, sex);
                  
            if (func.getAllSet()) {
                label30.Text = "";
                FuncList.Add(func);
                func.genID();
                func.saveText();
                Funcionários.Items.Add(func.getName() + "                                              ID:" + func.getID());
            } else { 
                func = null;
                MessageBox.Show("Alguns campos de entrada são inválidos!");
            }
        }

        //Função para escolha de 
        private void Funcionários_SelectedIndexChanged(object sender, EventArgs e)
        {
            Excluir.Enabled = true;
        }


        //Função para deletar informações de usuário
        public void deleteUser(string userID)
        {
            string[] user = userID.Split(':');
            string ID = user[user.Length - 1];
            string line;

            System.IO.StreamReader reader = new System.IO.StreamReader(@"UserFiles.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"TempFiles.txt");

            while ((line = reader.ReadLine()) != null) {
                //string line = reader.ReadLine();
                if (!line.Contains("ID:" + ID)) {
                    writer.WriteLine(line);
                }
            }

            reader.Close();
            writer.Close();

            if (File.Exists(@"TempFiles.txt"))
            {
                File.Delete(@"UserFiles.txt");
                File.Move(@"TempFiles.txt", @"UserFiles.txt");
            }

        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            deleteUser(Convert.ToString(Funcionários.SelectedItem));
            Funcionários.Items.Remove(Funcionários.SelectedItem);
        }
    }
}