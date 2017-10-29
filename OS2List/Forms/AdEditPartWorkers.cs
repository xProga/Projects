using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2List
{
    public partial class AdEditPartWorkers : Form
    {
        private static string tabNumberEditWorker;
        public AdEditPartWorkers()
        {
            InitializeComponent();
        }

        private void ClearBoxes()
        {
            FirstNameTextBox.Text = "";
            FirstNameTextBox.Enabled = true;
            SecondNameTextBox.Text = "";
            SecondNameTextBox.Enabled = true;
            LastNameTextBox.Text = "";
            LastNameTextBox.Enabled = true;
            TabNumberTextBox.Text = "";
            TabNumberTextBox.Enabled = true;
            DoljnostComboBox.Enabled = true;
            DoljnostComboBox.SelectedIndex = 3;
            PartNumberComboBox.Enabled = true;
            //PartNumberComboBox.SelectedIndex = 1;
        }

        private void OpenBoxes()
        {
            FirstNameTextBox.Enabled = true;
            SecondNameTextBox.Enabled = true;
            LastNameTextBox.Enabled = true;
            TabNumberTextBox.Enabled = true;
            DoljnostComboBox.Enabled = true;
            DoljnostComboBox.SelectedIndex = 3;
            PartNumberComboBox.Enabled = true;
            //PartNumberComboBox.SelectedIndex = 1;
            ApplyButton.Visible = true;
            CancelButton.Visible = true;
        }

        private void CloseBoxes()
        {
            FirstNameTextBox.Text = "";
            FirstNameTextBox.Enabled = false;
            SecondNameTextBox.Text = "";
            SecondNameTextBox.Enabled = false;
            LastNameTextBox.Text = "";
            LastNameTextBox.Enabled = false;
            TabNumberTextBox.Text = "";
            TabNumberTextBox.Enabled = false;
            DoljnostComboBox.Enabled = false;
            DoljnostComboBox.SelectedIndex = 3;
            PartNumberComboBox.Enabled = false;
            //PartNumberComboBox.SelectedIndex = 1;
            ApplyButton.Visible = false;
            CancelButton.Visible = false;
        }

        private void CloseWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewWorkerButton_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            ApplyButton.Visible = true;
            CancelButton.Visible = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CloseBoxes();
            ApplyButton.Visible = false;
            CancelButton.Visible = false;
        }

        private void WorkersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WorkersDataGridView.Rows[e.RowIndex].Selected = true;
            FirstNameTextBox.Text = WorkersDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            SecondNameTextBox.Text = WorkersDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            LastNameTextBox.Text = WorkersDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            TabNumberTextBox.Text = WorkersDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            DoljnostComboBox.SelectedItem = WorkersDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            PartNumberComboBox.SelectedItem = WorkersDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void DeleteCurrentWorkerButton_Click(object sender, EventArgs e)
        {
            if (WorkersDataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить работника?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (DBTTNEntities db = new DBTTNEntities())
                    {
                        string tabNumber = WorkersDataGridView.SelectedRows[0].Cells[3].Value.ToString();
                        tbl_Kadrovii_Sostav ks = new tbl_Kadrovii_Sostav();
                        ks = db.tbl_Kadrovii_Sostav.Where(x => x.Tab_N_KS.Equals(tabNumber)).FirstOrDefault();
                        db.tbl_Kadrovii_Sostav.Remove(ks);
                        WorkersDataGridView.Rows.Remove(WorkersDataGridView.SelectedRows[0]);
                        db.SaveChanges();
                    }
                }
            }
        }

        private void ChangeCurrentWorkerButton_Click(object sender, EventArgs e)
        {
            OpenBoxes();
            tabNumberEditWorker = TabNumberTextBox.Text;
            ApplyButton.Visible = true;
            CancelButton.Visible = true;
        }

        private void EditKadrviiSostRecord()
        {
            using (DBTTNEntities db = new DBTTNEntities())
            {
                //string tabNumber = TabNumberTextBox.Text;
                tbl_Kadrovii_Sostav ks = new tbl_Kadrovii_Sostav();
                ks = db.tbl_Kadrovii_Sostav.Where(x => x.Tab_N_KS.Equals(tabNumberEditWorker)).FirstOrDefault();
                ks.Familiya_KS = FirstNameTextBox.Text;
                ks.Imya_KS = SecondNameTextBox.Text;
                ks.Otchestvo_KS = LastNameTextBox.Text;
                ks.Tab_N_KS = TabNumberTextBox.Text;
                ks.Dolgnost_KS = DoljnostComboBox.SelectedItem.ToString();
                string pn = PartNumberComboBox.SelectedItem.ToString();
                ks.Kod_ORM_KS = db.tbl_ORM.Where(x => x.Short_Name_ORM.Equals(pn)).Select(x => x.ID_ORM).FirstOrDefault();
                db.SaveChanges();

                WorkersDataGridView.SelectedRows[0].Cells[0].Value = FirstNameTextBox.Text;
                WorkersDataGridView.SelectedRows[0].Cells[1].Value = SecondNameTextBox.Text;
                WorkersDataGridView.SelectedRows[0].Cells[2].Value = LastNameTextBox.Text;
                WorkersDataGridView.SelectedRows[0].Cells[3].Value = TabNumberTextBox.Text;
                WorkersDataGridView.SelectedRows[0].Cells[4].Value = DoljnostComboBox.SelectedItem;
                WorkersDataGridView.SelectedRows[0].Cells[5].Value = PartNumberComboBox.SelectedItem;
            }
        }

        private void AddKadrviiSostRecord()
        {
            using (DBTTNEntities db = new DBTTNEntities())
            {
                if (FirstNameTextBox.Text != "" && SecondNameTextBox.Text != "" && LastNameTextBox.Text != ""
                    && TabNumberTextBox.Text != "" && DoljnostComboBox.SelectedItem.ToString() != "" 
                    && PartNumberComboBox.SelectedItem.ToString() != "")
                {
                    try
                    {
                        string tabNumber = TabNumberTextBox.Text;
                        tbl_Kadrovii_Sostav ks = new tbl_Kadrovii_Sostav();
                        //ks = db.tbl_Kadrovii_Sostav.Where(x => x.Tab_N_KS.Equals(tabNumber)).FirstOrDefault();
                        ks.Familiya_KS = FirstNameTextBox.Text;
                        ks.Imya_KS = SecondNameTextBox.Text;
                        ks.Otchestvo_KS = LastNameTextBox.Text;
                        ks.Tab_N_KS = TabNumberTextBox.Text;
                        ks.Dolgnost_KS = DoljnostComboBox.SelectedItem.ToString();
                        string pn = PartNumberComboBox.SelectedItem.ToString();
                        ks.Kod_ORM_KS = db.tbl_ORM.Where(x => x.Short_Name_ORM.Equals(pn)).Select(x => x.ID_ORM).FirstOrDefault();
                        db.tbl_Kadrovii_Sostav.Add(ks);
                        db.SaveChanges();

                        WorkersDataGridView.Rows.Add(FirstNameTextBox.Text, SecondNameTextBox.Text,
                            LastNameTextBox.Text, TabNumberTextBox.Text,
                            DoljnostComboBox.SelectedItem.ToString(), PartNumberComboBox.SelectedItem.ToString());
                        ApplyButton.Visible = false;
                        CancelButton.Visible = false;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ошибка: " + e.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Одно из полей не заполнено. Пожалуйста, заполните ВСЕ поля для продолжения.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (DBTTNEntities db = new DBTTNEntities())
            {
                //string tabNumber = TabNumberTextBox.Text;
                if (db.tbl_Kadrovii_Sostav.Where(x => x.Tab_N_KS.Equals(tabNumberEditWorker)).Count() > 0)
                {
                    if (WorkersDataGridView.SelectedRows.Count > 0)
                    {
                        EditKadrviiSostRecord();
                        CloseBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Не выбрано ни одного работника для изменения");
                    }
                }
                else
                {
                    AddKadrviiSostRecord();
                    CloseBoxes();
                }
            }
        }

        private void AdEditPartWorkers_Load(object sender, EventArgs e)
        {
            using (DBTTNEntities db = new DBTTNEntities())
            {
                PartNumberComboBox.Items.AddRange(db.tbl_ORM.Where(x => x.Short_Name_ORM.Contains("ИТП")).Select(x => x.Short_Name_ORM).ToArray());
                var partWorkers = (from orm in db.tbl_ORM
                                   join ks in db.tbl_Kadrovii_Sostav on orm.ID_ORM equals ks.Kod_ORM_KS
                                   where orm.Short_Name_ORM.Contains("ИТП")
                                   select ks).ToList();
                
                int i = 0;
                while (partWorkers.Count > i)
                {
                    int ormID = (int)partWorkers[i].Kod_ORM_KS;
                    string orm = db.tbl_ORM.Where(x => x.ID_ORM == ormID).Select(x => x.Short_Name_ORM).FirstOrDefault();
                    WorkersDataGridView.Rows.Add(partWorkers[i].Familiya_KS, partWorkers[i].Imya_KS, partWorkers[i].Otchestvo_KS, partWorkers[i].Tab_N_KS, partWorkers[i].Dolgnost_KS, orm);
                    i++;
                }
            }
        }

        private void PartNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
