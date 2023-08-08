using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1_Proyecto_Final_ED
{
    class Program
    {
        static Postre[] postres = new Postre[10];
        static int cantidadPostres = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Gestión de Postres");
                Console.WriteLine("A) Mostrar ingredientes de un postre");
                Console.WriteLine("B) Agregar ingredientes a un postre");
                Console.WriteLine("C) Eliminar ingredientes de un postre");
                Console.WriteLine("D) Agregar un nuevo postre");
                Console.WriteLine("E) Eliminar un postre");
                Console.WriteLine("X) Salir");
                Console.Write("Selecciona una opción: ");
                char opcion = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                switch (opcion)
                {
                    case 'A':
                        MostrarIngredientes();
                        break;

                    case 'B':
                        AgregarIngredientes();
                        break;

                    case 'C':
                        EliminarIngredientes();
                        break;

                    case 'D':
                        AgregarPostre();
                        break;

                    case 'E':
                        EliminarPostre();
                        break;

                    case 'X':
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }

        static void MostrarIngredientes()
        {
            Console.Write("Ingrese el nombre del postre: ");
            string nombrePostre = Console.ReadLine();

            Postre postre = BuscarPostre(nombrePostre);
            if (postre != null)
            {
                Console.WriteLine($"Ingredientes del {postre.Nombre}:");

                foreach (string ingrediente in postre.Ingredientes)
                {
                    Console.WriteLine("- " + ingrediente);
                }
            }
            else
            {
                Console.WriteLine("El postre no existe.");
            }
        }

        static void AgregarIngredientes()
        {
            Console.Write("Ingrese el nombre del postre: ");
            string nombrePostre = Console.ReadLine();

            Postre postre = BuscarPostre(nombrePostre);
            if (postre != null)
            {
                Console.WriteLine($"Ingrese los ingredientes separados por comas para {postre.Nombre} (ejemplo: ingrediente1, ingrediente2, ingrediente3): ");
                string[] nuevosIngredientes = Console.ReadLine().Split(',');

                foreach (string nuevoIngrediente in nuevosIngredientes)
                {
                    string ingrediente = nuevoIngrediente.Trim();
                    if (!string.IsNullOrEmpty(ingrediente))
                    {
                        postre.Ingredientes.Add(ingrediente);
                    }
                }

                Console.WriteLine("Ingredientes agregados exitosamente.");
            }
            else
            {
                Console.WriteLine("El postre no existe.");
            }
        }

        static void EliminarIngredientes()
        {
            Console.Write("Ingrese el nombre del postre: ");
            string nombrePostre = Console.ReadLine();

            Postre postre = BuscarPostre(nombrePostre);
            if (postre != null)
            {
                Console.WriteLine($"Ingredientes del {postre.Nombre}:");

                for (int i = 0; i < postre.Ingredientes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {postre.Ingredientes[i]}");
                }

                Console.WriteLine("Ingrese los números de los ingredientes a eliminar separados por comas (ejemplo: 1, 3, 5): ");
                string[] numerosIngredientesEliminar = Console.ReadLine().Split(',');

                List<int> indicesEliminar = new List<int>();
                foreach (string numero in numerosIngredientesEliminar)
                {
                    if (int.TryParse(numero.Trim(), out int indice) && indice >= 1 && indice <= postre.Ingredientes.Count)
                    {
                        indicesEliminar.Add(indice - 1);
                    }
                }

                indicesEliminar.Sort();
                indicesEliminar.Reverse();

                foreach (int indiceEliminar in indicesEliminar)
                {
                    postre.Ingredientes.RemoveAt(indiceEliminar);
                }

                Console.WriteLine("Ingredientes eliminados exitosamente.");
            }
            else
            {
                Console.WriteLine("El postre no existe.");
            }
        }

        static void AgregarPostre()
        {
            if (cantidadPostres >= 10)
            {
                Console.WriteLine("Capacidad máxima de postres alcanzada. No se pueden agregar más postres.");
                return;
            }

            Console.Write("Ingrese el nombre del nuevo postre: ");
            string nombreNuevoPostre = Console.ReadLine();

            Postre postreExistente = BuscarPostre(nombreNuevoPostre);
            if (postreExistente == null)
            {
                Console.WriteLine($"Ingrese los ingredientes separados por comas para {nombreNuevoPostre} (ejemplo: ingrediente1, ingrediente2, ingrediente3): ");
                string[] nuevosIngredientes = Console.ReadLine().Split(',');

                List<string> ingredientes = new List<string>();
                foreach (string nuevoIngrediente in nuevosIngredientes)
                {
                    string ingrediente = nuevoIngrediente.Trim();
                    if (!string.IsNullOrEmpty(ingrediente))
                    {
                        ingredientes.Add(ingrediente);
                    }
                }

                Postre nuevoPostre = new Postre(nombreNuevoPostre, ingredientes);
                postres[cantidadPostres] = nuevoPostre;
                cantidadPostres++;

                Console.WriteLine("Postre agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("El postre ya existe.");
            }
        }

        static void EliminarPostre()
        {
            Console.Write("Ingrese el nombre del postre a eliminar: ");
            string nombrePostreEliminar = Console.ReadLine();

            Postre postreEliminar = BuscarPostre(nombrePostreEliminar);
            if (postreEliminar != null)
            {
                for (int i = 0; i < cantidadPostres; i++)
                {
                    if (postres[i] == postreEliminar)
                    {
                        for (int j = i; j < cantidadPostres - 1; j++)
                        {
                            postres[j] = postres[j + 1];
                        }
                        postres[cantidadPostres - 1] = null;
                        cantidadPostres--;

                        Console.WriteLine("Postre eliminado exitosamente.");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("El postre no existe.");
            }
        }

        static Postre BuscarPostre(string nombrePostre)
        {
            for (int i = 0; i < cantidadPostres; i++)
            {
                if (postres[i].Nombre.Equals(nombrePostre, StringComparison.OrdinalIgnoreCase))
                {
                    return postres[i];
                }
            }
            return null;
        }
    }

    class Postre
    {
        public string Nombre { get; }
        public List<string> Ingredientes { get; } = new List<string>();

        public Postre(string nombre, List<string> ingredientes)
        {
            Nombre = nombre;
            Ingredientes = ingredientes;
        }
    }
}

