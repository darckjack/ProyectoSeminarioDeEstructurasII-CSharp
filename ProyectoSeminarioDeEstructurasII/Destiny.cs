using System;
using System.IO;

namespace SeminarioDeEstructurasII {
    public class Destiny {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Aviability { get; set; }
        public bool TypeOfDes { get; set; }
        public bool Tax { get; set; }
        public const string DestiniesFile = "destinos.dat";
        public const string TempFile = "temporal.dat";

        public Destiny() {
            Id = 100;
            Name = "";
            Aviability = false;
            TypeOfDes = false;
            Tax = false;
        }

        public void createDestiny() {
            var outfile = new BinaryWriter(File.OpenWrite(DestiniesFile));
            char opc;

            Console.WriteLine("Ingrese el nombre del destino");
            Name = Console.ReadLine();

            Console.WriteLine("El destino esta disponible? s/n");
            opc = char.Parse(Console.ReadLine());

            if (opc == 'S' || opc == 's') {
                Aviability = true;
            } else {
                Aviability = false;
            }

            Console.WriteLine("El destino es un pais de entrada? s/n");
            opc = char.Parse(Console.ReadLine());

            if (opc == 'S' || opc == 's') {
                TypeOfDes = true;
            } else {
                TypeOfDes = false;
            }

            Console.WriteLine("El destino requiere impuesto extra? s/n");
            opc = char.Parse(Console.ReadLine());

            if (opc == 'S' || opc == 's') {
                Tax = true;
            } else {
                Tax = false;
            }

            Id = Id + 1;

            outfile.Seek((int)outfile.BaseStream.Length, SeekOrigin.Begin);
            outfile.Write(Id);
            outfile.Write(Name);
            outfile.Write(Aviability);
            outfile.Write(TypeOfDes);
            outfile.Write(Tax);

            outfile.Close();
        }

        public void showDestinies() {

            if (File.Exists(DestiniesFile)) {
                var inFile = new BinaryReader(File.OpenRead(DestiniesFile));


                while (inFile.BaseStream.Position < inFile.BaseStream.Length) {

                    Id = inFile.ReadInt32();
                    Name = inFile.ReadString();
                    Aviability = inFile.ReadBoolean();
                    TypeOfDes = inFile.ReadBoolean();
                    Tax = inFile.ReadBoolean();

                    Console.WriteLine("Codigo: {0}", Id);
                    Console.WriteLine("Nombre: {0}", Name);

                    if (Aviability) {
                        Console.WriteLine("El destino esta disponible");
                    } else {
                        Console.WriteLine("El destino no esta disponible");
                    }

                    if (TypeOfDes) {
                        Console.WriteLine("El pais es un pais de entrada");
                    } else {
                        Console.WriteLine("El pais no es un pais de entrada");
                    }

                    if (Tax) {
                        Console.WriteLine("El destino requiere un impuesto extra");
                    } else {
                        Console.WriteLine("El destino no requiere un impuesto extra");
                    }

                    Console.WriteLine();
                }

                inFile.Close();
            } else {
                Console.WriteLine("El archivo {0} no existe...", DestiniesFile);
            }
        }

