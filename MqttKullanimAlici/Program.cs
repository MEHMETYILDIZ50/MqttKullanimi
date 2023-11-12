using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttKullanimAlici
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient mqttClient = new MqttClient("broker.hivemq.com");
            mqttClient.MqttMsgPublishReceived += client_recievedMessage;

            string clientId = Guid.NewGuid().ToString();
            mqttClient.Connect(clientId);
            Console.WriteLine("Abone Olundu: test/deneme2");

            mqttClient.Subscribe(new String[] { "test/deneme2" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        }
        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Alınan Mesaj: " + message);
        }
    }
}
