using System;
using System.Reflection;

namespace Questions.QuestionFiles.CSharp.SingletonObjectComparison
{
    public class SingletonObjectCompare
    {
        public static void CreateTwoConstructorsOfSingletonClass()
        {
            var instance = MySingletonClass.Instance;
            var instanceA = MySingletonClass.Instance;
            Console.WriteLine(instance.GetHashCode() == instanceA.GetHashCode() ?
                "Same obj" : "Diff obj");

            var constructor = typeof(MySingletonClass).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            var singleton2 = (MySingletonClass)constructor.Invoke(null);
            Console.WriteLine(instance.GetHashCode() == singleton2.GetHashCode() ?
                "Same obj" : "Diff obj");







            //var className = nameof(MySingletonClass);
            //Type type = Type.GetType(className, true);
            //object instance1 = Activator.CreateInstance(type, true);
            //Console.WriteLine($"first instance hashcode {instance1.GetHashCode()}");
            //object instance2 = Activator.CreateInstance(type, true);
            //Console.WriteLine($"second instance hashcode {instance2.GetHashCode()}");


        }

        #region Completed
        #endregion
    }

    public sealed class MySingletonClass : ICloneable
    {
        private MySingletonClass()
        {
            if (Nested.instance!=null)
                throw new Exception("Cannot create singleton instance multiple times.");
        }

        public static MySingletonClass Instance { get { return Nested.instance; } }

        public object Clone()
        {
            throw new Exception("Cannot allow cloning of singleton class.");
        }

        private class Nested
        {
            private static readonly object Instancelock = new object();
            private static MySingletonClass objectInstance;

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static MySingletonClass instance
            {
                get
                {
                    if (objectInstance == null)
                    {
                        lock (Instancelock)
                        {
                            if (objectInstance == null)
                            {
                                objectInstance = new MySingletonClass();
                            }
                        }

                    }
                    return objectInstance;
                }
            }
        }
    }
}
