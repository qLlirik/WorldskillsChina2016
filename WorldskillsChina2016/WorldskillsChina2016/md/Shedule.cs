//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldskillsChina2016.md
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shedule
    {
        public int ID { get; set; }
        public Nullable<int> CompetitionID { get; set; }
        public Nullable<int> Day { get; set; }
        public Nullable<System.DateTime> DateExecution { get; set; }
        public Nullable<System.TimeSpan> TimeStart { get; set; }
        public Nullable<System.TimeSpan> TimeEnd { get; set; }
        public string Definition { get; set; }
        public string Comment { get; set; }
        public Nullable<int> ChampionshipID { get; set; }
    
        public virtual Championship Championship { get; set; }
        public virtual Competition Competition { get; set; }
    }
}
