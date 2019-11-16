using System;
using System.Collections;
using System.Collections.Generic;

namespace dataStructureQueueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("通过Queue来模拟消息队列的实现");
            QueueTest queueTest = new QueueTest();

            while (true)
            {
                Console.WriteLine("请输入你操作的类型：1:代表生成一条消息，2：代表消费一条消息");
                string type = Console.ReadLine();
                if (type == "1")
                {
                    Console.WriteLine("请输入具体消息：");
                    string inforValue = Console.ReadLine();
                    queueTest.InformationProducer(inforValue);
                }
                else if (type == "2")
                {
                    //// 在消费消息的时候，模拟一下，消费成功与消费失败下次继续消费的场景

                    object inforValue = queueTest.InformationConsumerGet();
                    if (inforValue == null)
                    {
                        Console.WriteLine("当前无可消息可消费");
                    }
                    else
                    {
                        Console.WriteLine("获取到的消息为：" + inforValue);

                        Console.WriteLine("请输入消息消费结果：1:成功消费消息，2：消息消费失败");
                        string consumerState = Console.ReadLine();

                        ///// 备注：该操作方式线程不安全，在多线程不要直接使用
                        if (consumerState == "1")
                        {
                            queueTest.InformationConsumerDel();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("操作有误，请重新选择");
                }
            }
        }
    }

    /// <summary>
    /// 队列练习
    /// </summary>
    public class QueueTest
    {
        /// <summary>
        /// 定义一个队列
        /// </summary>
        public Queue<string> queue = new Queue<string>();

        /// <summary>
        /// 生成消息--入队列
        /// </summary>
        /// <param name="inforValue"></param>
        public void InformationProducer(string inforValue)
        {
            queue.Enqueue(inforValue);
        }

        /// <summary>
        /// 消费消息---出队列--只获取数据，不删除数据
        /// </summary>
        /// <returns></returns>
        public object InformationConsumerGet()
        {
            if (queue.Count > 0)
            {
                return queue.Peek();
            }

            return null;
        }

        /// <summary>
        /// 消费消息---出队列---获取数据的同时删除数据
        /// </summary>
        /// <returns></returns>
        public string InformationConsumerDel()
        {
            if (queue.Count > 0)
            {
                return queue.Dequeue();
            }

            return null;
        }
    }
}