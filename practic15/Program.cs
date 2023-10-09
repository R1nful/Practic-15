namespace practic15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateThread(new ObjArray("Круто", 100, 100));
            CreateThread(new ObjArray("Вау", 10, 100));
            CreateThread(new ObjArray("C#", 300, 50));
        }

        private static void Method(object s)
        {
            ObjArray obAr = s as ObjArray;

            for (int i = 0; i < obAr.Count; i++)
            {
                Console.WriteLine($"Текст: {obAr.Smb}  \tID потока: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(obAr.Delay);
            }
        }

        private static void CreateThread(ObjArray objAr)
        {
            ParameterizedThreadStart pt = new ParameterizedThreadStart(Method);
            Thread thread = new Thread(pt);
            thread.Start(objAr);
        }
    }

    class ObjArray
    {
        public string Smb { get; set; }
        public int Delay { get; set; }
        public int Count { get; set; }

        public ObjArray(string smb, int delay, int count)
        {
            Smb = smb;
            Delay = delay;
            Count = count;
        }
    }
}