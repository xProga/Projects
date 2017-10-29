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
    public partial class AddItemInTTNList : Form
    {
        private readonly MainForm mf;
        public AddItemInTTNList(MainForm mainForm)
        {
            InitializeComponent();
            mf = mainForm;
        }

        private void ResetFields()
        {
            TelesysComboBox.Enabled = true;
            TelesysComboBox.Visible = true;
            TelesysComboBox.SelectedIndex = 0;
            NonExistItemNameTextBox.Visible = false;
            NonExistItemNameTextBox.Text = "";
            ModulComboBox.Enabled = true;
            //ModulComboBox.SelectedIndex = 0;
            ModulComboBox.Visible = true;
            ZavodNumberTextBox.Enabled = true;
            ZavodNumberTextBox.Text = "";
            CountNumericUpDown.Value = 1;
            CountNumericUpDown.Enabled = true;
            WeightTextBox.Text = "";
            WeightTextBox.Enabled = false;
            WayToGetWeightTextBox.Text = "";
            WayToGetWeightTextBox.Enabled = false;
            EdIzmerComboBox.Enabled = true;
            EdIzmerComboBox.SelectedIndex = 0;
            PackageViewComboBox.Enabled = true;
            PackageViewComboBox.SelectedIndex = 0;
            SpravochnikButton.Visible = true;
            ItemNameLabel.Text = "Модуль системы:";
            CatalogNumberTextBox.Enabled = false;
            CatalogNumberTextBox.Text = "";
        }

        private void AddItemInTTNList_Load(object sender, EventArgs e)
        {
            ExistItemRadioButton.Checked = true;
            List<string> spPackage;
            List<string> spEdIzmer;
            using (DBTTNEntities db = new DBTTNEntities())
            {
                //ModulComboBox.Items.AddRange(db.tbl_Modul_Name.Where(x => x.Class_Modul_Name.Equals("BakerModul")).Select(x => x.Short_Name_Modul_Name).ToArray());
                spPackage = db.tbl_Spiski.Where(x => x.Name_Spiski.Equals("PackageView")).Select(x => x.Value_Spiski).ToList();
                spEdIzmer = db.tbl_Spiski.Where(x => x.Name_Spiski.Equals("EdIzmer")).Select(x => x.Value_Spiski).ToList();
            }
            PackageViewComboBox.Items.Clear();
            EdIzmerComboBox.Items.Clear();
            PackageViewComboBox.Items.AddRange(spPackage.ToArray());
            EdIzmerComboBox.Items.AddRange(spEdIzmer.ToArray());

            ResetFields();
        }

        private void ExistItemRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void NonExistItemRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TelesysComboBox.Visible = false;
            NonExistItemNameTextBox.Text = "";
            NonExistItemNameTextBox.Visible = true;
            ModulComboBox.Visible = false;
            ZavodNumberTextBox.Text = "";
            CountNumericUpDown.Value = 1;
            WeightTextBox.Enabled = true;
            WeightTextBox.Text = "";
            WayToGetWeightTextBox.Enabled = true;
            WayToGetWeightTextBox.Text = "";
            EdIzmerComboBox.Enabled = true;
            EdIzmerComboBox.SelectedIndex = 0;
            PackageViewComboBox.Enabled = true;
            PackageViewComboBox.SelectedIndex = 0;
            SpravochnikButton.Visible = false;
            ItemNameLabel.Text = "Наименование:";
            CatalogNumberTextBox.Enabled = true;
            CatalogNumberTextBox.Text = "";
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            DataGridView objMov = mf.ObjectsMovementGridView;

            if (ExistItemRadioButton.Checked)
            {
                if (ModulComboBox.SelectedItem.ToString() != "")
                {
                    objMov.Rows.Add(ModulComboBox.SelectedItem, CatalogNumberTextBox.Text, ZavodNumberTextBox.Text, CountNumericUpDown.Value.ToString(), EdIzmerComboBox.SelectedItem.ToString(), PackageViewComboBox.SelectedItem.ToString(), WeightTextBox.Text, WayToGetWeightTextBox.Text);

                    ZavodNumberTextBox.Text = "";
                    WeightTextBox.Text = "";
                    WayToGetWeightTextBox.Text = "";
                    ModulComboBox.SelectedItem = "";
                }
                else
                {
                    MessageBox.Show("Не выбран Модуль телесистемы для добавления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            if (NonExistItemRadioButton.Checked)
            {
                if (NonExistItemNameTextBox.Text != "")
                {
                    objMov.Rows.Add(NonExistItemNameTextBox.Text, CatalogNumberTextBox.Text, ZavodNumberTextBox.Text, CountNumericUpDown.Value.ToString(), EdIzmerComboBox.SelectedItem.ToString(), PackageViewComboBox.SelectedItem.ToString(), WeightTextBox.Text, WayToGetWeightTextBox.Text);

                    NonExistItemNameTextBox.Text = "";
                    ZavodNumberTextBox.Text = "";
                    WeightTextBox.Text = "";
                    WayToGetWeightTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Не введено название для добавляемого оборудования!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void CloseDialogButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TelesysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModulComboBox.Items.Clear();
            switch (TelesysComboBox.SelectedItem.ToString())
            {
                case "BAKER":
                    {
                        using (DBTTNEntities db = new DBTTNEntities()){
                            ModulComboBox.Items.AddRange(db.tbl_Modul_Name.Where(x => x.Class_Modul_Name.Equals("BakerModul")).Select(x => x.Short_Name_Modul_Name).ToArray());
                        }
                        break;
                    }
                case "COILTRACK":
                    {
                        using (DBTTNEntities db = new DBTTNEntities())
                        {
                            ModulComboBox.Items.AddRange(db.tbl_Modul_Name.Where(x => x.Class_Modul_Name.Equals("CoilTrackModul")).Select(x => x.Short_Name_Modul_Name).ToArray());
                        }
                        break;
                    }
                case "EGSS":
                    {
                        using (DBTTNEntities db = new DBTTNEntities())
                        {
                            ModulComboBox.Items.AddRange(db.tbl_Modul_Name.Where(x => x.Class_Modul_Name.Equals("EGSSModul")).Select(x => x.Short_Name_Modul_Name).ToArray());
                        }
                        break;
                    }
                case "COMBO":
                    {
                        using (DBTTNEntities db = new DBTTNEntities())
                        {
                            ModulComboBox.Items.AddRange(db.tbl_Modul_Name.Where(x => x.Class_Modul_Name.Equals("ComboModul")).Select(x => x.Short_Name_Modul_Name).ToArray());
                        }
                        break;
                    }
                case "Другое":
                    {
                        using (DBTTNEntities db = new DBTTNEntities())
                        {
                            ModulComboBox.Items.AddRange(db.tbl_Modul_Name.Where(x => x.Class_Modul_Name.Equals("OtherModul")).Select(x => x.Short_Name_Modul_Name).ToArray());
                        }
                        break;
                    }
            }
        }

        private void ModulComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedModul = ModulComboBox.SelectedItem.ToString();
            tbl_Modul_Name mn;
            using (DBTTNEntities db = new DBTTNEntities())
            {
                mn = db.tbl_Modul_Name.Where(x => x.Short_Name_Modul_Name.Equals(selectedModul)).FirstOrDefault();
            }

            WeightTextBox.Text = mn.Weight_Modul_Name.ToString();
            WayToGetWeightTextBox.Text = mn.Way_To_Find_Weight;
            CatalogNumberTextBox.Text = mn.Catalog_Nomer_Modul_Name;
        }

        private void ZavodNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void WeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void SpravochnikButton_Click(object sender, EventArgs e)
        {
            SpravochElemTS spEl = new SpravochElemTS();
            spEl.ModulInfo(TelesysComboBox.SelectedText, ModulComboBox.SelectedText);
            spEl.Show();
        }

        private void ZavodNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
