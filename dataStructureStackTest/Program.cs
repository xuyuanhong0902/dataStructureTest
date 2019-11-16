using System;
using System.Collections.Generic;

namespace dataStructureStackTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 通过栈来模拟浏览器回退前进操作
            ////   1、定义两个栈，分别记录回退的地址集合，和前进地址集合
            ////   2、在操作具体的回退或者前进操作时
            ////      如果和前一次操作相同，那么就取出对应队列的一条数据存储到另外一个队列
            Console.WriteLine("本练习模拟浏览器的回退前进操作：");

            /// 假设浏览器已浏览了20个网站记录
            StackTest stackTestBack = new StackTest(20);
            StackTest stackTestGo = new StackTest(20);
            for (int i = 0; i < 20; i++)
            {
                stackTestBack.PushStack("网站" + (i + 1).ToString());
            }

            //// 记录上一次操作
            string beforOpert = "";
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("请输入你操作的类型：1:回退，2：前进");
                string type = Console.ReadLine();

                if (type == "1")
                {
                    //// 出栈
                    if (beforOpert == type)
                    {
                        stackTestGo.PushStack(stackTestBack.GetAndDelStack());
                    }
                    string wbeSit = stackTestBack.GetStack();
                    Console.WriteLine("回退到页面：" + wbeSit);
                    beforOpert = type;
                }
                else if (type == "2")
                {
                    //// 出栈
                    if (beforOpert == type)
                    {
                        stackTestBack.PushStack(stackTestGo.GetAndDelStack());
                    }
                    string wbeSit = stackTestGo.GetStack();

                    Console.WriteLine("回退到页面：" + wbeSit);
                    beforOpert = type;
                }
                else
                {
                    Console.WriteLine("请输入正确的操作方式！！");
                }
            }
        }
    }

    /// <summary>
    /// 队列练习
    /// </summary>
    public class StackTest
    {
        /// <summary>
        /// 定义一个栈
        /// </summary>
        public Stack<string> stack;

        /// <summary>
        ///无参数构造函数，栈初始化为默认长度
        /// </summary>
        public StackTest()
        {
            stack = new Stack<string>();
        }

        /// <summary>
        ///有参数构造函数，栈初始化为指定长度
        ///如果在定义队列时，如果知道需要存储的数据长度，那么最好预估一个长度，并初始化指定的长度
        /// </summary>
        public StackTest(int stackLen)
        {
            stack = stackLen > 0 ? new Stack<string>(stackLen) : new Stack<string>();
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="inforValue"></param>
        public void PushStack(string inforValue)
        {
            stack.Push(inforValue);
        }

        /// <summary>
        /// 出栈（但不删除）
        /// </summary>
        /// <returns></returns>
        public string GetStack()
        {
            if (stack.Count > 0)
            {
                return stack.Peek();
            }

            return null;
        }

        /// <summary>
        /// 出栈（并删除）
        /// </summary>
        /// <returns></returns>
        public string GetAndDelStack()
        {
            if (stack.Count > 0)
            {
                return stack.Pop();
            }

            return null;
        }
    }
}
