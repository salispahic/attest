using AirTicketBusiness.Service;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirTicketBusiness.Domain
{
    public class Consumer
    {
        private ProducerConsumer _producerConsumer;

        public Consumer(ProducerConsumer pc)
        {
            _producerConsumer = pc;
        }

        public void Process()
        {
            Thread.Sleep(100);
            do
            {
                //_producerConsumer.lollypop.WaitOne();
                HtmlFileWriter hfw = new HtmlFileWriter(_producerConsumer.GetConfigurationReader().GetHtmlFilesDirectory(), _producerConsumer.GetConfigurationReader().GetResourcesDirectory(), _producerConsumer.FileSystemHelper);
                IStackItem item = null;
                while (_producerConsumer.Queue.TryDequeue(out item))
                {
                    hfw.WriteHtmlFile(item);
                    // do stuff
                }
                _producerConsumer.IsDoneWriting = true;
            } while (!_producerConsumer.IsDoneReading || !_producerConsumer.Queue.IsEmpty);
        }
    }
}
