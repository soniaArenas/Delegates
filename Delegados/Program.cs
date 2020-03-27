using System;

namespace Delegados
{
    class Program
    {   //Declarar delegado
        public delegate void Del(string message);
        static void Main(string[] args)
        {
            //Instanciar delegado
            Del handler = DelegateMethod;

            //Llamada delegado
            handler("Hellow Wordl");

            MethodWithCallBack(1, 2, handler);

            MethodClass obj = new MethodClass();

            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;
            
            // creamos nuevo delegado, dos maneras de hacerlo
            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;

            allMethodsDelegate("Llamando a delegados");

            //Quitar método
            allMethodsDelegate -= d1;

            allMethodsDelegate("Llamando a delegados");

            //copiar mientras se remueve d2
            Del oneMethodDelegate = allMethodsDelegate - d2;

        }
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
        public static void MethodWithCallBack(int param1, int param2, Del Callback)
        {
            Callback("The number is: " + (param1 + param2).ToString());
        }
    }
    public class MethodClass
    {
        public void Method1(string message) { }
        public void Method2(string message) { }
    }
}
