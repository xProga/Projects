using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OS2List
{
    public partial class SpravochElemTS : Form
    {
        public SpravochElemTS()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ModulInfo(string telesysName, string modulName)
        {
            int telesysIndex = TelesysComboBox.FindString(telesysName);
            TelesysComboBox.SelectedIndex = telesysIndex;
            int modulIndex = ModulComboBox.FindString(modulName);
            ModulComboBox.SelectedIndex = modulIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModulComboBox.Items.Clear();
            switch (TelesysComboBox.SelectedItem.ToString())
            {
                case "BAKER":
                    {
                        using (DBTTNEntities db = new DBTTNEntities())
                        {
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
            CommentRichTextBox.Text = mn.Comment_Modul_Name;
            CatalogNumberTextBox.Text = mn.Catalog_Nomer_Modul_Name;
            if (mn.Image_Path != null)
            {
                var stream = new MemoryStream(mn.Image_Path);
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        private void SpravochElemTS_Load(object sender, EventArgs e)
        {
            TelesysComboBox.SelectedIndex = 0;
        }
    }
}
