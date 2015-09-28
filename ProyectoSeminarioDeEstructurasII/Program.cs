using System;

namespace SeminarioDeEstructurasII {

    class MainClass {

        public static void Main(string[] args) {

            var des = new Destiny();
            int aux;
            int opc;

            do {
                Console.Clear();
                Console.WriteLine("1.-Agregar un destino");
                Console.WriteLine("2.-Mostrar destinos");
                Console.WriteLine("3.-Modificar un destino");
                Console.WriteLine("4.-Eliminar un destino");
                Console.WriteLine("5.-Buscar un destino");
                Console.WriteLine("0.-Salir");
                Console.WriteLine("Ingrese una opcion: ");
                opc = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opc) {
                    case 1:
                        des.createDestiny();
                        break;

                    case 2:
                        des.showDestinies();
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el codigo del pais a modificar");
                        aux = int.Parse(Console.ReadLine());
                        des.updateDestiny(aux);
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Ingrese el codigo del pais a eliminar");
                        aux = int.Parse(Console.ReadLine());
                        des.deleteDestiny(aux);
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Igrese el codigo del pais a buscar");
                        aux = int.Parse(Console.ReadLine());
                        des.SearchById(aux);
                        break;

                    case 0:
                        Console.WriteLine("Saliendo...");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Opcion no valida");
                        Console.ReadLine();
                        break;
                }
            } while (opc != 0);

        }
    }
}
