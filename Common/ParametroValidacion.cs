using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ParametrosValidacion
    {
        /// <summary>
        /// Validamos la entrada de los parametros del cliente si coincide con la lista negra
        /// retorna falso de lo contrario la cadena es valida y retorna true
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool ValidoEntrada(string parametro)
        {
            bool res = true;
            string[] cadenaString = new string[] { "1=1", "1=0", "0=1", "0=0", ";"  ,   "+" , "||" + "'",
                                                  "select","update" ,"create" ,"from" ,"delete" , "sleep" ,"grant" ,"and","case","when","not","end"};

            foreach (string s in cadenaString)
            {

                switch (parametro.Contains(s.ToUpper()))
                {
                    case true:
                        res = false;
                        break;
                }

            }


            return res;
        }

   
    }
}