        public void updateDestiny(int id) {

            var outfile = new BinaryWriter(File.OpenWrite(TempFile));
            var inFile = new BinaryReader(File.OpenRead(DestiniesFile));
            char opc;

            if (File.Exists(DestiniesFile)) {

                while (inFile.BaseStream.Position < inFile.BaseStream.Length) {

                    Id = inFile.ReadInt32();
                    Name = inFile.ReadString();
                    Aviability = inFile.ReadBoolean();
                    TypeOfDes = inFile.ReadBoolean();
                    Tax = inFile.ReadBoolean();

                    if (Id != id) {

                        outfile.Seek((int)outfile.BaseStream.Length, SeekOrigin.Begin);
                        outfile.Write(Id);
                        outfile.Write(Name);
                        outfile.Write(Aviability);
                        outfile.Write(TypeOfDes);
                        outfile.Write(Tax);

                    } else {

                        Console.WriteLine("Ingrese el nombre del destino");
                        Name = Console.ReadLine();

                        Console.WriteLine("El destino esta disponible? s/n");
                        opc = char.Parse(Console.ReadLine());

                        if (opc == 'S' || opc == 's') {
                            Aviability = true;
                        } else {
                            Aviability = false;
                        }

                        Console.WriteLine("El destino es un pais de entrada? s/n");
                        opc = char.Parse(Console.ReadLine());

                        if (opc == 'S' || opc == 's') {
                            TypeOfDes = true;
                        } else {
                            TypeOfDes = false;
                        }

                        Console.WriteLine("El destino requiere impuesto extra? s/n");
                        opc = char.Parse(Console.ReadLine());

                        if (opc == 'S' || opc == 's') {
                            Tax = true;
                        } else {
                            Tax = false;
                        }

                        outfile.Seek((int)outfile.BaseStream.Length, SeekOrigin.Begin);
                        outfile.Write(Id);
                        outfile.Write(Name);
                        outfile.Write(Aviability);
                        outfile.Write(TypeOfDes);
                        outfile.Write(Tax);
                    }


                }

                outfile.Close();
                inFile.Close();
                File.Delete(DestiniesFile);
                File.Copy(TempFile, DestiniesFile);
                File.Delete(TempFile);

                Console.WriteLine("Los cambios se han aplicado con exito");
                Console.ReadLine();
            } else {
                Console.WriteLine("El archivo {0} no existe", DestiniesFile);
                Console.ReadLine();
            }
        }

        public void deleteDestiny(int id) {
            var outfile = new BinaryWriter(File.OpenWrite(TempFile));
            var inFile = new BinaryReader(File.OpenRead(DestiniesFile));

            if (File.Exists(DestiniesFile)) {

                while (inFile.BaseStream.Position < inFile.BaseStream.Length) {

                    Id = inFile.ReadInt32();
                    Name = inFile.ReadString();
                    Aviability = inFile.ReadBoolean();
                    TypeOfDes = inFile.ReadBoolean();
                    Tax = inFile.ReadBoolean();

                    if (Id != id) {

                        outfile.Seek((int)outfile.BaseStream.Length, SeekOrigin.Begin);
                        outfile.Write(Id);
                        outfile.Write(Name);
                        outfile.Write(Aviability);
                        outfile.Write(TypeOfDes);
                        outfile.Write(Tax);
                    }
                }

                outfile.Close();
                inFile.Close();

                File.Delete(DestiniesFile);
                File.Copy(TempFile, DestiniesFile);
                File.Delete(TempFile);

                Console.WriteLine("Los cambios se guardaron con exito");
                Console.ReadLine();
            } else {
                Console.WriteLine("El archivo {0} no se pudo abrir", DestiniesFile);
                Console.ReadLine();
            }
        }

        public void SearchById(int id) {
            var inFile = new BinaryReader(File.OpenRead(DestiniesFile));

            if (File.Exists(DestiniesFile)) {

                while (inFile.BaseStream.Position < inFile.BaseStream.Length) {

                    Id = inFile.ReadInt32();
                    Name = inFile.ReadString();
                    Aviability = inFile.ReadBoolean();
                    TypeOfDes = inFile.ReadBoolean();
                    Tax = inFile.ReadBoolean();

                    if (Id == id) {

                        Console.WriteLine("Codigo: {0}", Id);
                        Console.WriteLine("Nombre: {0}", Name);

                        if (Aviability) {
                            Console.WriteLine("El destino esta disponible");
                        } else {
                            Console.WriteLine("El destino no esta dispoible");
                        }

                        if (TypeOfDes) {
                            Console.WriteLine("El destino es un pais de entrada");
                        } else {
                            Console.WriteLine("El destino no es un pais de entrada");
                        }

                        if (Tax) {
                            Console.WriteLine("El destino requiere un impuesto extra");
                        } else {
                            Console.WriteLine("El destino no requiere impuesto extra");
                        }

                        Console.ReadLine();
                    }
                }

                inFile.Close();
            } else {
                Console.WriteLine("El archivo {0} no pudo abrirse", DestiniesFile);
            }
        }
    }
}