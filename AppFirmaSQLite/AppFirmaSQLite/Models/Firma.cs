using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFirmaSQLite.Models
{
    public class Firma
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        [MaxLength(70)]
        public string nombre { get; set; }

        [MaxLength(70)]
        public string descripcion { get; set; }

        public byte[] firma { get; set; }
    }
}
