namespace DZ11
{
    /// <summary>
    /// 11я домашка по OUTUS. OtusDictionary. dev-barnch
    /// </summary>
    class DZ11
    {
        /// <summary>
        /// Тестирование словаря.
        /// </summary>
        /// <param name="args"></param>
        public static void  Main(string[] args)
        {
           
            OtusDictionary dictionary = new OtusDictionary(true, (string s) => Console.WriteLine(s));
            dictionary.Add(18, "lwejhvbwherjvf");
            Console.ReadKey();
            dictionary.Add(10, "lwejhvbwherjvf");
            Console.ReadKey();
            dictionary.Add(50, "qwdfqweqewf");

            Console.WriteLine("\n\n * * * CHECK RESULTS * * * \n\n");
            Console.WriteLine($" key = 18 => {dictionary.Get(18)} \n key = 10 => {dictionary.Get(10)} \n key = 50 => {dictionary.Get(50)}");

        }

    }
}