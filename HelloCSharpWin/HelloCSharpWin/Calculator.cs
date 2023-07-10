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
            Button numButton = (Button)sender; //sender는 오브잭트 객체라서 형변환 필요 sender 앞에 Button를 적어 형변환 후 왼쪽 값에 넣어준다.
            SetNum(numButton.Text); //밑에 SetNum에서 호출 받음 
        }

        public void SetNum(string num) // 문자열로 매개변수인 num 값을 받는다.
        {
            if (isNewNum)
            {
                NumScreen.Text = num; //NumScreen.Text의 값이 num 일 경우 
                isNewNum = false;   // flase 출력 (새로운 값이 아니기 때문임)
            }
            else if (NumScreen.Text == "0")  //스크린 상의 0일 경우는
            {
                NumScreen.Text = num;  // num 매개변수 출력이 됨
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }

        private void NumPlus_Click(object sender, EventArgs e) // +버튼을 클릭 했을때
        {
            if (isNewNum == false)
            {
                int num = int.Parse(NumScreen.Text);  //string 문자열인 것을 정수 int로 변경해주는 Parse 사용해서 정수형으로 바꾼다.
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

