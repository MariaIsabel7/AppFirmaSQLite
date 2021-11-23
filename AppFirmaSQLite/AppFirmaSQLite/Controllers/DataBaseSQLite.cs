using AppFirmaSQLite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppFirmaSQLite.Controllers
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        // Constructor de la clase DataBaseSQLite

        public DataBaseSQLite(String pathdb)
        {

            // Crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            // Creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Firma>().Wait();
        }

        // Operaciones CRUD con SQLite
        // READ List Way

        public Task<List<Firma>> ObtenerListaFirmas()
        {
            return db.Table<Firma>().ToListAsync();
        }

        //READ one by one
        public Task<Firma> ObtenerFirmas(int pcodigo)
        {
            return db.Table<Firma>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }


        // CREATE persona
        public Task<int> GrabarFrimas(Firma firma)
        {
            if (firma.codigo != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }
        }

        //DELETE

        public Task<int> EliminarFirmas(Firma firma)
        {
            return db.DeleteAsync(firma);
        }


    }

}
