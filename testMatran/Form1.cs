using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testMatran
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            //Mức độ trung bình
             "!", "!", "N", "N", ",", ",", "k", "k", "b",
            "b", "v", "v", "w", "w", "z", "z", "@", "@", "#", "#", "$", "$", "%", "%",
            "^", "^", "&", "&", "*", "*", "u", "u", "a", "a", "r", "r", "q", "q", "e", "e"
        };
        Button buttonClicked, buttonClicked2;
        int n;
        int[] arr1;


        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            n = int.Parse(textBox1.Text);

            arr1 = new int[n];

            Random rd1 = new Random();
            int a = 0;
            while( a < n)
            {
                int x  = rd1.Next(1, n+1);   
                if(chuaXuatHienX(arr1, a, x))
                {
                    arr1[a++] = x;
                }
            }


            for (int i =0; i < n; i++)
            {
                flowLayoutPanel1.Controls.Add(btn(i));
            }    
        }

        private static bool chuaXuatHienX(int[] arr1, int size, int x)
        {
            for (int i = 0; i < size; i++)
            {
                if (arr1[i] == x)
                {
                    return false;
                }
            }
            return true;
        }



        private void btn_Click(object sender, EventArgs e)
        {
            if (buttonClicked != null && buttonClicked2 != null)
                return;

            Button clickerLabel = sender as Button;

            if (clickerLabel == null)
                return;
            if (clickerLabel.ForeColor == Color.Black)
                return;
            if (buttonClicked == null)
            {
                buttonClicked = clickerLabel;
                buttonClicked.ForeColor = Color.Black;
                return;
            }
            buttonClicked2 = clickerLabel;
            buttonClicked2.ForeColor = Color.Black;


            if (buttonClicked.Text == buttonClicked2.Text)
            {
                buttonClicked = null;
                buttonClicked2 = null;
            }
            else
                timer1.Start();

        }
        
        
        Button btn(int i)
        {
            
            List<string> list = new List<string>();
            Button b = new Button();
            b.Name = Numrd.ToString();
            b.Width = 62;
            b.Height = 62;
            b.Text = icons[i];

            b.Click +=  new System.EventHandler(this.btn_Click);
            return b;
        }



        //Game play

        private void CheckForWiner()
        {
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                Label label;
                label = flowLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("You win!", "Thông báo");
            // Close();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            buttonClicked.ForeColor = buttonClicked.BackColor;
            buttonClicked2.ForeColor = buttonClicked2.BackColor;

            buttonClicked = null;
            buttonClicked2 = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                return;
            }
            else
            {

            int tbValue = Convert.ToInt32(textBox1.Text);
            
            if (tbValue % 2 != 0)
            {
                MessageBox.Show("Số ô là lẻ không thể chơi (Cần nhập số chẵn)", "Hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                return;
            }
            if (tbValue > 40 )
            {
                MessageBox.Show("Vượt quá giới hạn 40 ô", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbValue == 0)
                {
                    MessageBox.Show("Số phần tử phải nguyên dương", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        //Hàm gán biển tượng cho các ô vuông
        /*
        private void AssignIconsToSquares()
        {
            //Tạo biến ngẫu nhiên để lưu trữ tạm thời
            Button label;
            //Biến chứa số ngẫu nhiên để gán biểu tượng vào ô có số thứ tự đó
            int randomNumber;

            for (int i = 0; i < n; i++)
            {
                if (flowLayoutPanel1.Controls[i] is Button)
                {
                    label = (Button)flowLayoutPanel1.Controls[i];
                }

                else
                    continue;
                //Nhận 1 số ngẫu nhiên
                randomNumber = random.Next(0, icons.Count);
                //icon có thứ tự là số ngẫu nhiên đó sẽ được gán cho label
                label.Text = icons[randomNumber];
                //Xóa số ngẫu nhiên khỏi danh sách icon
                icons.RemoveAt(randomNumber);
            }
        }*/



    }
}
