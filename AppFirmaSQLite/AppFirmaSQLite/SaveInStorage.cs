using System;
using System.Collections.Generic;
using System.Text;

namespace AppFirmaSQLite
{
    public interface SaveInStorage
    {
        string SaveImage(byte[] bytedata);
    }
}
