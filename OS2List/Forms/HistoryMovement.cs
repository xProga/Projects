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

namespace OS2List.Forms
{
    public partial class HistoryMovement : Form
    {
        public HistoryMovement()
        {
            InitializeComponent();
        }

        private class HistoryTTN
        {
            public DateTime Date { get; set; }
            public int NumberTTN { get; set; }
            public string SenderPartNumber { get; set; }
            public string SenderFIO { get; set; }
            public string SenderPermissionFIO { get; set; }
            public string DriverFIO { get; set; }
            public string DriverCarNumber { get; set; }
            public long DriverListNumber { get; set; }
            public string RequestedPartNumber { get; set; }
            public string RequestedFIO { get; set; }

            public static List<HistoryTTN> GetHistoryTTN(DateTime date)
            {
                List<HistoryTTN> liHTTN = new List<HistoryTTN>();
                using (DBTTNEntities db = new DBTTNEntities())
                {
                    var history = db.tbl_Movement_History.Where(x => x.Data_Movement_History.Equals(date)).ToList();
                    int i = 0;
                    while (history.Count > i)
                    {
                        liHTTN.Add(new HistoryTTN
                        {
                            Date = date,
                            SenderPartNumber = db.tbl_ORM.Where(x => x.ID_ORM == (int)history[i].Kod_Sender_ORM).Select(x => x.Short_Name_ORM).FirstOrDefault(),
                            SenderFIO = db.tbl_Kadrovii_Sostav.Where(x => x.ID_KS == (int)history[i].Kod_Sender_Kadr_Sost).Select(x => x.Familiya_KS + " " + x.Imya_KS.Substring(0, 1) + ". " + x.Otchestvo_KS.Substring(0,1) + ".").FirstOrDefault(),
                            SenderPermissionFIO = db.tbl_Kadrovii_Sostav.Where(x => x.ID_KS == (int)history[i].Kod_Sender_Permision_Kadr_Sost).Select(x => x.Familiya_KS + " " + x.Imya_KS.Substring(0, 1) + ". " + x.Otchestvo_KS.Substring(0, 1) + ".").FirstOrDefault(),
                            DriverFIO = db.tbl_Kadrovii_Sostav.Where(x => x.ID_KS == (int)history[i].Kod_Driver_Kadr_Sost).Select(x => x.Familiya_KS + " " + x.Imya_KS.Substring(0, 1) + ". " + x.Otchestvo_KS.Substring(0, 1) + ".").FirstOrDefault(),
                            DriverListNumber = (long)history[i].Kod_Driver_Movement_List,
                            DriverCarNumber = "1",
                            NumberTTN = (int)history[i].Movement_History_Number,
                            RequestedFIO = db.tbl_Kadrovii_Sostav.Where(x => x.ID_KS == (int)history[i].Kod_Recever_Request_Kadr_Sost).Select(x => x.Familiya_KS + " " + x.Imya_KS.Substring(0, 1) + ". " + x.Otchestvo_KS.Substring(0, 1) + ".").FirstOrDefault(),
                            RequestedPartNumber = db.tbl_ORM.Where(x => x.ID_ORM == (int)history[i].Kod_Recever_ORM).Select(x => x.Short_Name_ORM).FirstOrDefault()
                        });
                        i++;
                    }
                }
                return liHTTN;
            }
        }

        private class HistoryDetails
        {
            //public int MovementNumber { get; set; }
            public string ModulName { get; set; }
            public string ZavodInventNumber { get; set; }
            public int Count { get; set; }
            public string EdIzmer { get; set; }
            public string Package { get; set; }
            public float Weight { get; set; }
            public string WayToGetWeight { get; set; }

            public static List<HistoryDetails> GetDetailsHistory(int numberTTN)
            { 
                List<HistoryDetails> liHDeet = new List<HistoryDetails>();
                using (DBTTNEntities db = new DBTTNEntities())
                {
                    var hDet = db.tbl_Movement_History_Details.Where(x => x.Kod_Movement_History == numberTTN).ToList();

                    int i = 0;
                    while (hDet.Count > 0)
                    {
                        string modulName = null;
                        if (db.tbl_Modul_Name.Where(x => x.ID_Modul_Name == (int)hDet[i].Kod_Modul_Name).Count() > 0)
                        {
                            modulName = db.tbl_Modul_Name.Where(x => x.ID_Modul_Name == (int)hDet[i].Kod_Modul_Name).Select(x => x.Short_Name_Modul_Name).FirstOrDefault();
                        }
                        else
                        {
                            modulName = hDet[i].Modul_Name_IF_Definition_Not_Exist_In_Dictionary;
                        }

                        liHDeet.Add(new HistoryDetails
                        {
                            ModulName = modulName,
                            ZavodInventNumber = hDet[i].Zavod_Invent_Number,
                            Count = (int)hDet[i].Count_Modul,
                            EdIzmer = db.tbl_Spiski.Where(x => x.ID_Spiski == (int)hDet[i].Kod_Ed_Izmer).Select(x => x.Value_Spiski).FirstOrDefault(),
                            Package = db.tbl_Spiski.Where(x => x.ID_Spiski == (int)hDet[i].Kod_Package).Select(x => x.Value_Spiski).FirstOrDefault(),
                            Weight = hDet[i].Weight_Modul.Value,
                            WayToGetWeight = hDet[i].Kod_Way_To_Get_Weight
                        });
                        i++;
                    }
                }

                return liHDeet;
            }
        }

