using Ejercicio23;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedListCompleter listCompleter = new LinkedListCompleter();


        Console.Write("Ingrese el valor de inicio: ");
        int valorInicial = int.Parse(Console.ReadLine());


        Console.Write("Ingrese el valor final: ");
        int valorFinal = int.Parse(Console.ReadLine());


        listCompleter.Agregar(valorInicial);
            
        listCompleter.CompleteList(valorFinal);

        Console.WriteLine("Lista completa:");
        listCompleter.PrintList();
    }
}

public class LinkedListCompleter
{
    public Node Cabeza { get; set; }

    public LinkedListCompleter()
    {
        Cabeza = null;
    }

    public void Agregar(int value)
    {
        if (Cabeza == null)
        {
            Cabeza = new Node(value);
        }
        else
        {
            Node actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = new Node(value);
        }
    }

    public void CompleteList(int valorFinal)
    {
        Node actual = Cabeza;
        int valorSiguiente = Cabeza.Valor + 1;

        while (valorSiguiente <= valorFinal)
        {
            if (actual.Siguiente == null || actual.Siguiente.Valor > valorSiguiente)
            {
                Node newNode = new Node(valorSiguiente);
                newNode.Siguiente = actual.Siguiente;
                actual.Siguiente = newNode;
            }
            actual = actual.Siguiente;
            valorSiguiente++;
        }
    }

    public void PrintList()
    {
        Node actual = Cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}