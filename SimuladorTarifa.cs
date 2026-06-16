public class SimuladorTarifa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("===============================================");
        Console.WriteLine("         InDrive - Simulador de Tarifa");
        Console.WriteLine("===============================================");
        // Entrada de Datos
        // Delcracion de variables
        string nombre, nombreVehiculo;
        double distancia, tarifaBase, costoKm, subtotal , tarifaFinal, descuento= 0.00;
        int hora, tipoVehiculo;
        bool esHoraPico = false;

        Console.WriteLine("Nombre del Pasajero: ");
        nombre = Console.ReadLine();
        
        Console.WriteLine("Ingrese distancia del viaje (KM): ");
        distancia = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Hora de Salida (0 hrs - 23 hrs): ");
        hora = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\nTipo de Vehículo: ");
        Console.WriteLine(" 1. Economico");
        Console.WriteLine(" 2. Confort");
        Console.WriteLine(" 3. Premium");
        Console.WriteLine(" 4. Moto");
        Console.WriteLine("Ingrese la opcion: ");
        tipoVehiculo = int.Parse(Console.ReadLine());
        // Proceso
        switch (tipoVehiculo){
            case 1: // Economico
                nombreVehiculo = "Económico";
                tarifaBase = 2.0;
                costoKm = 1.5;
                break;
            case 2: // Confort
                nombreVehiculo = "Confort";
                tarifaBase = 3.0;
                costoKm = 2.0;
                break;
            case 3: // Premium
                nombreVehiculo = "Premium";
                tarifaBase = 5.0;
                costoKm = 3.0;
                break;
            case 4: // Moto
                nombreVehiculo = "Moto";
                tarifaBase = 1.5;
                costoKm = 1.0;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Fin del Programa");
                return;
        }
        // Cálculo del Subtotal Base
        subtotal = tarifaBase + (costoKm * distancia);
        // Condicional de recargo por hora pico
        if((hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20))
        {
            esHoraPico = true;
            subtotal = subtotal * 1.30; // incremento del 30%
        }
        // Descuento por distancia larga (5%) 
        if(distancia > 15)
        {
            descuento = subtotal * 0.05;
            subtotal = subtotal - descuento;
        }
        // Tarifa minima y redondeo
        tarifaFinal = Math.Max(subtotal, 5.00);
        tarifaFinal = Math.Round(tarifaFinal, 2);
        // Salida - Resumen del Viaje
        Console.WriteLine("\n===============================================");
        Console.WriteLine("         RESUMEN DEL VIAJE");
        Console.WriteLine("===============================================");
        Console.WriteLine("Pasajero: " + nombre);
        Console.WriteLine("Vehículo: " + nombreVehiculo);
        Console.WriteLine("Distancia: " + distancia + " km");
        Console.WriteLine("Hora Pico: " + (esHoraPico?"Sí (+30%)":"No")); // inline if -> condicional?es verdad: es falso; 
        if(descuento > 0){
            Console.WriteLine("Descuento: S/ " + Math.Round(descuento, 2));
        }else{
            Console.WriteLine("Descuento: No Aplica");
        }
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("TARIFA FINAL: S/ " + tarifaFinal);
        Console.WriteLine("===============================================");
    }
}