        //private void ShowTTNExcelFile(HistoryMovement historyMovement, string documentType)
        //{
        //    var excel = new Excel.Application();
        //    excel.Workbooks.Add(@"");
        //    var excelworksheet = excel.Worksheets[1];

        //    string itsSelItm = ITSSenderComboBox.SelectedItem.ToString();
        //    string itsResItm = ITSReceverComboBox.SelectedItem.ToString();

        //    var ITPNameandLeaderSender = (from ormList in db.tbl_Kadrovii_Sostav
        //                                  join ormName in db.tbl_ORM on ormList.Kod_ORM_KS equals ormName.ID_ORM
        //                                  where ormName.Short_Name_ORM.Equals(itsSelItm)
        //                                  select new { ITPLeaderName = ormList, ITPinfo = ormName }).FirstOrDefault();
        //    var ITPNameAndLeaderRecever = (from ormList in db.tbl_Kadrovii_Sostav
        //                                   join ormName in db.tbl_ORM on ormList.Kod_ORM_KS equals ormName.ID_ORM
        //                                   where ormName.Short_Name_ORM.Equals(itsResItm)
        //                                   select new { ITPLeaderName = ormList, ITPinfo = ormName, ormName.Short_Name_ORM }).ToList().FirstOrDefault();

        //    excelworksheet.Cells[5, "A"] = "НАКЛАДНАЯ № " + NumberTTNTextBox.Text + " от " + dateTimePickerSend.Text + " г.";

        //    excelworksheet.Cells[9, "D"] = "0800, УКРСиПНП, ИТС, " + ITPNameandLeaderSender.ITPinfo.Full_Name_ORM + ", " + ITPNameandLeaderSender.ITPinfo.Phone_ORM;

        //    excelworksheet.Cells[11, "D"] = KustSenderComboBox.SelectedItem + " " + KustNumbertextBox.Text;

        //    excelworksheet.Cells[13, "D"] = "0800, УКРСиПНП, ИТС, " + ITPNameAndLeaderRecever.ITPinfo.Full_Name_ORM + ", " + ITPNameAndLeaderRecever.ITPinfo.Phone_ORM;

        //    excelworksheet.Cells[15, "D"] = KustReceverComboBox.SelectedItem + " " + KustNumberReceverTextBox.Text;

        //    excelworksheet.Cells[17, "D"] = DriverListSerialtextBox.Text;

        //    int i = 0;
        //    while (ObjectsMovementGridView.RowCount - 2 > i) //Создание строк
        //    {
        //        excelworksheet.get_Range("A23", "O23").Copy();
        //        Excel.Range line = (Excel.Range)excelworksheet.Rows[18];
        //        line.Insert();
        //        line = (Excel.Range)excelworksheet.Rows[18 + i];
        //        line.RowHeight = 15;
        //        i++;
        //    }

        //    decimal fullWeight = 0;
        //    int fullCount = 0;
        //    i = 0;
        //    while (ObjectsMovementGridView.RowCount - 1 > i) // заполнение строк
        //    {
        //        string temp = ObjectsMovementGridView.Rows[i].Cells[0].Value.ToString();
        //        var currObj = (from mod in db.tbl_Modul_Name where mod.Short_Name_Modul_Name.Equals(temp) select mod).ToList()[0];

        //        excelworksheet.Cells[17 + i, "A"] = i + 1;  //п.п
        //        excelworksheet.Cells[17 + i, "B"] = ObjectsMovementGridView.Rows[i].Cells[0].Value.ToString();  //наименование
        //        excelworksheet.Cells[17 + i, "D"] = ITPNameandLeaderSender.ITPinfo.Phone_ORM; // Инв. номер ТС (телесистемы)
        //        excelworksheet.Cells[17 + i, "G"] = ObjectsMovementGridView.Rows[i].Cells[1].Value.ToString(); //серийный/инвентарный
        //        //excelworksheet.Cells[17 + i, "I"] = currObj.Ed_Izmer; //ед измерения
        //        excelworksheet.Cells[17 + i, "I"] = ObjectsMovementGridView.Rows[i].Cells[2].Value.ToString(); //кол-во
        //        //excelworksheet.Cells[17 + i, "K"] = ""; //номер потр
        //        excelworksheet.Cells[17 + i, "J"] = "Контейнер"; //вид упаковки груза
        //        excelworksheet.Cells[17 + i, "K"] = ObjectsMovementGridView.Rows[i].Cells[2].Value.ToString(); //кол-во груза
        //        excelworksheet.Cells[17 + i, "L"] = ObjectsMovementGridView.Rows[i].Cells[3].Value.ToString(); //масса
        //        excelworksheet.Cells[17 + i, "M"] = "Взвешивание"; //способ опред массы

