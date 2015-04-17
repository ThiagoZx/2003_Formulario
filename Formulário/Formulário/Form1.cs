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

        private void Unfocus_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Formulário.Properties.Resources.Icon_x;
            sex = null;
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

        //Função para escolha de usuarios
        private void Funcionários_SelectedIndexChanged(object sender, EventArgs e)
        {
            Excluir.Enabled = true;
            Editar.Enabled = true;

            if (Funcionários.Items.Count == 0) {
                Excluir.Enabled = false;
                Editar.Enabled = false;
            }

        }

        //Função para limpar caixas de texto
        private void clearAll() 
        {
            NameBox.Text = null;
            AgeBox.Text = null;
            JobBox.Text = null;
            SalaryBox.Text = "R$ ";
            EmailBox.Text = null;
            TelBox.Text = null;
            BloodBox.Text = null;
            FilhoBox.Text = "0";
            EstCivBox.Text = null;
            CEPBox.Text = null;
            EnderBox.Text = null;
            NumBox.Text = null;
            sex = null;
            pictureBox1.Image = Formulário.Properties.Resources.Icon_x;
            Unfocus.Focus();
        }

        //Funções para alterar os dados de um usuário
        public void toTextBox(string data)
        {
            string[] info = data.Split('#');
            NameBox.Text = info[0];
            AgeBox.Text = info[1];
            JobBox.Text = info[2];
            SalaryBox.Text = info[3];
            EmailBox.Text = info[4];
            TelBox.Text = info[5];
            BloodBox.Text = info[6];
            FilhoBox.Text = info[7];
            EstCivBox.Text = info[8];
            CEPBox.Text = info[9];
            EnderBox.Text = info[10];
            NumBox.Text = info[11];
            sex = info[12];
            if (sex == "Masculino")
            {
                MaleButton.Focus();
            }
            else 
            {
                FemaleButton.Focus();
            }
        }

        private void selectUser(string userID) 
        {
            string[] user = userID.Split(':');
            string ID = user[user.Length - 1];
            string line;

            System.IO.StreamReader reader = new System.IO.StreamReader(@"UserFiles.txt");

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("ID:" + ID))
                {
                    toTextBox(line);
                }
            }

            reader.Close();
        }

        private void saveChange(string userData, int ID) 
        {
            string line;

            System.IO.StreamReader reader = new System.IO.StreamReader(@"UserFiles.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"TempFiles.txt");

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("ID:" + ID))
                {
                    writer.WriteLine(userData);
                }
                else 
                {
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

        //Função para deletar informações de usuário
        private void deleteUser(string userID)
        {
            string[] user = userID.Split(':');
            string ID = user[user.Length - 1];
            string line;

            System.IO.StreamReader reader = new System.IO.StreamReader(@"UserFiles.txt");
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"TempFiles.txt");

            while ((line = reader.ReadLine()) != null) {
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

        //Função do Botão de adicionar
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Adicionar") 
            {
                Funcionario func = new Funcionario();
                func.setAll(NameBox.Text, AgeBox.Text, JobBox.Text, SalaryBox.Text, EmailBox.Text, NumBox.Text, TelBox.Text, BloodBox.Text, Convert.ToString(FilhoBox.Value), EstCivBox.Text, CEPBox.Text, EnderBox.Text, sex);
                validBox(NameBox.Text, AgeBox.Text, JobBox.Text, SalaryBox.Text, EmailBox.Text, NumBox.Text, TelBox.Text, BloodBox.Text, Convert.ToString(FilhoBox.Value), EstCivBox.Text, CEPBox.Text, EnderBox.Text, sex);

                if (func.getAllSet())
                {
                    label30.Text = "";
                    FuncList.Add(func);
                    func.genID();
                    func.saveText();
                    Funcionários.Items.Add(func.getName() + "                                              ID:" + func.getID());
                    clearAll();
                }
                else
                {
                    func = null;
                    MessageBox.Show("Alguns campos de entrada são inválidos!");
                }
            }
            else if (button3.Text == "Salvar") 
            {
                string[] user = Convert.ToString(Funcionários.SelectedItem).Split(':');
                int ID = Convert.ToInt32(user[user.Length - 1]);

                foreach(Funcionario f in FuncList ) {
                    int fID = f.getID();
                    if (fID == ID) 
                    {
                        f.setAll(NameBox.Text, AgeBox.Text, JobBox.Text, SalaryBox.Text, EmailBox.Text, NumBox.Text, TelBox.Text, BloodBox.Text, Convert.ToString(FilhoBox.Value), EstCivBox.Text, CEPBox.Text, EnderBox.Text, sex);
                        validBox(NameBox.Text, AgeBox.Text, JobBox.Text, SalaryBox.Text, EmailBox.Text, NumBox.Text, TelBox.Text, BloodBox.Text, Convert.ToString(FilhoBox.Value), EstCivBox.Text, CEPBox.Text, EnderBox.Text, sex);

                        if (f.getAllSet())
                        {
                            label30.Text = "";
                            string data = f.asString(true);
                            saveChange(data, f.getID());
                            button3.Text = "Adicionar";
                            Editar.Text = "Editar";
                            Editar.Enabled = false;
                            Funcionários.Enabled = true;
                            clearAll();
                        }
                        else
                        {
                            MessageBox.Show("Alguns campos de entrada são inválidos!");
                        }
                    }
                }
            }
            
        }

        //Função do Botão excluir
        private void Excluir_Click(object sender, EventArgs e)
        {
            deleteUser(Convert.ToString(Funcionários.SelectedItem));
            Funcionários.Items.Remove(Funcionários.SelectedItem);
            Excluir.Enabled = false;
        }

        //Função do botão editar
        private void Editar_Click(object sender, EventArgs e)
        {
            
            if (Editar.Text == "Editar") {
                button3.Text = "Salvar";
                Editar.Text = "Cancelar";
                Excluir.Enabled = false;
                selectUser(Convert.ToString(Funcionários.SelectedItem));
                Funcionários.Enabled = false;
            }
            else if (Editar.Text == "Cancelar") {
                button3.Text = "Adicionar";
                Editar.Text = "Editar";
                Editar.Enabled = false;
                Funcionários.Enabled = true;
                clearAll();
            }
        }

        //Mask para o CEP
        private void CEPBox_TextChanged(object sender, EventArgs e) {
            if (!(CEPBox.Text.Contains("-"))) {
                if (CEPBox.Text.Length == 8) CEPBox.Text = CEPBox.Text.Insert(5, "-");             
            }
        }

        //Função que limita a números
        public void NumbersOnly(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}