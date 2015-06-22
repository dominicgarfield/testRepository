using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanwellQuizBingo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        static Random _random = new Random();

        public static int[] RandomizeIntArray(int[] arr)
        {
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            // Add all strings from array
            // Add new random int each time
            foreach (int i in arr)
            {
                list.Add(new KeyValuePair<int, int>(_random.Next(), i));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            int[] result = new int[arr.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, int> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        }
    }
}
