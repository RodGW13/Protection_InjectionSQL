using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using Common;

namespace Common.Logging
{
    public class Logging : ILogging
    {

        public Logging()
        {


        }


        private static string _USUARIO_ = string.Empty;
        public Logging(string user)
        {
            if (string.IsNullOrEmpty(_USUARIO_))
            {
                _USUARIO_ = user;
            }

        }


        public override void Error(string message, Common.Enums.Modulos.Nombre module)
        {
            WriteEntry(message, Common.Enums.NivelError.Tipo.Error, module, null);
        }

        public override void CriticalError(Exception ex, string message, Enums.Modulos.Nombre module)
        {
            WriteEntry(message, Enums.NivelError.Tipo.CriticalError, module, ex);
        }

        public override void Error(Exception ex, Enums.Modulos.Nombre module)
        {
            WriteEntry(ex.Message, Enums.NivelError.Tipo.Error, module, ex);
        }

        public override void Warning(string message, Enums.Modulos.Nombre module)
        {
            WriteEntry(message, Enums.NivelError.Tipo.Advertencia, module, null);
        }

        public override void Info(string message, Enums.Modulos.Nombre module)
        {
            WriteEntry(message, Enums.NivelError.Tipo.Informacion, module, null);
        }

        private void writeLine(string _evento)
        {

            try
            {


                string fileName = ConfigurationManager.AppSettings["LOG"] + DateTime.Now.ToString("ddMMyyyy") + "_eventos.log";
                FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);

                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(_evento);



                //writer.WriteLine("Esta es la primera línea del archivo.");
                writer.Close();
                stream.Close();

            }
            catch
            {

            }
        }

      

        private void WriteEntry(string message, Enums.NivelError.Tipo type, Enums.Modulos.Nombre module, Exception ex)
        {

            Enums.Modulos.Info uriModulos = new Enums.Modulos.Info();
            writeLine(
                    string.Format("{1} - {2} - {0}: {3}",
                                  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                  type,
                                  uriModulos.Uri[module.ToString()],
                                  message));

            if (type == Enums.NivelError.Tipo.CriticalError || type == Enums.NivelError.Tipo.Error)
            {
                if (ex != null)
                {
                    writeLine(string.Format("{1} - {2} - {0}: {3}, ****Exeption Mesagge: {4}  ****** Stack trace: {5}",
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                      type,
                                      uriModulos.Uri[module.ToString()],
                                      message, ex.InnerException, ex.StackTrace));

                    new EnvioMail().Send("Error - Proyecto", ConfigurationManager.AppSettings["CUENTA_CORREO"], string.Format("{0},{1},{2},{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, uriModulos.Uri[module.ToString()], message));
                }
                else
                {

                    writeLine(string.Format("{1} - {2} - {0}: {3}, ****Exeption Mesagge: {4}  ****** Stack trace: {5}",
                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                      type,
                                      uriModulos.Uri[module.ToString()],
                                      message, "", ""));

                    new EnvioMail().Send("Error - Proyecto", ConfigurationManager.AppSettings["CUENTA_CORREO"], string.Format("{0},{1},{2},{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, uriModulos.Uri[module.ToString()], message));


                }
            }



        }

    }
}
