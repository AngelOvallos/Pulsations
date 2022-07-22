using Logic;
using Entity;
using System;
using System.Collections.Generic;


namespace Pulsaciones
{
    class Program
    {
        private static readonly PersonService personService = new PersonService();
        static void Main(string[] args)
        {
            char follow = 'S';
            do
            {
                int opcion = Menu();
                switch (opcion)
                {
                    case 1: Save();
                        break

                    case 2: Consult();
                        break;

                    case 3: Search();
                        break;

                    case 4: follow = 'N';
                        break;

                }
            }while (follow == 'S');
        }

        public static int Menu()
        {
            Console.Clear();
            int op;
            Console.WriteLine("-------------Software de Registro de Pulsaciones--------------");
            Console.WriteLine("-------------Programando con La Sofia-----------");
            Console.WriteLine("1. Registrar.");
            Console.WriteLine("2. Consultar.");
            Console.WriteLine("3. Buscar.");
            Console.WriteLine("4. Salir.");
            do
            {
                Console.Write("Escoja una opción: ");
                op = int.Parse(Console.ReadLine());
            }while (op < 1|| op > 4);
            return op;
        }

        public static string Save()
        {
            Console.Clear();
            Console.WriteLine("---------Ingreso de Datos---------");
            var person = DataCapture();
            string message = personService.Save(person);
            Console.WriteLine(message);
        }

        public static void Consult()
        {
            Console.Clear();
            Console.WriteLine("----------Consulta de Datos------");
            var answer = personService.Consult();
            if (answer.Error)
            {
                Console.WriteLine(answer.Message);
            }
            else
            {
                foreach (var item in answer.People)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("-------------------");
                }
            }
        }

        private static Person DataCapture()
        {
            Console.Write("Id: ");
            string id = Console.ReadLine();
            Console.Write("Primer nombre: ");
            string name = Console.ReadLine();
            Console.Write("Primer apellido: ");
            string lastName = Console.ReadLine();
            Console.Write("Edad: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Genero (M/F): ");
            string genre = Console.ReadLine();
            person = new(id, name, lastName, age, genre);
            person.CalculatePulsation();
            Console.WriteLine($"Pulsación estimada por 10 segundos de Ejercicio: {person.Pulsacion}");
            return person;
        }
    }
}
