using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_9
{
    public partial class Form1 : Form
    {
        PCCollection PC = new PCCollection();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }
        private void DataGridShow()
        {
            dataGridView1.Rows.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            for (int i = 0; i < PC.Count(); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView1.Rows[i].Cells["Column1"].Value = PC.Get(i).Name.ToString();
                dataGridView1.Rows[i].Cells["Column2"].Value = PC.Get(i).Number.ToString();
                dataGridView1.Rows[i].Cells["Column3"].Value = PC.Get(i).Model.ToString();
                dataGridView1.Rows[i].Cells["Column4"].Value = PC.Get(i).Country.ToString();
                dataGridView1.Rows[i].Cells["Column5"].Value = PC.Get(i).Price.ToString();

                if (!comboBox2.Items.Contains(PC.Get(i).Name.ToString()))
                 comboBox2.Items.Add(PC.Get(i).Name.ToString()); 
                if (!comboBox3.Items.Contains(PC.Get(i).Country.ToString()))
                 comboBox3.Items.Add(PC.Get(i).Country.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(comboBox1.Text).Trim() == string.Empty || Convert.ToString(textBox2.Text).Trim() == string.Empty || Convert.ToString(textBox3.Text).Trim() == string.Empty || Convert.ToString(textBox4.Text).Trim() == string.Empty || Convert.ToString(textBox5.Text).Trim() == string.Empty)
                {
                    MessageBox.Show("\tПомилка.\n\nНе всі поля заповнені даними");
                    return;
                }
                if (Convert.ToInt32(textBox5.Text) > 0)
                {
                    PC.Add(new Complectation(Convert.ToString(comboBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text), Convert.ToString(textBox4.Text), Convert.ToDouble(textBox5.Text)));
                    PC.Sort();
                    DataGridShow();
                }
                else MessageBox.Show("\tПомилка.\n\nЦіна повинна бути додатнім числом");
            }
            catch
            {
                MessageBox.Show("Поле 'Номер' та 'Ціна' повинні бути числовим значенням");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DataGridShow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                PC.Remove(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                DataGridShow();
            }
            catch
            {
                MessageBox.Show("Виберить елемент для видалення");
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "file (*.dat)|*.dat|All files (*.*)|*.*";
            saveFile.FileName = "PC Complectation";
            saveFile.DefaultExt = "dat";
            saveFile.ShowDialog();
            if (saveFile.FileName != string.Empty)
                PC.SaveFile(saveFile.FileName);
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "file (*.dat)|*.dat|All files (*.*)|*.*";
            file.ShowDialog();
            if (file.FileName != string.Empty)
                PC.OpenFile(file.FileName);
            DataGridShow();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tТРіПО\nЛабораторна робота №9");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < PC.Count(); i++)
                {
                    if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == PC.Get(i).Name.ToString())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].HeaderCell.Value = (dataGridView1.RowCount).ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column1"].Value = PC.Get(i).Name.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column2"].Value = PC.Get(i).Number.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column3"].Value = PC.Get(i).Model.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column4"].Value = PC.Get(i).Country.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column5"].Value = PC.Get(i).Price.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не вибрано жодного елемента");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < PC.Count(); i++)
                {
                    if (comboBox3.Items[comboBox3.SelectedIndex].ToString() == PC.Get(i).Country.ToString())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].HeaderCell.Value = (dataGridView1.RowCount).ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column1"].Value = PC.Get(i).Name.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column2"].Value = PC.Get(i).Number.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column3"].Value = PC.Get(i).Model.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column4"].Value = PC.Get(i).Country.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column5"].Value = PC.Get(i).Price.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не вибрано жодного елемента");
            }
        }

      
    }
}