        //        fullWeight = fullWeight + Convert.ToDecimal(ObjectsMovementGridView.Rows[i].Cells[3].Value);
        //        fullCount = fullCount + Convert.ToInt32(ObjectsMovementGridView.Rows[i].Cells[2].Value);
        //        i++;
        //    }

        //    excelworksheet.Cells[24 + i - 1, "I"] = fullCount;
        //    excelworksheet.Cells[24 + i - 1, "K"] = fullCount;
        //    excelworksheet.Cells[24 + i - 1, "L"] = fullWeight.ToString();

        //    excelworksheet.Cells[26, "G"] = ReasonMovementTextBox.Text;
        //    excelworksheet.Cells[32 + ObjectsMovementGridView.RowCount - 1, "B"] = SenderTextBox.Text;
        //    excelworksheet.Cells[32 + ObjectsMovementGridView.RowCount - 1, "F"] = SenderComboBox.SelectedItem.ToString();

        //    excelworksheet.Cells[39 + ObjectsMovementGridView.RowCount - 1, "C"] = "Водитель автомобиля";
        //    excelworksheet.Cells[39 + ObjectsMovementGridView.RowCount - 1, "F"] = DriverComboBox.SelectedItem.ToString();

        //    excelworksheet.Cells[32 + ObjectsMovementGridView.RowCount - 1, "J"] = "Водитель автомобиля";
        //    excelworksheet.Cells[32 + ObjectsMovementGridView.RowCount - 1, "N"] = DriverComboBox.SelectedItem.ToString();

        //    i = 0;
        //    while (i < 11)
        //    {
        //        Excel.Range line = (Excel.Range)excelworksheet.Rows[20 + ObjectsMovementGridView.RowCount - 1 + i];
        //        line.RowHeight = 15;
        //        i++;
        //    }

        //}

        private void GetHistoryDataGrid(DateTime date)
        {
            List<HistoryTTN> liHTTN = HistoryTTN.GetHistoryTTN(date);

            int i = 0;
            while (liHTTN.Count > i)
            {
                CreatedTTNDataGridView.Rows.Add(liHTTN[i].Date, liHTTN[i].NumberTTN, 
                    liHTTN[i].SenderPartNumber, liHTTN[i].SenderFIO, liHTTN[i].SenderPermissionFIO, 
                    liHTTN[i].DriverFIO, liHTTN[i].DriverCarNumber, liHTTN[i].DriverListNumber, 
                    liHTTN[i].RequestedPartNumber, liHTTN[i].RequestedFIO);
                i++;
            }
        }

        private void GetDetailsHistoryDataGrid(int numberTTN)
        { 
            List<HistoryDetails> liHistDetailsTTN = HistoryDetails.GetDetailsHistory(numberTTN);

            int i = 0;
            while (liHistDetailsTTN.Count > 0)
            {
                DetailsCreatedTTNDataGridView.Rows.Add(liHistDetailsTTN[i].ModulName, liHistDetailsTTN[i].ZavodInventNumber, 
                    liHistDetailsTTN[i].Count, liHistDetailsTTN[i].EdIzmer, liHistDetailsTTN[i].Package, 
                    liHistDetailsTTN[i].Weight, liHistDetailsTTN[i].WayToGetWeight);
                i++;
            }
        }

        private void HistoryMovement_Load(object sender, EventArgs e)
        {
            GetHistoryDataGrid(SentTTNDateTimePicker.Value);
            DetailsCreatedTTNDataGridView.Rows.Clear();
        }

        private void CreatedTTNDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CreatedTTNDataGridView.Rows[e.RowIndex].Selected = true;
            GetDetailsHistoryDataGrid((int)CreatedTTNDataGridView.Rows[e.RowIndex].Cells[1].Value);
        }

        private void ShowTTNButton_Click(object sender, EventArgs e)
        {

        }

        private void SentTTNDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            GetHistoryDataGrid(SentTTNDateTimePicker.Value);
            DetailsCreatedTTNDataGridView.Rows.Clear();
        }
    }
}
