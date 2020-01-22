using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dotNETtask10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintLoadedAssemblies();
            Console.ReadLine();
        }

        private static void PrintLoadedAssemblies()
        {
            Console.WriteLine("Список загруженных сборок:");
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine($"-> {asm.GetName().Name}");
            }
            Assembly assembly = Assembly.Load("dotNETTask8");
            Type inverserType = assembly.GetType("dotNETtask8.Inverser");
            object inverser = Activator.CreateInstance(inverserType);
            MethodInfo mi = inverserType.GetMethod("Inverse");
            MethodInfo sin = typeof(Math).GetMethod("Sin");
            //Delegate del = Delegate.CreateDelegate(typeof(Math.Sin),sin);
            _ = mi.Invoke(inverser, new object[] { 0, Math.PI / 2, Math.Sin(0), 0.0001 });
        }    
        public double f(double x)
        {
            return Math.Sin(x);
        }
    }
}
