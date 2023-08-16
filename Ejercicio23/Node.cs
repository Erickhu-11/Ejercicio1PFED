using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio23
{
    public class Node
    {
        public int Valor { get; set; }
        public Node? Siguiente { get; set; }

        public Node(int value)
        {
            Valor = value;
            Siguiente = null;
        }
    }

}
