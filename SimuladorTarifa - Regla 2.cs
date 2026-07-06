using System;

class SimuladorTarifa
{
    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("   InDrive - Simulador de Tarifa");
        Console.WriteLine("========================================\n");

        Console.Write("Nombre del pasajero    : ");
        string nombre = Console.ReadLine();

        double distancia;
        int hora;
        int tipoVehiculo;

        // Regla 2 — Registro y validación de cada viaje

        while (true)
        {
            Console.Write("Distancia del viaje (km): ");
            distancia = double.Parse(Console.ReadLine());

            Console.Write("Hora de salida (0 - 23) : ");
            hora = int.Parse(Console.ReadLine());

            Console.WriteLine("\nTipo de vehículo:");
            Console.WriteLine("  1. Económico");
            Console.WriteLine("  2. Confort");
            Console.WriteLine("  3. Premium");
            Console.WriteLine("  4. Moto");
            Console.Write("Seleccione opción       : ");
            tipoVehiculo = int.Parse(Console.ReadLine());

            if (EsValido(distancia, hora, tipoVehiculo))
            {
                break;
            }

            Console.WriteLine("\n⚠ Datos inválidos. Verifica: distancia > 0, hora entre 0-23, vehículo entre 1-4.\n");
        }

        double tarifaFinal = CalcularTarifa(distancia, hora, tipoVehiculo);

        Console.WriteLine("\nTARIFA FINAL: S/ " + tarifaFinal);
    }

    // Determina si una hora corresponde a horario pico
    static bool EsHoraPico(int hora)
    {
        return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20);
    }

    // Valida que los datos de entrada de un viaje sean correctos
    static bool EsValido(double distancia, int hora, int tipoVehiculo)
    {
        if (distancia <= 0) return false;
        if (hora < 0 || hora > 23) return false;
        if (tipoVehiculo < 1 || tipoVehiculo > 4) return false;
        return true;
    }

    // Calcula la tarifa final de un viaje según distancia, hora y tipo de vehículo
    static double CalcularTarifa(double distancia, int hora, int tipoVehiculo)
    {
        double tarifaBase = 0;
        double costoKm = 0;

        switch (tipoVehiculo)
        {
            case 1:
                tarifaBase = 2.00;
                costoKm = 1.50;
                break;
            case 2:
                tarifaBase = 3.00;
                costoKm = 2.00;
                break;
            case 3:
                tarifaBase = 5.00;
                costoKm = 3.00;
                break;
            case 4:
                tarifaBase = 1.50;
                costoKm = 1.00;
                break;
        }

        double subtotal = tarifaBase + (costoKm * distancia);

        if (EsHoraPico(hora))
        {
            subtotal = subtotal * 1.30;
        }

        double descuento = 0;
        if (distancia > 15)
        {
            descuento = subtotal * 0.05;
            subtotal = subtotal - descuento;
        }

        double tarifaFinal = Math.Max(subtotal, 5.00);
        tarifaFinal = Math.Round(tarifaFinal, 2);

        return tarifaFinal;
    }
}

