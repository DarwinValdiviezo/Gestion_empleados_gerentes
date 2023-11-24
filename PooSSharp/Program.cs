using System;
using System.Collections.Generic;
// 1. Definición de Clases:
// Define una clase Empleado con los siguientes atributos:
class Empleado : MostrarInformacion
{
    public string Nombre { get; set; }
    public double Salario { get; set; }
    public Empleado(string nombre, double salario)
    {
        Nombre = nombre;
        Salario = salario;
    }
    // Implementación en la clase `Empleado` para calcular el salario anual.
    public virtual double CalcularSalarioAnual()
    {
        return Salario * 12;
    }
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Salario: {Salario}");
    }}
// 2. Herencia:
// Crea una clase Gerente que herede de la clase Empleado.
// Agrega un nuevo atributo para el departamento que supervisa en la clase Gerente.
class Gerente : Empleado
{
    public string Departamento { get; set; }
    public Gerente(string nombre, double salario, string departamento) : base(nombre, salario)
    {
        Departamento = departamento;
    }
    // Sobreescribe el método para calcular el salario anual de los gerentes.
    public override double CalcularSalarioAnual()
    {
        return Salario * 12;
    }
    // Sobreescribe el método para mostrar información de los gerentes.
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Departamento: {Departamento}");
    }}
// 3. Interfaz y Polimorfismo:
// Define una interfaz MostrarInformacion con un método para mostrar información general.
interface MostrarInformacion
{
    void MostrarInformacion();
}
class Program
{
    static List<Empleado> empleados = new List<Empleado>();
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Ingresar datos de Empleado");
            Console.WriteLine("2. Ingresar datos de Gerente");
            Console.WriteLine("3. Mostrar información por tipo de empleado");
            Console.WriteLine("4. Salir");
            Console.WriteLine("Seleccione una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    IngresarEmpleado();
                    break;
                case "2":
                    IngresarGerente();
                    break;
                case "3":
                    MostrarInformacionPorTipoEmpleado();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }}
    static void IngresarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("Ingrese el nombre del empleado:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el salario del empleado:");
        double salario;
        while (!double.TryParse(Console.ReadLine(), out salario))
        {
            Console.WriteLine("Por favor, ingrese un salario válido:");
        }
        Empleado empleado = new Empleado(nombre, salario);
        empleados.Add(empleado);
        Console.WriteLine("\nInformación del Empleado:");
        empleado.MostrarInformacion();
    }
    static void IngresarGerente()
    {
        Console.Clear();
        Console.WriteLine("Ingrese el nombre del gerente:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el salario del gerente:");
        double salario;
        while (!double.TryParse(Console.ReadLine(), out salario))
        {
            Console.WriteLine("Por favor, ingrese un salario válido:");
        }
        Console.WriteLine("Ingrese el departamento del gerente:");
        string departamento = Console.ReadLine();
        Gerente gerente = new Gerente(nombre, salario, departamento);
        empleados.Add(gerente);
        Console.WriteLine("\nInformación del Gerente:");
        gerente.MostrarInformacion();
    }

    static void MostrarInformacionPorTipoEmpleado()
    {
        Console.Clear();
        Console.WriteLine("\nInformación de Empleados:");
        MostrarInformacionPorTipo(typeof(Empleado));
        Console.WriteLine("\nInformación de Gerentes:");
        MostrarInformacionPorTipo(typeof(Gerente));
    }
    static void MostrarInformacionPorTipo(Type tipo)
    {
        foreach (var empleado in empleados)
        {
            if (empleado.GetType() == tipo)
            {
                empleado.MostrarInformacion();
                Console.WriteLine($"Salario Anual: {empleado.CalcularSalarioAnual()}");
                Console.WriteLine(new string('-', 30));
            }}}}
