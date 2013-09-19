using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;

namespace SlXnaApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        DispatcherTimer timer;
        String[] abc = new string[26];
        public MainPage()
        {
            InitializeComponent();
            abcd();
        }

        // Simple button Click event handler to take us to the second page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
        }

        private void St(object sender, RoutedEventArgs x)
        {

            Random r = new Random();
           int a = r.Next(0, 25);
             

            int i = 1;
            string st = "tb" + i + "1";
            string stj = "tb" + "2" + i;
            string stk = "tb" + "3"+ i;
            string stl = "tb" + "4" + i;
            string stm = "tb" + "5" + i;
            string stn = "tb" + "6" + i;


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(.150);
            timer.Tick += (s, e) =>
            {

                var con = this.FindName(st);
                var con1 = this.FindName(stj);
                var con2 = this.FindName(stk);
                var con3 = this.FindName(stl);
                var con4 = this.FindName(stm);
                var con5 = this.FindName(stn);
                int a1 = r.Next(0, 25);
                int a2 = r.Next(0, 25);
                int a3 = r.Next(0, 25);
                int a4 = r.Next(0, 25);
                int a5 = r.Next(0, 25);
                int a6 = r.Next(0, 25);
                if (con != null)
                {
                    

                    TextBlock tb = (TextBlock)con;
                    tb.Text = abc[a1];
                    TextBlock tb1 = (TextBlock)con1;
                    tb1.Text = abc[a2];
                    TextBlock tb2 = (TextBlock)con2;
                    tb2.Text = abc[a3];
                    TextBlock tb3 = (TextBlock)con3;
                    tb3.Text = abc[a4];
                    TextBlock tb4 = (TextBlock)con4;
                    tb4.Text = abc[a5];
                    TextBlock tb5 = (TextBlock)con5;
                    tb5.Text = abc[a6];
                    // Whatever
                }

                if (i < 6)
                {
                    i++;
               
                }
                else
                {
                    i = 1;

                }
                st = "tb" + i + "1";
                stj = "tb" + "2" + i;
                stk = "tb" + "3" + i;
                stl = "tb" + "4" + i;
                stm = "tb" + "5" + i;
                stn = "tb" + "6" + i;
                //Code that will be called after each second

            };

            timer.Start();
        }


        public void abcd()
        {
            abc[0] = "A";
            abc[1] = "B";
            abc[2] = "C";
            abc[3] = "D";
            abc[4] = "E";
            abc[5] = "F";
            abc[6] = "G";
            abc[7] = "H";
            abc[8] = "I";
            abc[9] = "J";
            abc[10] = "K";
            abc[11] = "L";
            abc[12] = "M";
            abc[13] = "N";
            abc[14] = "O";
            abc[15] = "P";
            abc[16] = "Q";
            abc[17] = "R";
            abc[18] = "S";
            abc[19] = "T";
            abc[20] = "U";
            abc[21] = "V";
            abc[22] = "W";
            abc[23] = "X";
            abc[24] = "Y";
            abc[25] = "Z";
        }
    }
}