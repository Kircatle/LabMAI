using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C39
{
    public partial class Langueage : Form
    {
        private View view;
        private About aform;

        public Langueage(View view, About aform)
        {
            InitializeComponent();
            this.view = view;
            this.aform = aform;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                view.button1.Text = "Draw function";
                view.button2.Text = "Draw particles";
                view.button3.Text = "Start optimization";
                view.button4.Text = "Stop";
                view.button5.Text = "Restart";
                view.button6.Text = "Exit";
                view.label1.Text = "from";
                view.label2.Text = "to";
                view.label7.Text = "Function";
                view.label8.Text = "Count particles";
                view.label9.Text = "Range";
                view.groupBox2.Text = "Count iteration";
                view.groupBox4.Text = "information";
                view.Text = "Particle swarm optimization algoritm(global maximum)";
                view.toolStripButton1.Text = "Langueage";
                this.Text = "Langueage";
                view.toolStripButton2.Text = "About Programm";
                aform.Text = "About programm";
                aform.label1.Text = "Author:";
                aform.label2.Text = "Syroezhlin Kirill Gennadievich";
                aform.label3.Text = "Group:";
                aform.label4.Text = "M8O-204Б-18";
                aform.label5.Text = "About programm";
                aform.label6.Text = "The program visualizes the optimization algorithm of the swarm of particles on the OXY plane";
                view.t1.SetToolTip(view.label2, "Range X");
                view.t2.SetToolTip(view.textBox4, "For example: x^2, sin(x), cos(x), tan(x), ctg(x)");
                view.t3.SetToolTip(view.textBox5, "The number of particles that will search for the global maximum of the function");
                view.t4.SetToolTip(view.textBox3, "How many times to execute the algorithm");
            }
            else if (radioButton2.Checked)
            {
                view.button1.Text = "Нарисовать функцию";
                view.button2.Text = "Нарисовать частицы";
                view.button3.Text = "Запустить оптимизацию";
                view.button4.Text = "Стоп";
                view.button5.Text = "Перезагрузка";
                view.button6.Text = "Выход";
                view.label1.Text = "от";
                view.label2.Text = "до";
                view.label7.Text = "Функция";
                view.label8.Text = "Количество частиц";
                view.label9.Text = "Диапазон";
                view.groupBox2.Text = "Количество интераций";
                view.groupBox4.Text = "информация";
                view.Text = "алгоритм оптимизации роя частиц(глобальный максимум)";
                view.toolStripButton1.Text = "Язык";
                view.toolStripButton2.Text = "О программе";
                this.Text = "Язык";
                aform.Text = "О программе";
                aform.label1.Text = "Автор:";
                aform.label2.Text = "Сыроежкин Кирилл Геннадьевич";
                aform.label3.Text = "Группа:";
                aform.label4.Text = "M8O-204Б-18";
                aform.label5.Text = "О программе";
                aform.label6.Text = "Программа визуализирует алгоритм оптимизации роя частиц на плоскости OXY";
                view.t1.SetToolTip(view.label2, "Диапазон X");
                view.t2.SetToolTip(view.textBox4, "Например: x^2, sin(x), cos(x), tan(x), ctg(x)");
                view.t3.SetToolTip(view.textBox5, "Количество частиц, которые будут искать глобальный максимум функции");
                view.t4.SetToolTip(view.textBox3, "Сколько раз выполнить алгоритм");


            }
            Close();
          
        }
    }
}
