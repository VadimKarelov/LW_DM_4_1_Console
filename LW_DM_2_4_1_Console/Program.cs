using System;

namespace LW_DM_4_1_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            Console.WriteLine($"Расстояние между городами 1 и 8 = {graph.SearchMinLength(0, 7)}");
            Console.WriteLine($"Расстояние между городами 1 и 6 = {graph.SearchMinLength(0, 5)}");
            Console.WriteLine($"Расстояние между городами 4 и 8 = {graph.SearchMinLength(3, 7)}");
            Console.WriteLine($"Расстояние между городами 2 и 6 = {graph.SearchMinLength(1, 5)}");
        }
    }
}