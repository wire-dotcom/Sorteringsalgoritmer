using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleoleApp5
{
    class Program
    {
        static void SelectionSort(List<int> myList)
        {
            int temp, smallest;
            for (int i = 0; i < myList.Count - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < myList.Count; j++)
                {
                    if (myList[j] < myList[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = myList[smallest];
                myList[smallest] = myList[i];
                myList[i] = temp;

            }
        }
        static void BubbleSort(List<int> myList)
        {
            for (int i = 0; i < myList.Count; i++) // Räkna antal genomgångar
            {
                for (int j = 0; j < myList.Count - 1; j++) // Gå igenom alla element i listan
                {
                    if (myList[j] > myList[j + 1]) //om elementen ligger i fel ordning
                    {
                        //byt plats på myList[j] och myList[j+1]
                        int temp = myList[j];
                        myList[j] = myList[j + 1];
                        myList[j + 1] = temp;
                    }
                }

            }
        }
        static void SkapaSlumpLista(List<int> myList, int size)
        {
            Random slump = new Random();

            for (int i = 0; i < size; i++) //skapar ett stort antal slumpt
            {
                myList.Add(slump.Next(1000000));
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Hur lång ska listan vara?");
            string answer = Console.ReadLine();

            List<int> tallista = new List<int>();

            SkapaSlumpLista(tallista, Convert.ToInt32(answer));

            Stopwatch SelectionTime = new Stopwatch();
            SelectionTime.Start();
            SelectionSort(tallista);
            SelectionTime.Stop();
            TimeSpan tsSelection = SelectionTime.Elapsed;
            string elapsedTimeSelection = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           tsSelection.Hours, tsSelection.Minutes, tsSelection.Seconds,
           tsSelection.Milliseconds / 10);
            Console.WriteLine("SelectionSort tid: " + elapsedTimeSelection);


            SkapaSlumpLista(tallista, Convert.ToInt32(answer));
            Stopwatch BubbleTime = new Stopwatch();
            BubbleTime.Start();
            BubbleSort(tallista);
            BubbleTime.Stop();
            TimeSpan tsBubble = BubbleTime.Elapsed;
            string elapsedTimeBubble = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           tsBubble.Hours, tsBubble.Minutes, tsBubble.Seconds,
           tsBubble.Milliseconds / 10);
            Console.WriteLine("BubbleSort tid: " + elapsedTimeBubble);



        }
    }
}
