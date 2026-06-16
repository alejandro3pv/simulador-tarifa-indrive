# simulador-tarifa-indrive

Simulador de tarifa digital basado en el modelo de InDrive Perú.
Desarrollado en C# para el curso de Programación I - Ingeniería de Sistemas - UPN.

## Variables de entrada
- Nombre del pasajero
- Distancia del viaje (km)
- Hora de salida (0-23)
- Tipo de vehículo (1-4)

## Reglas 
1. Tarifa base según tipo de vehículo
2. Recargo del 30% en hora pico (7-9h y 17-20h)
3. Descuento del 5% si distancia mayor a 15 km
4. Tarifa mínima de S/ 5.00
5. Redondeo a 2 decimales

________________________________________________________

## Casos de prueba
| # | Nombre | Distancia | Hora | Vehículo | Resultado esperado |
|---|--------|-----------|------|----------|--------------------|
| 1 | Ana García | 8 km | 14 | Económico | S/ 14.00 |
| 2 | Carlos López | 5 km | 8 | Confort | S/ 16.90 |
| 3 | María Torres | 20 km | 12 | Premium | S/ 61.75 |
| 4 | Luis Mendoza | 1 km | 12 | Moto | S/ 5.00 |
