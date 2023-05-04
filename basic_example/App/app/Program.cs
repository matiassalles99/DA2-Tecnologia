using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Console.WriteLine("Bienvienido a la app de reflection");
            while (input != "S")
            {
                try
                {
                    Console.WriteLine("Ingrese la ruta del assembly");
                    input = Console.ReadLine();
                    //recorro el contenido del assembly, es a modo de ejemplo
                    //para poder entender como esta estructurado un assembly y los comandos para navegarlo
                    InspectAssembly(input);
                    Console.WriteLine("Ingrese el texto que desea guardar");
                    string toSave= Console.ReadLine();
                    Console.WriteLine("Ingrese la ruta donde desea guardar");
                    string route = Console.ReadLine();
                    InstanceAndExecuteLog(input, toSave, route);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Algo salío mal, vuelve a intentarlo.." + e.ToString());
                }
            }

        }

        private static void InstanceAndExecuteLog(string input, string toSave, string route)
        {
            Assembly myAssembly = Assembly.LoadFile(input);

            //Cargo todas las clases que implementen Ilogger
            IEnumerable<Type> implementations = GetTypesInAssembly<ILogger>(myAssembly);
            Console.WriteLine(implementations.Count());
            //Instancio la primera de la lista(en este ejemplo la única)  
            ILogger logInstance = (ILogger)Activator.CreateInstance(implementations.FirstOrDefault());
            logInstance.Log(toSave, route);
        }

        private static IEnumerable<Type> GetTypesInAssembly<Interface>(Assembly myAssembly)
        {
            List<Type> types = new List<Type>();
            foreach(var type in myAssembly.GetTypes())
            {
                if(typeof(Interface).IsAssignableFrom(type))
                {
                    types.Add(type);
                }
            }
            return types;
        }

        private static void InspectAssembly(string input)
        {
            // Cargamos el assembly en memoria
            Assembly myAssembly = Assembly.LoadFile(input);
            // Mostraremos toda la info del assembly

            foreach (Type tipo in myAssembly.GetTypes())
            {
                Console.WriteLine(string.Format("Clase: {0}", tipo.Name));

                Console.WriteLine("Fields");
                foreach (FieldInfo prop in tipo.GetFields())
                {
                    Console.WriteLine(string.Format("\t{0} : {1}", prop.Name, prop.FieldType.Name));
                }

                Console.WriteLine("Propiedades");
                foreach (PropertyInfo prop in tipo.GetProperties())
                {
                    Console.WriteLine(string.Format("\t{0} : {1}", prop.Name, prop.PropertyType.Name));
                }

                Console.WriteLine("Constructores");
                foreach (ConstructorInfo con in tipo.GetConstructors())
                {
                    Console.Write("\tConstructor: ");
                    foreach (ParameterInfo param in con.GetParameters())
                    {
                        Console.Write(string.Format("{0} : {1} ", param.Name, param.ParameterType.Name));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Metodos");
                foreach (MethodInfo met in tipo.GetMethods())
                {
                    Console.Write(string.Format("\t{0} ", met.Name));
                    foreach (ParameterInfo param in met.GetParameters())
                    {
                        Console.Write(string.Format("{0} : {1} ", param.Name, param.ParameterType.Name));
                    }
                    Console.WriteLine();                               
                }
                Console.WriteLine();
            }
        }
    }
}
