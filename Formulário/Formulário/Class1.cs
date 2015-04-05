using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Formulário
{
    class Funcionario
    {
        //Vericação de todas as informações
        private bool allSet = true;
        public bool getAllSet() {
            return allSet;
        }

        //Função para geração de ID
        public void genID() {

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"UserFiles.txt");
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                string[] data = line.Split(':');
                this.ID = Convert.ToInt32(data[1]) + 1;
            }

            file.Close();

        }

        public string getName() {
            return this.name;
        }

        public int getID() {
            return this.ID;
        }

        //Informações pessoais do usuário
        private string name;
        private int age;
        private string job;
        private string salary;
        private string email;
        private string tel;
        private string blood;
        private int filho;
        private string estCiv;
        private string CEP;
        private string ender;
        private int num;
        private string sex;
        private int ID;

        //Função de envio para o banco de dados
        public string asString()
        {
            return name + "#" + age + "#" + job + "#" + salary + "#" + email + "#" + tel + "#"+ blood + "#" + filho + "#" + estCiv + "#" + CEP + "#" + ender + "#" + num + "#" + sex + "#" + "ID:" + ID + "\r\n";
        }

        //Função para recuperação do banco de dados 
        public void fromString(string data) 
        {
            string[] info = data.Split('#');
            name = info[0];
            age = Convert.ToInt32(info[1]);
            job = info[2];
            salary = info[3];
            email = info[4];
            tel = info[5];
            blood = info[6];
            filho = Convert.ToInt32(info[7]);
            estCiv = info[8];
            CEP = info[9];
            ender = info[10];
            num = Convert.ToInt32(info[11]);
            sex = info[12];
            string[] splitID = info[13].Split(':');
            ID = Convert.ToInt32(splitID[1]);
        }

        //Função de verificação de dados e envio para a classe
        public void setAll(string name, string age, string job, string salary, string email, string num,
                           string tel, string blood, string filho, string estCiv, string CEP, string ender, string sex)
        {
            if (name == "") {
                allSet = false;
            } else {
                this.name = name; 
            }
            
            if (age == "") {
                allSet = false;
            } else {
                this.age = Convert.ToInt32(age);
            }

            if (job == "") {
                allSet = false;
            } else {
                this.job = job;
            }

            if (salary == "R$ ") {
                allSet = false;
            } else {
                this.salary = salary;
            }

            if (email == "") {
                allSet = false;
            } else {
                this.email = email;
            }

            if (num == "") {
                allSet = false;
            } else { 
                this.num = Convert.ToInt32(num);
            }

            if ((tel.Length < 14) || (tel.Length > 15)) {
                allSet = false;
            } else {
                this.tel = tel;
            }

            if (blood == "") {
                allSet = false;
            } else {
                this.blood = blood;
            }
            
            this.filho = Convert.ToInt32(filho);
           
            if (estCiv == "") {
                allSet = false;
            } else {
                this.estCiv = estCiv;
            }

            if (CEP.Length < 9) {
                allSet = false;
            } else {
                this.CEP = CEP;
            }

            if (ender.Length <= 4) {
                allSet = false;
            } else {
                this.ender = ender;
            }

            if (sex == null) {
                allSet = false;
            } else {
                this.sex = sex;
            }
        }

        //Função para salvar informações no banco de dados
        public void saveText() 
        {
            string save = asString();
            System.IO.File.AppendAllText(@"UserFiles.txt", save);
        }
    }
}