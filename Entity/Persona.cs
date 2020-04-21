using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public decimal Pulsaciones
        {
            get
            {
                if (Sexo.Equals("F")|| Sexo.Equals("f"))
                {
                    return (220-Edad)/10;
                } else
                {
                    return (210 - Edad) / 10;
                } 

                    
            }
        }

        public override string ToString()
        {
            return $"Identificación:{Identificacion} --- Nombre:{Nombre} --- Edad:{Edad} --- Sexo:{Sexo} --- Pulsaciones:{Pulsaciones}";
        }
    }
}
