namespace pl_lab3
{
    class Program
    {
        static void Main()
        {
            Random rnd = new();
            TockenRing ring = new();

            int amount = rnd.Next(10, 50);
            string message = "hello";
            int recipient = rnd.Next(1, 10);
            int tockenTtl = rnd.Next(10, 20);

            Console.WriteLine("amount: " + amount);
            Console.WriteLine("message: " + message);
            Console.WriteLine("recipient: " + recipient);
            Console.WriteLine("ttl: " + tockenTtl);

            ring.Init(amount, message, recipient, tockenTtl);
        }
    }
}