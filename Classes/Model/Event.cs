//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UIKitTutorials.Classes.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int idEvent { get; set; }
        public Nullable<int> idType { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Name { get; set; }
        public Nullable<int> idPlace { get; set; }
    
        public virtual Place Place { get; set; }
        public virtual TypeEvent TypeEvent { get; set; }
    }
}