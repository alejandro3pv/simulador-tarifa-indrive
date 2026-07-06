using System;

class CierreDeTurno
{
    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("   InDrive - Cierre de Turno");
        Console.WriteLine("========================================\n");

        // Regla 4 — Estadísticas del cierre de turno

        Console.Write("¿Cuántos viajes realizaste hoy? ");
        int n = int.Parse(Console.ReadLine());

        double[] tarifas = new double[n];
        bool[] picoHora = new bool[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Viaje {i + 1} de {n} ---");

            double distancia;
            int hora;
            int tipoVehiculo;

            // Bucle de validación: se repite mientras los datos sean inválidos
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
                Console.Write("Seleccione opción        : ");
                tipoVehiculo = int.Parse(Console.ReadLine());

                if (EsValido(distancia, hora, tipoVehiculo))
                {
                    break;
                }

                Console.WriteLine("\n⚠ Datos inválidos. Verifica: distancia > 0, hora entre 0-23, vehículo entre 1-4.\n");
            }

            tarifas[i] = CalcularTarifa(distancia, hora, tipoVehiculo);
            picoHora[i] = EsHoraPico(hora);

            Console.WriteLine($"\nTarifa del viaje {i + 1}: S/ {tarifas[i]}");
        }

        // Estadísticas del cierre de turno
        double total = CalcularTotal(tarifas);
        double promedio = CalcularPromedio(tarifas);
        double maximo = EncontrarMaximo(tarifas);
        double minimo = EncontrarMinimo(tarifas);
        int cantidadPico = ContarHoraPico(picoHora);

        Console.WriteLine("\n========================================");
        Console.WriteLine("       RESUMEN DEL CIERRE DE TURNO");
        Console.WriteLine("========================================");
        Console.WriteLine($"Número de viajes        : {n}");
        Console.WriteLine($"Total ganado            : S/ {Math.Round(total, 2)}");
        Console.WriteLine($"Tarifa promedio          : S/ {Math.Round(promedio, 2)}");
        Console.WriteLine($"Viaje más rentable       : S/ {maximo}");
        Console.WriteLine($"Viaje más económico      : S/ {minimo}");
        Console.WriteLine($"Viajes en hora pico      : {cantidadPico}");
    }

    // Determina si una hora corresponde a horario pico
    static bool EsHoraPico(int hora)
    {
        return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20);
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

    // Valida que los datos de entrada de un viaje sean correctos
    static bool EsValido(double distancia, int hora, int tipoVehiculo)
    {
        if (distancia <= 0) return false;
        if (hora < 0 || hora > 23) return false;
        if (tipoVehiculo < 1 || tipoVehiculo > 4) return false;
        return true;
    }

    // Suma todas las tarifas del arreglo
    static double CalcularTotal(double[] tarifas)
    {
        double total = 0;
        for (int i = 0; i < tarifas.Length; i++)
        {
            total += tarifas[i];
        }
        return total;
    }

    // Calcula la tarifa promedio del día
    static double CalcularPromedio(double[] tarifas)
    {
        return CalcularTotal(tarifas) / tarifas.Length;
    }

    // Encuentra la tarifa más alta del día
    static double EncontrarMaximo(double[] tarifas)
    {
        double maximo = tarifas[0];
        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] > maximo)
            {
                maximo = tarifas[i];
            }
        }
        return maximo;
    }

    // Encuentra la tarifa más baja del día
    static double EncontrarMinimo(double[] tarifas)
    {
        double minimo = tarifas[0];
        for (int i = 1; i < tarifas.Length; i++)
        {
            if (tarifas[i] < minimo)
            {
                minimo = tarifas[i];
            }
        }
        return minimo;
    }

    // Cuenta cuántos viajes tuvieron recargo por hora pico
    static int ContarHoraPico(bool[] picoHora)
    {
        int contador = 0;
        for (int i = 0; i < picoHora.Length; i++)
        {
            if (picoHora[i])
            {
                contador++;
            }
        }
        return contador;
    }
}



