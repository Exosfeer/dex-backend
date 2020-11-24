using RabbitMQ.Client;
using System;
using System.Text;
using NotificationSystem.Contracts;
using RabbitMQ.Client.Events;
using Serilog;

namespace NotificationSystem.Services
{
    public interface IRabbitMQListener
    {
        EventingBasicConsumer CreateConsumer(INotificationService notificationService);
        void StartConsume(EventingBasicConsumer consumer, string subject);
    }
    public class RabbitMQListener : IRabbitMQListener
    {
        private readonly IModel channel;

        public RabbitMQListener(IModel channel)
        {
            this.channel = channel;
        }

        public EventingBasicConsumer CreateConsumer(INotificationService notificationService)
        {
            Console.WriteLine("Before creating Consumer");
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                try
                {
                    if(notificationService != null)
                    {
                        notificationService.ValidateMessageBody(message);
                        notificationService.SendNotification(message);
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        Console.WriteLine("Delivered");
                    } else
                    {
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        Console.WriteLine("Delivered");
                    }
                    
                } catch(Exception e)
                {
                    throw e;
                }
            };
            Console.WriteLine("After creating Consumer");
            return consumer;
        }

        public void StartConsume(EventingBasicConsumer consumer, string subject)
        {
            Console.WriteLine("Before starting consument");
            channel.BasicConsume(queue: subject,
                autoAck: false,
                consumer: consumer);
            Console.WriteLine("After starting consument");
            Console.ReadLine();
        }
    }
}