//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OS2List
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Movement_History
    {
        public int ID_History { get; set; }
        public Nullable<int> Movement_History_Number { get; set; }
        public Nullable<int> Kod_Sender_ORM { get; set; }
        public Nullable<int> Kod_Sender_Kadr_Sost { get; set; }
        public Nullable<int> Kod_Sender_Permision_Kadr_Sost { get; set; }
        public Nullable<int> Kod_Recever_ORM { get; set; }
        public Nullable<int> Kod_Recever_Request_Kadr_Sost { get; set; }
        public Nullable<int> Kod_Driver_Kadr_Sost { get; set; }
        public Nullable<long> Kod_Driver_Movement_List { get; set; }
        public Nullable<System.DateTime> Data_Movement_History { get; set; }
        public Nullable<int> Movement_History_Details { get; set; }
    }
}
