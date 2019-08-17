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
    public class Producer
    {
        private ProducerConsumer _producerConsumer;

        public Producer(ProducerConsumer pc)
        {
            _producerConsumer = pc;

        }

        public void Process()
        {

            XmlFileReader xfr = new XmlFileReader(_producerConsumer.GetConfigurationReader().GetXmlFilesDirectory(), _producerConsumer.GetConfigurationReader().GetXmlFilesProcessedDirectory(), _producerConsumer.FileSystemHelper); ;
            int numberOfFiles = _producerConsumer.GetConfigurationReader().GetXmlFilesDirectory().GetFiles().Length;
            while (xfr.GetNextStackItem() != null)
            {
                IStackItem si = xfr.GetNextStackItem();
                _producerConsumer.Queue.Enqueue(si);
                //_producerConsumer.lollypop.Set();
                _producerConsumer.IsDoneReading = false;
            }
            _producerConsumer.IsDoneReading = true;
        }
    }
}
