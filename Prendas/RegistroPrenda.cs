using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prendas
{
    internal class RegistroPrenda
    { 
  public string TipoPrenda { get; set; }
    public string Marca { get; set; }
    public string Talla { get; set; }
    public string Precio { get; set; }


    public RegistroPrenda(string tipoPrenda, string marca, string talla, string precio)
    {
        TipoPrenda = tipoPrenda;
        Marca = marca;
        Talla = talla;
        Precio = precio;
    }

    public static void Registrar(List<RegistroPrenda> prendas, string marca, string tipo, string talla, string precio)
    {
        RegistroPrenda prenda = new RegistroPrenda(marca, tipo, talla, precio);
        prendas.Add(prenda);
    }


    public static List<RegistroPrenda> Cargar(string filePath)
    {

        return new List<RegistroPrenda>();
    }
}
}

