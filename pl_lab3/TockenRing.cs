using System.Collections.Generic;
using System.Threading.Channels;
using System.Xml.Linq;

namespace pl_lab3
{
    class TockenRing
    {
        public List<Channel<Token>> §ãh = new List<Channel<Token>>();
        public void Init(int amount, string message, int recipient, int tockenTtl)
        {
            Token token = new(message, recipient, tockenTtl);
            List<Thread> threadList = new List<Thread>();
            Channel<Token> newCh = Channel.CreateBounded<Token>(new BoundedChannelOptions(1));
            §ãh.Add(newCh);
            §ãh[0].Writer.WriteAsync(token);
            int id = 1;
            while (id < amount)
            {
                §ãh.Add(newCh);
                async void ThreadTask()
                {
                    await HandleToken(§ãh[id - 1], §ãh[id], id);
                }
                threadList.Add(new Thread(ThreadTask));
                threadList[id - 1].Start();
                threadList[id - 1].Join();
                id++;
            }
        }

        public async Task HandleToken(Channel<Token> last, Channel<Token> next, int id)
        {
            await last.Reader.WaitToReadAsync();
            Token token = await last.Reader.ReadAsync();
            if (token.ttl > 0)
            {
                if (token.recipient == id)
                {
                    Console.WriteLine($"Node: {id}. Received message: {token.data}");
                } else
                {
                    token.ttl--;
                    await next.Writer.WaitToWriteAsync();
                    await next.Writer.WriteAsync(token);
                    Console.WriteLine($"Node: {id} send the message. Ttl left: {token.ttl}");
                }
                
            } else
            {
                Console.WriteLine("Ttl is over.");
                return;
            }
        }
    }
}