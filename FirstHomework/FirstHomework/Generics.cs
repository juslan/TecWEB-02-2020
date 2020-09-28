using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace FirstHomework.Generics
{
    public class MyQueue<T>
    {
        private T[] nodes;
        private int emptySpot;
        public int current { get; set; }

        public MyQueue(int size)
        {
            nodes = new T[size];
            this.current = 0;
            this.emptySpot = 0;
        }

        public void Enqueue(T value)
        {
            nodes[emptySpot] = value;
            emptySpot++;
            if (emptySpot >= nodes.Length)
            {
                emptySpot = 0;
            }
        }
        public T Dequeue()
        {
            int ret = current;
            current++;
            if (current >= nodes.Length)
            {
                current = 0;
            }
            return nodes[ret];
        }
    }
    public static class Tester
    {
        public static void Test()
        {
            var stringQueue = new MyQueue<string>(3);//queue de string
            for(int i = 0; i < 3; i++)
            {
                stringQueue.Enqueue("Hola");
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{stringQueue.Dequeue()}");
                
            }
            Console.WriteLine("-------------------");

            var butacaQueue = new MyQueue<Butaca>(2);
            butacaQueue.Enqueue(new Butaca()
            {
                MemberName = "Juslan",
                MemberAge = 20,
                sec = Sector.Preferencia
            });
            butacaQueue.Enqueue(new Butaca()
            {
                MemberName = "Peter",
                MemberAge = 22,
                sec = Sector.General
            });
            for (int i = 0; i < 2; i++)
            {
                var but = butacaQueue.Dequeue();
                Console.WriteLine($"nombre: {but.MemberName}");
                Console.WriteLine($"edad: {but.MemberAge}");
                Console.WriteLine($"sector: {but.sec}");
            }
        }
    }
}
