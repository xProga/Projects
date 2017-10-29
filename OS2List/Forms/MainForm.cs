using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace OS2List
{
    public partial class MainForm : Form
    {
        //DB_Part_OS2Entities db = new DB_Part_OS2Entities();
        DBTTNEntities db = new DBTTNEntities();
        private Excel.Application exapp;
        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range exceslcells;

        public MainForm()
        {
            InitializeComponent();
        }

        public void AddItemsInComboBox(DataGridViewComboBoxColumn comboboxColumn)
        {
            //DB_Part_OS2Entities db = new DB_Part_OS2Entities();
            //comboboxColumn.Items.AddRange((from d in db.tbl_Modul_Name select d.Short_Name_Modul_Name).ToArray());
        }

        public List<string> ValidateForm()
        {
            Control[] ctrl = new Control[15];

            ctrl[0] = NumberTTNTextBox;
            ctrl[1] = ITSSenderComboBox;
            ctrl[2] = KustSenderComboBox;
            ctrl[3] = KustNumbertextBox;
            ctrl[4] = SenderComboBox;
            ctrl[5] = SenderTextBox;
            ctrl[6] = SenderAllowedComboBox;
            ctrl[7] = SenderAllowedPositionTextBox;
            ctrl[8] = ITSReceverComboBox;
            ctrl[9] = KustReceverComboBox;
            ctrl[10] = KustNumberReceverTextBox;
            ctrl[11] = RequestedReceverComboBox;
            ctrl[12] = RequestedReceverTextBox;
            ctrl[13] = DriverComboBox;
            ctrl[14] = DriverListSerialtextBox;

            string[] ctrlName = new string[15];

            ctrlName[0] = "Номер ТТН";
            ctrlName[1] = "Орг. единица отправителя";
            ctrlName[2] = "Месторождение отправителя";
            ctrlName[3] = "Номер месторождения отправителя";
            ctrlName[4] = "ФИО отправителя";
            ctrlName[5] = "Должность отправителя";
            ctrlName[6] = "ФИО разрешившего отправку";
            ctrlName[7] = "Должность разрешившего отправку";
            ctrlName[8] = "Орг. единица получателя";
            ctrlName[9] = "Месторождение получателя";
            ctrlName[10] = "Номер месторождения получателя";
            ctrlName[11] = "ФИО получателя";
            ctrlName[12] = "Должность получателя";
            ctrlName[13] = "ФИО водителя";
            ctrlName[14] = "Номер путевого листа водителя";

            

            List<string> errCtrls = new List<string>();

            int i = 0;
            while (ctrl.Length > i)
            {
                if (ctrl[i].Text == "")
                {
                    errCtrls.Add(ctrlName[i]);
                }
                i++;
            }

            return errCtrls;
        }

        public void PrintOS2List()
        {
            exapp = new Excel.Application();
            //exapp.Visible = true;

            exapp.Workbooks.Add(@"D:\Shablon.xltx");
            //exapp.Workbooks.Open(@"C:\Shablon.xls",
            // Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            // Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            // Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelsheets = exapp.Worksheets;
            excelworksheet = (Excel.Worksheet)exapp.Worksheets["ОС2"]; // Лист 1
            //excelcells = excelworksheet.Range.Cells[9][3];
            string itsSelItm = ITSSenderComboBox.SelectedItem.ToString();
            string itsResItm = ITSReceverComboBox.SelectedItem.ToString();
            var ITPNameandLeaderSender = (from ormList in db.tbl_Kadrovii_Sostav
                                            join ormName in db.tbl_ORM on ormList.Kod_ORM_KS equals ormName.ID_ORM
                                            where ormName.Short_Name_ORM.Equals(itsSelItm)
                                          select new { ITPLeaderName = ormList, ITPinfo = ormName }).FirstOrDefault();
            var ITPNameAndLeaderRecever = (from ormList in db.tbl_Kadrovii_Sostav 
                                            join ormName in db.tbl_ORM on ormList.Kod_ORM_KS equals ormName.ID_ORM
                                            where ormName.Short_Name_ORM.Equals(itsResItm)
                                            select new { ITPLeaderName = ormList, ITPinfo = ormName, ormName.Short_Name_ORM}).ToList().FirstOrDefault();
            excelworksheet.Cells[5, "F"] = "НАКЛАДНАЯ № " + NumberTTNTextBox.Text + " от " + dateTimePickerSend.Text;

            excelworksheet.Cells[9, "E"] = "0800, УКРСиПНП, ИТС, " + ITPNameandLeaderSender.ITPinfo.Full_Name_ORM + ", " + ITPNameandLeaderSender.ITPinfo.Phone_ORM;

            excelworksheet.Cells[11, "E"] = KustSenderComboBox.SelectedItem + " месторождение, куст " + KustNumbertextBox.Text;
            if (ITSSenderComboBox.SelectedItem.ToString() == "ГР ИТС")
            {
                excelworksheet.Cells[11, "E"] = "БПО УКРСиПНП, ул. Западная 3";
            }
            excelworksheet.Cells[12, "E"] = "0800, УКРСиПНП, ИТС, " + ITPNameAndLeaderRecever.ITPinfo.Full_Name_ORM + ", " + ITPNameAndLeaderRecever.ITPinfo.Phone_ORM;

            excelworksheet.Cells[14, "E"] = KustReceverComboBox.SelectedItem + " месторождение, куст " + KustNumberReceverTextBox.Text;
            if (ITSReceverComboBox.SelectedItem.ToString() == "ГР ИТС")
            {
                excelworksheet.Cells[14, "E"] = "БПО УКРСиПНП, ул. Западная 3";
            }

            excelworksheet.Cells[15, "H"] = DriverListSerialtextBox.Text;


            Excel.Range line = (Excel.Range)excelworksheet.get_Range("A21", "O21");
            line.RowHeight = 15;
            line.Font.Name = "Arial";
            line.Font.Size = 7;
            //excelcells.Value2 = "aaa";
            int i = 0;
            while (ObjectsMovementGridView.RowCount - 1> i) //Создание строк
            {
                line = excelworksheet.get_Range("A21", "O21").EntireRow;
                line.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                line = excelworksheet.get_Range("A21", "O21");
                line.RowHeight = 15;
                line.Font.Name = "Arial";
                line.Font.Size = 7;
                excelworksheet.get_Range("A22", "O22").Copy();
                excelworksheet.get_Range("A21", "O21").PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationAdd);
                i++;
            }

            decimal fullWeight = 0;
            int fullCount = 0;
            i = 0;
            while (ObjectsMovementGridView.RowCount > i) // заполнение строк
            {
                string temp = ObjectsMovementGridView.Rows[i].Cells[0].Value.ToString();
                var currObj = (from mod in db.tbl_Modul_Name where mod.Short_Name_Modul_Name.Equals(temp) select mod).ToList()[0];

                excelworksheet.Cells[21 + i, "A"] = i + 1;  //п.п
                excelworksheet.Cells[21 + i, "B"] = ""; //Инв. номер сдатчика
                excelworksheet.Cells[21 + i, "D"] = ObjectsMovementGridView.Rows[i].Cells[0].Value.ToString();  //наименование
                excelworksheet.Cells[21 + i, "G"] = ObjectsMovementGridView.Rows[i].Cells[1].Value.ToString(); //Каталожный номер
                excelworksheet.Cells[21 + i, "H"] = ObjectsMovementGridView.Rows[i].Cells[2].Value.ToString(); //серийный/инвентарный
                //excelworksheet.Cells[17 + i, "DZ"] = currObj.Ed_Izmer; //ед измерения
                excelworksheet.Cells[21 + i, "I"] = ObjectsMovementGridView.Rows[i].Cells[3].Value.ToString(); //кол-во
                //excelworksheet.Cells[21 + i, "FF"] = ""; //номер потр
                excelworksheet.Cells[21 + i, "J"] = ObjectsMovementGridView.Rows[i].Cells[5].Value.ToString(); ; //вид упаковки груза
                excelworksheet.Cells[21 + i, "K"] = ObjectsMovementGridView.Rows[i].Cells[3].Value.ToString(); //кол-во груза
                excelworksheet.Cells[21 + i, "L"] = ObjectsMovementGridView.Rows[i].Cells[6].Value.ToString(); //масса
                excelworksheet.Cells[21 + i, "M"] = "Взвешивание"; //способ опред массы
                excelworksheet.Cells[21 + i, "N"] = "--";
                excelworksheet.Cells[21 + i, "O"] = "--";

                fullWeight = fullWeight + Convert.ToDecimal(ObjectsMovementGridView.Rows[i].Cells[6].Value);
                fullCount = fullCount + Convert.ToInt32(ObjectsMovementGridView.Rows[i].Cells[3].Value);
                i++;
            }

            excelworksheet.Cells[25 + i - 1, "D"] = ReasonMovementTextBox.Text;

            excelworksheet.Cells[22 + i - 1, "I"] = fullCount;
            excelworksheet.Cells[22 + i - 1, "K"] = fullCount;
            excelworksheet.Cells[22 + i - 1, "L"] = fullWeight.ToString();

            excelworksheet.Cells[31 + ObjectsMovementGridView.RowCount - 1, "B"] = SenderTextBox.Text;
            excelworksheet.Cells[31 + ObjectsMovementGridView.RowCount - 1, "F"] = SenderComboBox.SelectedItem.ToString();

            excelworksheet.Cells[39 + ObjectsMovementGridView.RowCount - 1, "C"] = "Водитель автомобиля";
            excelworksheet.Cells[39 + ObjectsMovementGridView.RowCount - 1, "F"] = DriverComboBox.SelectedItem.ToString();

            excelworksheet.Cells[31 + ObjectsMovementGridView.RowCount - 1, "J"] = "Водитель автомобиля";
            excelworksheet.Cells[31 + ObjectsMovementGridView.RowCount - 1, "N"] = DriverComboBox.SelectedItem.ToString();

            //i = 0;
            //while (i < 11)
            //{
            //    line = (Excel.Range)excelworksheet.Rows[20 + ObjectsMovementGridView.RowCount - 1 + i];
            //    line.RowHeight = 15;
            //    i++;
            //}

            ((Excel.Worksheet)exapp.ActiveWorkbook.Sheets["ОС2"]).Select();
            exapp.Visible = true;

        }

        public void PrintM11Excel()
        {
            var excel = new Excel.Application();
            excel.Workbooks.Add(@"D:\Shablon.xltx");
            //excel.Workbooks.Open(@"D:\Shablon.xltx", Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            var excelworksheet = (Excel.Worksheet)excel.Worksheets[1]; 

            string itsSelItm = ITSSenderComboBox.SelectedItem.ToString();
            string itsResItm = ITSReceverComboBox.SelectedItem.ToString();
            
            var ITPNameandLeaderSender = (from ormList in db.tbl_Kadrovii_Sostav
                                          join ormName in db.tbl_ORM on ormList.Kod_ORM_KS equals ormName.ID_ORM
                                          where ormName.Short_Name_ORM.Equals(itsSelItm)
                                          select new { ITPLeaderName = ormList, ITPinfo = ormName }).FirstOrDefault();
            var ITPNameAndLeaderRecever = (from ormList in db.tbl_Kadrovii_Sostav
                                           join ormName in db.tbl_ORM on ormList.Kod_ORM_KS equals ormName.ID_ORM
                                           where ormName.Short_Name_ORM.Equals(itsResItm)
                                           select new { ITPLeaderName = ormList, ITPinfo = ormName, ormName.Short_Name_ORM }).ToList().FirstOrDefault();

            excelworksheet.Cells[5, "F"] = "ТРЕБОВАНИЕ-НАКЛАДНАЯ № " + NumberTTNTextBox.Text + " от " + dateTimePickerSend.Text;

            excelworksheet.Cells[9, "E"] = "0800, УКРСиПНП, ИТС, " + ITPNameandLeaderSender.ITPinfo.Full_Name_ORM + ", " + ITPNameandLeaderSender.ITPinfo.Phone_ORM;

            excelworksheet.Cells[9, "K"] = KustSenderComboBox.SelectedItem + " месторождение, куст " + KustNumbertextBox.Text;
            if (ITSSenderComboBox.SelectedItem.ToString() == "ГР ИТС")
            {
                excelworksheet.Cells[9, "K"] = "БПО УКРС и ПНП";
            }

            excelworksheet.Cells[10, "E"] = "0800, УКРСиПНП, ИТС, " + ITPNameAndLeaderRecever.ITPinfo.Full_Name_ORM + ", " + ITPNameAndLeaderRecever.ITPinfo.Phone_ORM;

            excelworksheet.Cells[10, "K"] = KustReceverComboBox.SelectedItem + " месторождение, куст " + KustNumberReceverTextBox.Text;
            if (ITSReceverComboBox.SelectedItem.ToString() == "ГР ИТС")
            {
                excelworksheet.Cells[10, "K"] = "БПО УКРС и ПНП";
            }

            excelworksheet.Cells[13, "C"] = RequestedReceverTextBox.Text + " " + RequestedReceverComboBox.SelectedItem.ToString();

            excelworksheet.Cells[13, "J"] = SenderAllowedPositionTextBox.Text + " " + SenderAllowedComboBox.SelectedItem.ToString();

            excelworksheet.Cells[12, "F"] = ReasonMovementTextBox.Text;

            excelworksheet.Cells[11, "H"] = DriverListSerialtextBox.Text;

            Excel.Range line = (Excel.Range)excelworksheet.get_Range("A19", "O20");
            line.RowHeight = 15;
            line.Font.Name = "Arial";
            line.Font.Size = 7;

            int i = 0;
            while (ObjectsMovementGridView.RowCount -1 > i) //Создание строк
            {
                //excelworksheet.Rows[19]
                line = excelworksheet.get_Range("A19", "O19").EntireRow;
                line.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                line = excelworksheet.get_Range("A19", "O19");
                line.RowHeight = 15;
                line.Font.Name = "Arial";
                line.Font.Size = 7;
                excelworksheet.get_Range("A20", "O20").Copy();
                excelworksheet.get_Range("A19", "O19").PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationAdd);
                i++;
            }

            decimal fullWeight = 0;
            int fullCount = 0;
            i = 0;
            while (ObjectsMovementGridView.RowCount > i) // заполнение строк
            {
                string temp = ObjectsMovementGridView.Rows[i].Cells[0].Value.ToString();
                var currObj = (from mod in db.tbl_Modul_Name where mod.Short_Name_Modul_Name.Equals(temp) select mod).ToList()[0];

                excelworksheet.Cells[19 + i, "A"] = i + 1;  //п.п
                excelworksheet.Cells[19 + i, "B"] = ITPNameandLeaderSender.ITPinfo.Phone_ORM; // Инв. номер ТС (телесистемы)
                excelworksheet.Cells[19 + i, "D"] = ObjectsMovementGridView.Rows[i].Cells[0].Value.ToString();  //наименование
                excelworksheet.Cells[19 + i, "G"] = ObjectsMovementGridView.Rows[i].Cells[1].Value.ToString(); //номенклатурный
                excelworksheet.Cells[19 + i, "H"] = ObjectsMovementGridView.Rows[i].Cells[2].Value.ToString(); //серийный/инвентарный
                //excelworksheet.Cells[17 + i, "I"] = currObj.Ed_Izmer; //ед измерения
                excelworksheet.Cells[19 + i, "I"] = ObjectsMovementGridView.Rows[i].Cells[3].Value.ToString(); //кол-во
                //excelworksheet.Cells[17 + i, "K"] = ""; //номер потр
                excelworksheet.Cells[19 + i, "J"] = ObjectsMovementGridView.Rows[i].Cells[5].Value.ToString(); //вид упаковки груза
                excelworksheet.Cells[19 + i, "K"] = ObjectsMovementGridView.Rows[i].Cells[3].Value.ToString(); //кол-во груза
                excelworksheet.Cells[19 + i, "L"] = ObjectsMovementGridView.Rows[i].Cells[6].Value.ToString(); //масса
                excelworksheet.Cells[19 + i, "M"] = "Взвешивание"; //способ опред массы
                excelworksheet.Cells[19 + i, "N"] = "--";
                excelworksheet.Cells[19 + i, "O"] = "--";

                fullWeight = fullWeight + Convert.ToDecimal(ObjectsMovementGridView.Rows[i].Cells[6].Value);
                fullCount = fullCount + Convert.ToInt32(ObjectsMovementGridView.Rows[i].Cells[3].Value);
                i++;
            }

            excelworksheet.Cells[20 + i - 1, "I"] = fullCount;
            excelworksheet.Cells[20 + i - 1, "K"] = fullCount;
            excelworksheet.Cells[20 + i - 1, "L"] = fullWeight.ToString();
            
            excelworksheet.Cells[25 + ObjectsMovementGridView.RowCount - 1, "B"] = SenderTextBox.Text;
            excelworksheet.Cells[25 + ObjectsMovementGridView.RowCount - 1, "F"] = SenderComboBox.SelectedItem.ToString();

            excelworksheet.Cells[38 + ObjectsMovementGridView.RowCount - 1, "C"] = "Водитель автомобиля";
            excelworksheet.Cells[38 + ObjectsMovementGridView.RowCount - 1, "F"] = DriverComboBox.SelectedItem.ToString();

            excelworksheet.Cells[28 + ObjectsMovementGridView.RowCount - 1, "J"] = "Водитель автомобиля";
            excelworksheet.Cells[28 + ObjectsMovementGridView.RowCount - 1, "N"] = DriverComboBox.SelectedItem.ToString();

            //i = 0;
            //while (i < 11)
            //{
            //    Excel.Range line = (Excel.Range)excelworksheet.Rows[19 + ObjectsMovementGridView.RowCount - 1 + i];
            //    line.RowHeight = 15;
            //    i++;
            //}
            ((Excel.Worksheet)excel.ActiveWorkbook.Sheets["М11"]).Select();
            excel.Visible = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBTTNDataSet.tbl_Current_Movement". При необходимости она может быть перемещена или удалена.
            //this.tbl_Current_MovementTableAdapter.Fill(this.dBTTNDataSet.tbl_Current_Movement);
            //AddItemsInComboBox((DataGridViewComboBoxColumn)ObjectsMovementGridView.Columns[0]);
            ITSSenderComboBox.Items.AddRange((from items in db.tbl_ORM select items.Short_Name_ORM).ToArray());
            ITSSenderComboBox.AutoCompleteCustomSource.AddRange((from items in db.tbl_ORM select items.Short_Name_ORM).ToArray());
            ITSReceverComboBox.Items.AddRange((from items in db.tbl_ORM select items.Short_Name_ORM).ToArray());
            ITSReceverComboBox.AutoCompleteCustomSource.AddRange((from items in db.tbl_ORM select items.Short_Name_ORM).ToArray());
            KustSenderComboBox.Items.AddRange((from kust in db.tbl_Mestorojdenie select kust.Name_Mestorojdenie).ToArray());
            KustSenderComboBox.AutoCompleteCustomSource.AddRange((from kust in db.tbl_Mestorojdenie select kust.Name_Mestorojdenie).ToArray());
            KustReceverComboBox.Items.AddRange((from kust in db.tbl_Mestorojdenie select kust.Name_Mestorojdenie).ToArray());
            KustReceverComboBox.AutoCompleteCustomSource.AddRange((from kust in db.tbl_Mestorojdenie select kust.Name_Mestorojdenie).ToArray());
            TypeDocumentComboBox.SelectedIndex = 0;
            //ObjectsMovementGridView.CurrentCell = ObjectsMovementGridView.Rows[ObjectsMovementGridView.RowCount -1].Cells[0];
            DriverComboBox.Items.AddRange((from drvr in db.tbl_Kadrovii_Sostav where drvr.Dolgnost_KS.Equals("Водитель автомобиля") select drvr.Familiya_KS + " " + drvr.Imya_KS.Substring(0, 1) + ". " + drvr.Otchestvo_KS.Substring(0,1) + ".").ToArray());
            //ObjectsMovementGridView.Rows[0].Height = 30;
        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            AddItemInTTNList addItem = new AddItemInTTNList(this);
            addItem.ShowDialog();
        }

        private void removeSelectedRowButton_Click(object sender, EventArgs e)
        {
            if (ObjectsMovementGridView.CurrentRow != null && ObjectsMovementGridView.CurrentRow.Index != 0)
            {
                if (MessageBox.Show("Вы уверены что хотите удалить выделенную строку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObjectsMovementGridView.Rows.Remove(ObjectsMovementGridView.CurrentRow);
                }
            }
            else
            {
                MessageBox.Show("Нельзя удалить первую строку!", "Ошибка!!!");
            }

        }

        private void removeAllRowsButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Уверены что хотите удалить ВСЕ строки?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in ObjectsMovementGridView.Rows)
                {
                    ObjectsMovementGridView.Rows.Clear();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> valFormResult = ValidateForm();
            if (valFormResult.Count == 0)
            {
                if (TypeDocumentComboBox.SelectedIndex == 1)
                {
                    PrintOS2List();
                }
                else
                {
                    PrintM11Excel();
                }
            }
            else
            {
                string errPositions = "";
                int i = 0;
                while (valFormResult.Count > i)
                {
                    errPositions += " - " + valFormResult[i] + "\r\n";
                    i++;
                }
                MessageBox.Show("Неккоректно заполены поля:\r\n\r\n" + errPositions, "Ошибка!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numberTTN = Convert.ToInt32(NumberTTNTextBox.Text);
            int alreadyExistMovementNumber = db.tbl_Movement_History.Where(x => x.Movement_History_Number == numberTTN).Count();
            if ( alreadyExistMovementNumber > 0)
            {
            if (ITSSenderComboBox.SelectedText != "" &&
                KustSenderComboBox.SelectedText != "" &&
                KustNumbertextBox.Text != "" &&
                SenderComboBox.SelectedText != "" &&
                DriverComboBox.SelectedText != "" &&
                DriverListSerialtextBox.Text != "" &&
                ObjectsMovementGridView.RowCount > 0)
            {
                string senderKadrSostName = SenderComboBox.SelectedItem.ToString().Split(' ').First();
                string senderPermicionKadrSostName = SenderAllowedComboBox.SelectedItem.ToString().Split(' ').First();
                string receverRequestKadrSostName  = RequestedReceverComboBox.SelectedItem.ToString().Split(' ').First();
                string driverKadrSostName = DriverComboBox.SelectedItem.ToString().Split(' ').First();
                
                db.tbl_Movement_History.Add(new tbl_Movement_History 
                    {
                        Data_Movement_History = DateTime.Now,
                        Kod_Sender_ORM = db.tbl_ORM.Where(x => x.Short_Name_ORM.Equals((string)ITSSenderComboBox.SelectedItem)).Select(x => x.ID_ORM).FirstOrDefault(),
                        Kod_Sender_Kadr_Sost = db.tbl_Kadrovii_Sostav.Where(x => x.Familiya_KS.Equals(senderKadrSostName)).Select(x => x.ID_KS).FirstOrDefault(),
                        Kod_Sender_Permision_Kadr_Sost = db.tbl_Kadrovii_Sostav.Where(x => x.Familiya_KS.Equals(senderPermicionKadrSostName)).Select(x => x.ID_KS).FirstOrDefault(),
                        Kod_Recever_ORM = db.tbl_ORM.Where(x => x.Short_Name_ORM.Equals((string)ITSReceverComboBox.SelectedItem)).Select(x => x.ID_ORM).FirstOrDefault(),
                        Kod_Recever_Request_Kadr_Sost = db.tbl_Kadrovii_Sostav.Where(x => x.Familiya_KS.Equals(receverRequestKadrSostName)).Select(x => x.ID_KS).FirstOrDefault(),
                        Kod_Driver_Kadr_Sost = db.tbl_Kadrovii_Sostav.Where(x => x.Familiya_KS.Equals(driverKadrSostName)).Select(x => x.ID_KS).FirstOrDefault(),
                        Kod_Driver_Movement_List = Convert.ToInt32(DriverListSerialtextBox.Text),
                        Movement_History_Number = numberTTN
                    });

                int i = 0;
                List<tbl_Movement_History_Details> liMovDet = new List<tbl_Movement_History_Details>();
                while (ObjectsMovementGridView.Rows.Count > i)
                {
                    int kodModulName = 0;
                    string nonExistInDictionaryModulName = null;
                    string modul = ObjectsMovementGridView.Rows[i].Cells[0].Value.ToString();
                    if (db.tbl_Modul_Name.Where(x => x.Short_Name_Modul_Name.Equals(modul)).Count() > 0)
                    {
                        kodModulName = db.tbl_Modul_Name.Where(x => x.Short_Name_Modul_Name.Equals(modul)).Select(x => x.ID_Modul_Name).FirstOrDefault();
                        nonExistInDictionaryModulName = null;
                    }
                    else
                    {
                        kodModulName = 0;
                        nonExistInDictionaryModulName = modul;
                    }

                    string edIzmer = ObjectsMovementGridView.Rows[i].Cells[3].Value.ToString();
                    string package = ObjectsMovementGridView.Rows[i].Cells[4].Value.ToString();
                    int countModul = (int)ObjectsMovementGridView.Rows[i].Cells[2].Value;
                    float weightModul = (float)ObjectsMovementGridView.Rows[i].Cells[5].Value;
                    string wayToGetWeight = ObjectsMovementGridView.Rows[i].Cells[5].Value.ToString();

                    liMovDet.Add(new tbl_Movement_History_Details
                    {
                        Kod_Movement_History = numberTTN,
                        Kod_Modul_Name = kodModulName,
                        Modul_Name_IF_Definition_Not_Exist_In_Dictionary = nonExistInDictionaryModulName,
                        Kod_Ed_Izmer = db.tbl_Spiski.Where(x => x.Value_Spiski.Equals(edIzmer)).Select(x => x.ID_Spiski).FirstOrDefault(),
                        Kod_Package = db.tbl_Spiski.Where(x => x.Value_Spiski.Equals(package)).Select(x => x.ID_Spiski).FirstOrDefault(),
                        Count_Modul = countModul,
                        Weight_Modul = weightModul,
                        Kod_Way_To_Get_Weight = wayToGetWeight
                    });
                    i++;
                }

                db.SaveChanges();


            }
            else
            {
                MessageBox.Show("Один или несколько пунектов не заполнены!", "Ошибка!!!");
            }
            }
            else
            {
                MessageBox.Show("ТТН с таким номером уже существует. Введите другой номер.", "Ошибка!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ITSReceverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestedReceverComboBox.Items.Clear();
            RequestedReceverComboBox.AutoCompleteCustomSource.Clear();
            RequestedReceverComboBox.Text = "";
            RequestedReceverTextBox.Text = "";
            KustReceverComboBox.Text = "";
            KustNumberReceverTextBox.Text = "";
            
            string temp = ITSReceverComboBox.SelectedItem.ToString();
            int idORM = (from ormList in db.tbl_ORM where ormList.Short_Name_ORM.Equals(temp) select ormList.ID_ORM).ToList().First();
            RequestedReceverComboBox.Items.AddRange((from ks in db.tbl_Kadrovii_Sostav where (((ks.Priority_Doljnost_KS == 2) || (ks.Priority_Doljnost_KS == 3)) && ((ks.Kod_ORM_KS == idORM) || (ks.Kod_ORM_KS == 0))) select ks.Familiya_KS + " " + ks.Imya_KS.Substring(0,1) + ". " + ks.Otchestvo_KS.Substring(0, 1)+ "." ).ToArray());
            //RequestedReceverComboBox.AutoCompleteCustomSource.AddRange();

            ITSReceverComboBox.Focus();

            if (ITSReceverComboBox.SelectedText.Equals("ГР ИТС"))
            {
                KustReceverComboBox.SelectedText = "ул. Западная";
                KustNumberReceverTextBox.Text = "3";
            }
            else
            {
                KustReceverComboBox.SelectedItem = "";
                KustNumbertextBox.Text = "";
            }
        }

        private void SenderAllowedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = SenderAllowedComboBox.SelectedItem.ToString().Split(' ').First();
            SenderAllowedPositionTextBox.Text = (from orm in db.tbl_Kadrovii_Sostav where orm.Familiya_KS.Equals(temp) select orm.Dolgnost_KS).ToList().First();
        }

        private void SenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SenderAllowedComboBox.Items.Clear();
            string temp = SenderComboBox.SelectedItem.ToString().Split(' ').First();
            int codeORM = (int)(from orm in db.tbl_Kadrovii_Sostav where orm.Familiya_KS.Equals(temp) select orm.Kod_ORM_KS).ToList().First();
            SenderAllowedComboBox.Items.AddRange((from ks in db.tbl_Kadrovii_Sostav where (((ks.Priority_Doljnost_KS == 2) || (ks.Priority_Doljnost_KS == 3)) && ((ks.Kod_ORM_KS == codeORM) || (ks.Kod_ORM_KS == 0))) select ks.Familiya_KS + " " + ks.Imya_KS.Substring(0,1) + ". " + ks.Otchestvo_KS.Substring(0, 1)+ "." ).ToArray());
            //SenderAllowedComboBox.AutoCompleteCustomSource.AddRange((from orm in db.tbl_ORM where (((orm.Priority == 2) || (orm.Priority == 3)) && ((orm.Code_ORM == codeORM) || (orm.Code_ORM == 0))) select orm.Short_Name).ToArray());
            SenderTextBox.Text = (from ks in db.tbl_Kadrovii_Sostav where ks.Familiya_KS.Equals(temp) select ks.Dolgnost_KS).ToList().First();
        }

        private void ITSSenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SenderComboBox.Items.Clear();
            SenderAllowedComboBox.Items.Clear();
            SenderComboBox.Text = "";
            SenderAllowedComboBox.Text = "";
            SenderTextBox.Text = "";
            SenderAllowedPositionTextBox.Text = "";
            KustSenderComboBox.Text = "";
            KustNumbertextBox.Text = "";
            SenderComboBox.AutoCompleteCustomSource.Clear();
            SenderAllowedComboBox.AutoCompleteCustomSource.Clear();

            string temp = ITSSenderComboBox.SelectedItem.ToString();
            int idORM = (from ormList in db.tbl_ORM where ormList.Short_Name_ORM.Equals(temp) select ormList.ID_ORM).ToList().First();
            SenderComboBox.Items.AddRange((from ks in db.tbl_Kadrovii_Sostav where ((ks.Priority_Doljnost_KS == 1) && (ks.Kod_ORM_KS == idORM)) select ks.Familiya_KS + " " + ks.Imya_KS.Substring(0, 1) + ". " + ks.Otchestvo_KS.Substring(0, 1) + ".").ToArray());
            //SenderComboBox.AutoCompleteCustomSource.AddRange((from orm in db.tbl_ORM where ((orm.Priority == 1) && (orm.Code_ORM == idORM)) select orm.Short_Name).ToArray());
            ITSSenderComboBox.Focus();

            if (ITSSenderComboBox.SelectedText.Equals("ГР ИТС"))
            {
                KustSenderComboBox.SelectedText = "ул. Западная";
                KustNumbertextBox.Text = "3";
            }
            else {
                KustSenderComboBox.SelectedItem = "";
                KustNumbertextBox.Text = "";
            }
        }

        private void RequestedReceverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = RequestedReceverComboBox.SelectedItem.ToString().Split(' ').First();
            RequestedReceverTextBox.Text = (from ks in db.tbl_Kadrovii_Sostav where ks.Familiya_KS.Equals(temp) select ks.Dolgnost_KS).ToList().First();
        }

        private void ObjectsMovementGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ObjectsMovementGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (ObjectsMovementGridView.CurrentRow != null)
            //{
            //    string temp = ObjectsMovementGridView.CurrentRow.Cells[0].Value.ToString();
            //    var items = (from item in db.tbl_Modul_Name where item.Short_Name_Modul_Name.Equals(temp) select item).ToList();
            //    if (items.Count > 0)
            //    {
            //        //ObjectsMovementGridView.CurrentRow.Cells[2].Value = "1";
            //        //ObjectsMovementGridView.CurrentRow.Cells[3].Value = items[0].Weight;
            //    }
            //}
        }

        private void NumberTTNTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumberTTNTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 59 ) && e.KeyChar != 8 && e.KeyChar != 45)
                e.Handled = true;
        }

        private void KustNumbertextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void KustNumberReceverTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void DriverListSerialtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void справочникЭлементовТСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpravochElemTS spEl = new SpravochElemTS();
            spEl.Show();
        }

        private void работникиИТПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdEditPartWorkers addPartWorkers = new AdEditPartWorkers();
            addPartWorkers.ShowDialog();
        }

        private void dBTTNDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
