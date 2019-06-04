using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Graphviz;
using System.Diagnostics;
using System.IO;
namespace GraphMax
{
    public partial class GraphMax : Form
    {
        int n = 1, number=0;
        int[,] A, A_2, A_3, T, T_t, S, E;
        public GraphMax()
        {
            InitializeComponent();
        }

        private void GraphMax_Load(object sender, EventArgs e)
        {
            Print_Graph.BackColor = Color.White;
            Accept.BackColor = Color.White;
        }

        private void Accept_Click_1(object sender, EventArgs e)
        {
            if (n == 0)
                return;
            A = new int[n, n];
            A_2 = new int[n, n];
            A_3 = new int[n, n];
            T = new int[n, n];
            S = new int[n, n];
            E = new int[n, n];
            for (short i = 0; i < n; i++)
                for (short j = 0; j < n; j++)
                    A[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
            Print_matrix(A, n, n);
            E_fill(n, n, E);
            A_2 = Multiplication(A, A);
            A_3 = Multiplication(A_2, A);
            T = One_way_matrix(n, n, E, A, A_2, A_3);
            T_t = Copy_matrix(n, n, T);
            T_t = Transp_matrix(n, n, T_t);
            S = Strong_connect_matrix(n, n, T, T_t);
            Print_matrix(S, n, n);
        }

        private void Print_Graph_Click(object sender, EventArgs e)
        {
            number++;
            MakePngFile_A(A);
            MakePngFile_S(S);
            pictureBox1.Image = Image.FromFile(@"C:\Users\User\Desktop\GraphMax\GraphMax\bin\Debug\tmp" + number+".png");
            pictureBox2.Image = Image.FromFile(@"C:\Users\User\Desktop\GraphMax\GraphMax\bin\Debug\tmp" + number + 1 + @".png");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        }


        private void MakeDotFile_A(int[,] A)
        {
            FileStream fileStream =
                new FileStream("tmp"+number+".dot", FileMode.Create, FileAccess.Write);
         
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write("digraph {node [shape=\"circle\", style=\"filled\", fillcolor=\"blue\", fontcolor=\"#FFFFFF\", margin=\"0.01\"]; rankdir = \"LR\"; ");
            for (int i = 0; i < n; i++)
            {
                if (A[i,i] == 0)
                    streamWriter.Write(i + "->" + i + ";");
                for (int j = 0; j < n; j++)
                    if (A[i, j] != 0)
                        streamWriter.Write(i + "->" + j + ";");
            }
                      


            streamWriter.Write("}");
            streamWriter.Close();
            fileStream.Close();
        }

        public void MakePngFile_A(int[,] A)
        {
            MakeDotFile_A(A);
            Process process = new Process();
            process.StartInfo =
                new ProcessStartInfo(@"C:\Users\User\Desktop\GraphMax\packages\Graphviz.2.38.0.2\dot.exe",
        @"-Tpng C:\Users\User\Desktop\GraphMax\GraphMax\bin\Debug\tmp" + number+ @".dot -o C:\Users\User\Desktop\GraphMax\GraphMax\bin\Debug\tmp" + number+@".png");
            process.Start();
            process.WaitForExit();
        }
        private void MakeDotFile_S(int[,] S)
        {
            FileStream fileStream =
                new FileStream("tmp"+number+1+".dot", FileMode.Create, FileAccess.Write);

            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write("digraph {node [shape=\"circle\", style=\"filled\", fillcolor=\"blue\", fontcolor=\"#FFFFFF\", margin=\"0.01\"]; rankdir = \"LR\"; ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (S[i, j] != 0)
                        streamWriter.Write(i + "->" + j + ";");
            streamWriter.Write("}");
            streamWriter.Close();
            fileStream.Close();
        }

        public void MakePngFile_S(int[,] S)
        {
            MakeDotFile_S(S);
            Process process = new Process();
            process.StartInfo =
                new ProcessStartInfo(@"C:\Users\User\Desktop\GraphMax\packages\Graphviz.2.38.0.2\dot.exe",
        @"-Tpng C:\Users\User\Desktop\GraphMax\GraphMax\bin\Debug\tmp" + number+1+ @".dot -o C:\Users\User\Desktop\GraphMax\GraphMax\bin\Debug\tmp" + number + 1 + @".png");
            process.Start();
            process.WaitForExit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = (byte)numericUpDown1.Value;
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static void E_fill(int rows, int coums, int[,] E) // Заполнение единичной матрицы
        {
            for (int i = 0; i < rows; i++)
                E[i, i] = 1;
        }
        public static void Print_matrix(int[,] E, int rows, int colums) //Печать матрицы
        {
            Console.Write("\n");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colums; j++)
                {
                    if (j == colums - 1)
                        Console.Write(" " + E[i, j] + "\n");
                    else
                        Console.Write(" " + E[i, j] + " ");
                }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        public static int[,] Multiplication(int[,] a, int[,] b)
        {
            int[,] r = new int[a.Length, b.Length];
            for (int i = 0; i < b.GetLength(1); i++)
            {
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    r[i, j] = 0;
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        public static int[,] One_way_matrix(int rows, int colums, int[,] E, int[,] A, int[,] A_2, int[,] A_3)
        {
            int[,] tmp = new int[rows, colums];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colums; j++)
                    if (E[i, j] != 0 || A[i, j] != 0 || A_2[i, j] != 0 || A_3[i, j] != 0)
                        tmp[i, j] = 1;
                    else
                        tmp[i, j] = 0;
            return tmp;
        }
        public static int[,] Transp_matrix(int rows, int colums, int[,] T)
        {
            int tmp;
            int[,] r = new int[rows, colums];
            r = T;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    tmp = r[i, j];
                    r[i, j] = r[j, i];
                    r[j, i] = tmp;
                }
            }
            return r;
        }
        public static int[,] Copy_matrix(int rows, int colums, int[,] T)
        {
            int[,] r = new int[rows, colums];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colums; j++)
                    r[i, j] = T[i, j];
            return r;
        }
        public static int[,] Strong_connect_matrix(int rows, int colums, int[,] T, int[,] T_t)
        {
            int[,] S = new int[rows, colums];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colums; j++)
                    if (T[i, j] == 0 || T_t[i, j] == 0)
                        S[i, j] = 0;
                    else
                        S[i, j] = 1;
            return S;
        }
    }
}
