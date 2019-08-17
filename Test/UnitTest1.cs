using System;
using System.Threading;
using AirTicketBusiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ProducerConsumerTest
    {
        [TestMethod]
        public void ProducerConsumer()
        {
            ProducerConsumer pc = new ProducerConsumer();
            while(!pc.IsDoneReading || !pc.IsDoneWriting)
            {
                Thread.Sleep(1000);
            }
            int a = 0;
        }
    }
}
