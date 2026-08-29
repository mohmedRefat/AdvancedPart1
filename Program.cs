using System;

namespace AdvancedPart1
{


    /*
    Q1


    generic class : class that can work with different data types without writing the same class mulitple times 
        we use it for code resualbility , type safety , prevent boxin and unboxing

    /*

    Q2
    */

    public class Container<T>
    {
        private T data;



        public void Add(T value)
        {
            data = value;
        }



        public T Get()
        {
            return data;
        }
    }



    /*
    Q3
    multiple type parameters means that generic class can work  with more than data type
    */

    public class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }



        /*
        Q4
        Generic method :method that can work with different data types using type parameter

        */

        public static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;

            first = second;

            second = temp;
        }



        /*
        Q5
          we need to use Icomparable  so the method can compare the values with each other

        */

        public static T FindMax<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) > 0)
            {
                return first;
            }

            return second;
        }


        /*
        Q6
        Generic interface :interface that can work with different data type using generic type parameter

    

        */

        public interface IRepository<T>
        {
            void Add(T item);

            T Get();
        }



        /*
        Q7
        Means that t must be value type
        */

        public class ValContainer<T>
            where T : struct
        {
            public T Data { get; set; }
        }



        /*
        Q8
        class Constrains : means that t must be reference type

        */

        public class RefeContainer<T>
            where T : class
        {
            public T Data { get; set; }
        }



        /*
        Q9
        new() :constrains means that t mush have public parametless constructor,it allows u to create object using t()

    
        */

        public class CreateInstance<T>
            where T : new()
        {
            public T Create()
            {
                return new T();
            }
        }



        /*
        Q10
        means that T must implement the interface



        */

        public interface IPrintable
        {
            void Print();
        }


        public class Printer<T>
            where T : IPrintable
        {
            public void PrintData(T data)
            {
                data.Print();
            }
        }



        /*
        Q11
        It means that T must inherif from base class 

        */

        public class Animal
        {
            public void Eat()
            {
                Console.WriteLine("AM Eating wow");
            }
        }


        public class AnimalContainer<T>
            where T : Animal
        {
            public void MakeAnimalEat(T animal)
            {
                animal.Eat();
            }
        }



        /*
        Q12
        we write more that one constrain like T must be
        1 Class 
       2 Implement Iprintalbe
        3 Have paameterless constructor
      
        */

        public class MultiConstraint<T>
            where T : class, IPrintable, new()
        {
            public T Create()
            {
                return new T();
            }
        }



        /*
        Q13
        default returns the default value of T
        
        for int default = 0 , for string default = null

        */

        public static T GetDefault<T>()
        {
            return default;
        }



        /*
        Q14
        */

        public class SafeList<T>
        {
            private List<T> items = new List<T>();


            // Add item

            public void Add(T item)
            {
                items.Add(item);
            }


            // Get item

            public T Get(int index)
            {
                if (index >= 0 && index < items.Count)
                {
                    return items[index];
                }

                return default;
            }
        }



        /*
        Q15
        covariance allows u to use more derived typ where a base type is expected

        The 'out' keyword is used for covariance
        with generic interfaces and delegates.
        out : is keyword user for covarince with generic interface
        */

        public interface IProducer<out T>
        {
            T Get();
        }



        /*
        Q16
        Contravariance allows u to use a base type
        where a more derived type is expected

        in is a keyword  used for contravariance.
        */

        public interface IConsumer<in T>
        {
            void Consume(T data);
        }



        /*
        Q17
        covariance use out and works with return valus  


        contravariance uses inand works with input paramters

        */



        /*
        Q18
        Each constructed generic type has its own static members
    
        */

        public class MyClass<T>
        {
            public static int Count;

            public MyClass()
            {
                Count++;
            }
        }



        /*
        Q19
         class can inherit from a generic class by specifying the type parameter
        */

        public class GenericBase<T>
        {
            public T Data { get; set; }
        }


        public class IntChild : GenericBase<int>
        {
        }



        /*
        Q20
        Complete Exercise

        */

        public class Cache<TKey, TValue>
        {
            private class CacheItem
            {
                public TValue Value { get; set; }

                public DateTime ExpirationTime { get; set; }
            }


            private Dictionary<TKey, CacheItem> items =
                new Dictionary<TKey, CacheItem>();


            // Add item

            public void Add(
                TKey key,
                TValue value,
                TimeSpan expiration)
            {
                CacheItem item = new CacheItem();

                item.Value = value;

                item.ExpirationTime =
                    DateTime.Now.Add(expiration);

                items[key] = item;
            }


            // Get item

            public TValue Get(TKey key)
            {
                if (!items.ContainsKey(key))
                {
                    return default;
                }


                CacheItem item = items[key];


                // Check expiration

                if (DateTime.Now >= item.ExpirationTime)
                {
                    items.Remove(key);

                    return default;
                }


                return item.Value;
            }


            // Remove item

            public bool Remove(TKey key)
            {
                return items.Remove(key);
            }


            // Check if item exists

            public bool Contains(TKey key)
            {
                if (!items.ContainsKey(key))
                {
                    return false;
                }


                CacheItem item = items[key];


                // Check expiration

                if (DateTime.Now >= item.ExpirationTime)
                {
                    items.Remove(key);

                    return false;
                }


                return true;
            }
        }




    }
}
