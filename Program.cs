using System;
using System.Collections.Generic;
using System.Linq;
using Parking.Services;

namespace Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = null;

            while (true)
            {
                string command = Console.ReadLine();
                string[] inputs = command.Split(' ');

                try
                {
                    switch (inputs[0].ToLower())
                    {
                        case "create_parking_lot":
                            int totalSlots = int.Parse(inputs[1]);
                            parkingLot = new ParkingLot(totalSlots);
                            WriteInColor($"Created a parking lot with {totalSlots} slots", ConsoleColor.Green);
                            break;

                        case "park":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            WriteInColor(parkingLot.ParkVehicle(inputs[1], inputs[2], inputs[3]), ConsoleColor.Cyan);
                            break;

                        case "leave":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            WriteInColor(parkingLot.Leave(int.Parse(inputs[1])), ConsoleColor.Yellow);
                            break;

                        case "status":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            Console.ForegroundColor = ConsoleColor.White;
                            parkingLot.Status();
                            Console.ResetColor();
                            break;

                        case "type_of_vehicles":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            int vehicleCount = parkingLot.GetVehicleCountByType(inputs[1]);
                            WriteInColor(vehicleCount.ToString(), ConsoleColor.Blue);
                            break;


                        case "registration_numbers_for_vehicles_with_odd_plate":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            WriteInColor(parkingLot.GetRegistrationNumbersForOddPlate(), ConsoleColor.Green);
                            break;

                        case "registration_numbers_for_vehicles_with_even_plate":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            WriteInColor(parkingLot.GetRegistrationNumbersForEvenPlate(), ConsoleColor.Magenta);
                            break;

                        case "registration_numbers_for_vehicles_with_colour":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            WriteInColor(parkingLot.GetRegistrationNumbersByColor(inputs[1]), ConsoleColor.Cyan);
                            break;

                        case "slot_numbers_for_vehicles_with_colour":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            WriteInColor(parkingLot.GetSlotNumbersByColor(inputs[1]), ConsoleColor.Yellow);
                            break;

                        case "slot_number_for_registration_number":
                            if (parkingLot == null) throw new Exception("Parking lot not initialized");
                            WriteInColor(parkingLot.GetSlotNumberByRegistrationNumber(inputs[1]), ConsoleColor.Red);
                            break;

                        case "exit":
                            return;

                        default:
                            WriteInColor("Invalid command", ConsoleColor.Red);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    WriteInColor($"Error: {ex.Message}", ConsoleColor.Red);
                }
            }
        }

        private static void WriteInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
