using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class CategoriaModelo
    {
        private Int64 id;
        private string desigCategoria;
        public Int64 Id { get => id; set => id = value; }
        public string DesigCategoria { get => desigCategoria; set => desigCategoria = value; }
    }
}
