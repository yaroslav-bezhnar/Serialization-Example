using System;
using System.Windows.Forms;

namespace lab_9
{
    public partial class Form1 : Form
    {
        #region Fields

        private readonly PCCollection _pcCollection = new PCCollection();

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        #endregion

        #region Private Methods

        private void DataGridShow()
        {
            dataGridView1.Rows.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            for ( var i = 0; i < _pcCollection.Count(); i++ )
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = i + 1;
                dataGridView1.Rows[i].Cells["Column1"].Value = _pcCollection.Get( i ).Name;
                dataGridView1.Rows[i].Cells["Column2"].Value = _pcCollection.Get( i ).Number;
                dataGridView1.Rows[i].Cells["Column3"].Value = _pcCollection.Get( i ).Model;
                dataGridView1.Rows[i].Cells["Column4"].Value = _pcCollection.Get( i ).Country;
                dataGridView1.Rows[i].Cells["Column5"].Value = _pcCollection.Get( i ).Price;

                if ( !comboBox2.Items.Contains( _pcCollection.Get( i ).Name ) )
                    comboBox2.Items.Add( _pcCollection.Get( i ).Name );
                if ( !comboBox3.Items.Contains( _pcCollection.Get( i ).Country ) )
                    comboBox3.Items.Add( _pcCollection.Get( i ).Country );
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            try
            {
                if ( Convert.ToString( comboBox1.Text ).Trim() == string.Empty ||
                     Convert.ToString( textBox2.Text ).Trim() == string.Empty ||
                     Convert.ToString( textBox3.Text ).Trim() == string.Empty ||
                     Convert.ToString( textBox4.Text ).Trim() == string.Empty ||
                     Convert.ToString( textBox5.Text ).Trim() == string.Empty )
                {
                    MessageBox.Show( $@"Помилка.{Environment.NewLine}Не всі поля заповнені даними" );
                    return;
                }

                if ( Convert.ToInt32( textBox5.Text ) > 0 )
                {
                    _pcCollection.Add( new Complectation( Convert.ToString( comboBox1.Text ),
                                                         Convert.ToInt32( textBox2.Text ),
                                                         Convert.ToString( textBox3.Text ),
                                                         Convert.ToString( textBox4.Text ),
                                                         Convert.ToDouble( textBox5.Text ) ) );
                    _pcCollection.Sort();
                    DataGridShow();
                }
                else
                {
                    MessageBox.Show( $@"Помилка.{Environment.NewLine}Ціна повинна бути додатнім числом" );
                }
            }
            catch
            {
                MessageBox.Show( @"Поле 'Номер' та 'Ціна' повинні бути числовим значенням" );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            DataGridShow();
        }

        private void button4_Click( object sender, EventArgs e )
        {
            try
            {
                _pcCollection.Remove( dataGridView1.CurrentCell.RowIndex );
                dataGridView1.Rows.RemoveAt( dataGridView1.CurrentCell.RowIndex );
                DataGridShow();
            }
            catch
            {
                MessageBox.Show( @"Виберить елемент для видалення" );
            }
        }

        private void ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void зберегтиЯкToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = @"file (*.dat)|*.dat|All files (*.*)|*.*";
            saveFile.FileName = @"PC Complectation";
            saveFile.DefaultExt = @"dat";
            saveFile.ShowDialog();
            if ( saveFile.FileName != string.Empty )
                _pcCollection.SaveFile( saveFile.FileName );
        }

        private void відкритиToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var file = new OpenFileDialog();
            file.Filter = @"file (*.dat)|*.dat|All files (*.*)|*.*";
            file.ShowDialog();
            if ( file.FileName != string.Empty )
                _pcCollection.OpenFile( file.FileName );
            DataGridShow();
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            MessageBox.Show( $@"ТРіПО{Environment.NewLine}Лабораторна робота №9" );
        }

        private void comboBox2_SelectedIndexChanged( object sender, EventArgs e )
        {
            try
            {
                dataGridView1.Rows.Clear();
                for ( var i = 0; i < _pcCollection.Count(); i++ )
                    if ( comboBox2.Items[comboBox2.SelectedIndex].ToString() == _pcCollection.Get( i ).Name )
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].HeaderCell.Value = dataGridView1.RowCount;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column1"].Value = _pcCollection.Get( i ).Name;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column2"].Value = _pcCollection.Get( i ).Number;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column3"].Value = _pcCollection.Get( i ).Model;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column4"].Value = _pcCollection.Get( i ).Country;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column5"].Value = _pcCollection.Get( i ).Price;
                    }
            }
            catch
            {
                MessageBox.Show( @"Не вибрано жодного елемента" );
            }
        }

        private void comboBox3_SelectedIndexChanged( object sender, EventArgs e )
        {
            try
            {
                dataGridView1.Rows.Clear();
                for ( var i = 0; i < _pcCollection.Count(); i++ )
                    if ( comboBox3.Items[comboBox3.SelectedIndex].ToString() == _pcCollection.Get( i ).Country )
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].HeaderCell.Value = dataGridView1.RowCount.ToString();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column1"].Value = _pcCollection.Get( i ).Name;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column2"].Value = _pcCollection.Get( i ).Number;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column3"].Value = _pcCollection.Get( i ).Model;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column4"].Value = _pcCollection.Get( i ).Country;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Column5"].Value = _pcCollection.Get( i ).Price;
                    }
            }
            catch
            {
                MessageBox.Show( @"Не вибрано жодного елемента" );
            }
        }

        #endregion
    }
}