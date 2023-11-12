using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttKullanimOrnekNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient mqttClient = new MqttClient("broker.hivemq.com");
            string clientId = Guid.NewGuid().ToString();

            mqttClient.Connect(clientId);
            Console.WriteLine("Abone Olundu: test/deneme2");
            while (true)
            {
                Console.WriteLine("Mesajı girin: ");
                string message = Console.ReadLine();
                string Topic = "test/deneme2";
                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            }
         
        }
    }
}
