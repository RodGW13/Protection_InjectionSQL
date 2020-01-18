using Common.Logging;
using System;

namespace Persistencia
{
    public class PersonaDAL
    {
        Common.ParametrosValidacion parametrosValidacion = new Common.ParametrosValidacion();
        public static ILogging traza = new Logging();
        public string ObtenerNombreParam(string nombre)
        {
            string resultado = string.Empty;
            try
            {
                //validamos la entrada y si esta en la lista negra nos saltara la excepción asi evitamos
                //que el ataque se concrete en la base de datos si no es asi ejecutamos la llamada del procedimiento almacenado
                if (parametrosValidacion.ValidoEntrada(nombre) == false)
                {
                    throw new Exception("Error en la cadena del parametro SP intento de SQLInjection parametros: " + nombre);
                }
            }
            catch (Exception ex)
            {
                traza.Error("Ha ocurrido un Error " + " parametros:" + nombre + " " + ex.Message, Common.Enums.Modulos.Nombre.paginaWeb);
                throw ex;
            }
            return resultado;
        }
    }
}
