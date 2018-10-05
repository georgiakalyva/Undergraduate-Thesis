using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;


namespace ThesisMobile.DataModel
{
    [Table("Setting")]
    public class Setting
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Description { get; set; }

    }
}
