using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public  abstract class ILogging
    {
       
         public  abstract void Error(string message, Enums.Modulos.Nombre module);

         public  abstract void CriticalError(Exception ex, string message, Enums.Modulos.Nombre module);

         public  abstract void Error(Exception ex, Enums.Modulos.Nombre module);

         public  abstract void Warning(string message, Enums.Modulos.Nombre module);

         public  abstract void Info(string message, Enums.Modulos.Nombre module);
        

    }
}
