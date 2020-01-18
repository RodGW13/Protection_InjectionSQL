using System.Collections.Generic;

namespace Common.Enums.Modulos
{
    public enum Nombre
    {
        paginaWeb

    }

    public class Info
    {
        public Info()
        {
            Dictionary<string, string> _uriModulos = new Dictionary<string, string>();


            _uriModulos.Add(Nombre.paginaWeb.ToString(), "Pagina PaginaInicial.aspx");
            Uri = _uriModulos;
        }

        public Dictionary<string, string> Uri { get; set; }

    }
}
