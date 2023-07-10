using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HelloCSharpWin
{
    public enum Oparators { Add, Sub, Multi, Div }
    public partial class Calculator : Form
    {
        public int Result = 0;
        public bool isNewNum = true;
        public Oparators Opt = Oparators.Add;


        public Calculator()
        {
            InitializeComponent();
        }

        private void NumButton1_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender; //sender�� ������Ʈ ��ü�� ����ȯ �ʿ� sender �տ� Button�� ���� ����ȯ �� ���� ���� �־��ش�.
            SetNum(numButton.Text); //�ؿ� SetNum���� ȣ�� ���� 
        }

        public void SetNum(string num) // ���ڿ��� �Ű������� num ���� �޴´�.
        {
            if (isNewNum)
            {
                NumScreen.Text = num; //NumScreen.Text�� ���� num �� ��� 
                isNewNum = false;   // flase ��� (���ο� ���� �ƴϱ� ������)
            }
            else if (NumScreen.Text == "0")  //��ũ�� ���� 0�� ����
            {
                NumScreen.Text = num;  // num �Ű����� ����� ��
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }

        private void NumPlus_Click(object sender, EventArgs e) // +��ư�� Ŭ�� ������
        {
            if (isNewNum == false)
            {
                int num = int.Parse(NumScreen.Text);  //string ���ڿ��� ���� ���� int�� �������ִ� Parse ����ؼ� ���������� �ٲ۴�.
                if (Opt == Oparators.Add)
                    Result = Result + num;
                else if (Opt == Oparators.Sub)
                    Result = Result - num;

                NumScreen.Text = Result.ToString();
                isNewNum = true;
            }

            Button optButton = (Button)sender;
            if (optButton.Text == "+")
                Opt = Oparators.Add;
            else if (optButton.Text == "-")     
                Opt = Oparators.Sub;
        }

        private void NumClear_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Oparators.Add;

            NumScreen.Text = "0";
        }
    }
}

