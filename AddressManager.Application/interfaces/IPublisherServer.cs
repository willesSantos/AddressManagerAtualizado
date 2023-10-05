using Google.Cloud.PubSub.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManager.Application.interfaces
{
    public interface IPublisherServer
    {
        public Task<string> CreateTopic(string nomaTopic, string mensagem, string projectid);
        public Task<string> CreateSubscriber(TopicName nomaTopic, string mensagem, string projectid);
    }
}
