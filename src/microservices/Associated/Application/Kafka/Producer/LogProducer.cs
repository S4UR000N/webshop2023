//using Confluent.Kafka;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _Application.Kafka.Producer
//{
//    public class LogProducer
//    {
//        public void mymethod()
//        {
//            const string topic = "purchases";

//            string[] users = { "eabara", "jsmith", "sgarcia", "jbernard", "htanaka", "awalther" };
//            string[] items = { "book", "alarm clock", "t-shirts", "gift card", "batteries" };

//            using (var producer = new ProducerBuilder<string, string>(configuration.AsEnumerable()).Build())
//            {
//                producer.Produce(topic, new Message<string, string> { Key = user, Value = item },
//                    (deliveryReport) =>
//                    {
//                        if (deliveryReport.Error.Code != ErrorCode.NoError)
//                        {
//                            Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
//                        }
//                        else
//                        {
//                            Console.WriteLine($"Produced event to topic {topic}: key = {user,-10} value = {item}");
//                            numProduced += 1;
//                        }
//                    });

//                Console.WriteLine($"{numProduced} messages were produced to topic {topic}");
//            }
//    }
//}
