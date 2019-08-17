using AirTicketBusiness.Domain;
using AirTicketBusiness.Service;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirTicketBusiness
{
    public class ProducerConsumer
    {
        Producer _producer;
        Consumer _consumer;

        public ConcurrentQueue<IStackItem> Queue;

        public ConfigurationReader GetConfigurationReader()
        {
            return new ConfigurationReader();
        }

        public IFileSystemHelper FileSystemHelper { get; set; }
        public bool IsDoneReading;
        public bool IsDoneWriting;

        public ProducerConsumer()
        {
            FileSystemHelper = new FileSystemHelper();
            Queue = new ConcurrentQueue<IStackItem>();
            _producer = new Producer(this);
            _consumer = new Consumer(this);
            IsDoneReading = false;
            IsDoneWriting = false;

            Thread thread = new Thread(new ThreadStart(_producer.Process));
            thread.Start();
            Thread thread2 = new Thread(new ThreadStart(_consumer.Process));
            thread2.Start();

            thread.Join();
            thread2.Join();
        }

    }
}
