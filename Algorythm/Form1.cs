using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Algorythm
{
    public partial class Form1 : Form
    {

        int k;
        int n;
        int m;
        char[] A;
        int[] C;
        char ch;
        string st, str;
        char[] AA;
        int[] CC;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            n = int.Parse(textBox1.Text);
            A = new char[n];
            C = new int[n];
            for (int i = 0; i < n; i++)
            {
                A[i] = (char)(65 + i);
                C[i] = 0;
            }
            listBox1.Items.Clear();
        //algoritm perestanovki
        L1:;//metka
            st = "";
            for (int i = 0; i < n; i++) st = st + " " + A[i];
            listBox1.Items.Add(st);
            //
            k = n - 2;
        //nachalo perestanovki
        L2:;
            C[k]++;
            ch = A[k];
            for (int i = k; i < n - 1; i++) A[i] = A[i + 1];
            A[n - 1] = ch;
            if (C[k] <= n - 1 - k) goto L1;
            C[k] = 0;
            k--;
            if (k >= 0) goto L2;
            stopwatch.Stop();
            textBox3.Text = Convert.ToString(stopwatch.ElapsedMilliseconds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            m = int.Parse(textBox2.Text);
            A = new char[n];
            C = new int[m];
            for (int i = 0; i < n; i++) A[i] = (char)(i + 65);
            listBox1.Items.Clear();
            C[0] = 0;
            k = 0;
        //algoritm sochetanii
        L1:;
            for (int i = k + 1; i < m; i++) C[i] = C[i - 1] + 1;
            st = "";
            for (int i = 0; i < m; i++) st = st + "  " + A[C[i]];
            listBox1.Items.Add(st);
            //
            k = m - 1;
        //nachalo sochetanii
        L2:;
            C[k]++;
            if (C[k] <= n - m + k) goto L1;
            k--;
            if (k >= 0) goto L2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            m = int.Parse(textBox2.Text);
            AA = new char[n];
            CC = new int[m];
            A = new char[m];
            C = new int[m];
            listBox1.Items.Clear();
            for (int i = 0; i < n; i++) AA[i] = (char)(65 + i);
            CC[0] = 0;
            k = 0;
        //algoritm razmeshenii
        LL1:;
            for (int i = k + 1; i < m; i++) CC[i] = CC[i - 1] + 1;

            //------------алгоритм перестановок----------------------------------//
            for (int i = 0; i < m; i++)
            {
                A[i] = AA[CC[i]];
                C[i] = 0;
            }
        L1:;//metka
            st = "";
            for (int i = 0; i < m; i++) st = st + " " + A[i];
            listBox1.Items.Add(st);
        //
        //nachalo perestanovki
        L2:;
            C[k]++;
            ch = A[k];
            for (int i = k; i < m - 1; i++) A[i] = A[i + 1];
            A[m - 1] = ch;
            if (C[k] <= m - 1 - k) goto L1;
            C[k] = 0;
            k--;
            if (k >= 0) goto L2;
            //koneц

            //-------------------------------------------------------------------//
            k = m - 1;
        LL2:;
            CC[k]++;
            if (CC[k] <= n - m + k) goto LL1;
            k--;
            if (k >= 0) goto LL2;
            for (int i = 0; i < n; i++) AA[i] = (char)(65 + i);
        }

        public class Permutations
        {

            private List<string> _permutationsList;
            private String _str;


            private void AddToList(char[] a, bool repeat = true)
            {
                var bufer = new StringBuilder("");
                for (int i = 0; i < a.Count(); i++)
                {
                    bufer.Append(a[i]);
                }
                if (repeat || !_permutationsList.Contains(bufer.ToString()))
                {
                    _permutationsList.Add(bufer.ToString());
                }

            }


            private void RecPermutation(char[] a, int n, bool repeat = true)
            {
                for (var i = 0; i < n; i++)
                {
                    var temp = a[n - 1];
                    for (var j = n - 1; j > 0; j--)
                    {
                        a[j] = a[j - 1];
                    }
                    a[0] = temp;
                    if (i < n - 1) AddToList(a, repeat);
                    if (n > 0) RecPermutation(a, n - 1, repeat);
                }
            }

            public Permutations()
            {
                _str = "";
            }

            public Permutations(String str)
            {
                _str = str;
            }
            public String PermutationStr
            {
                get
                {
                    return _str;
                }
                set
                {
                    _str = value;
                }
            }

            public List<string> GetPermutationsList(bool repeat = true)
            {
                _permutationsList = new List<string> { _str };
                RecPermutation(_str.ToArray(), _str.Length, repeat);
                return _permutationsList;
            }
            public List<string> GetPermutationsSortList(bool repeat = true)
            {
                GetPermutationsList(repeat).Sort();
                return _permutationsList;
            }

        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    n = int.Parse(textBox1.Text);
        //    A = new char[n];
        //    C = new int[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        str += (char)(65 + i);
        //    }
        //    var per = new Permutations(str);
        //    var list = per.GetPermutationsSortList();

        //    foreach (var l in list)
        //    {
        //        listBox1.Items.Add(l);
        //    }
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    n = int.Parse(textBox1.Text);
        //    A = new char[n];
        //    C = new int[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        str += (char)(65 + i);
        //    }
        //    var per = new Permutations(str);
        //    var list = per.GetPermutationsSortList(false);

        //    foreach (var l in list)
        //    {
        //        listBox1.Items.Add(l);
        //    }
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            listBox1.Items.Clear();
            n = int.Parse(textBox1.Text);
            A = new char[n];
            C = new int[n];
            for (int i = 0; i < n; i++)
            {
                str += (char)(65 + i);
            }
            var per = new Permutations(str);
            var list = per.GetPermutationsList();

            foreach (var l in list)
            {
                listBox1.Items.Add(l);
            }
            stopwatch.Stop();
            textBox4.Text = Convert.ToString(stopwatch.ElapsedMilliseconds);
        }
    }
}
