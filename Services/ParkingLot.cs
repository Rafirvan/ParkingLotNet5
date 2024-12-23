using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Parking.Models;

namespace Parking.Services
{
    public class ParkingLot
    {
        private readonly List<ParkingSlot> _slots;

        public ParkingLot(int totalSlots)
        {
            _slots = Enumerable.Range(1, totalSlots)
                .Select(i => new ParkingSlot { SlotNumber = i })
                .ToList();
        }

        public string ParkVehicle(string registrationNumber, string color, string type)
        {
            if (_slots.All(s => s.IsOccupied))
                return "Sorry, parking lot is full";

            var firstEmptySlot = _slots.FirstOrDefault(s => !s.IsOccupied);
            if (firstEmptySlot != null)
            {
                firstEmptySlot.Vehicle = new Vehicle
                {
                    RegistrationNumber = registrationNumber,
                    Color = color,
                    Type = type
                };
                return $"Allocated slot number: {firstEmptySlot.SlotNumber}";
            }

            return "Error occurred while parking";
        }

        public string Leave(int slotNumber)
        {
            var slot = _slots.FirstOrDefault(s => s.SlotNumber == slotNumber);
            if (slot != null && slot.IsOccupied)
            {
                slot.Vehicle = null;
                return $"Slot number {slotNumber} is free";
            }
            return "Invalid slot number";
        }

        public void Status()
        {
            Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");
            foreach (var slot in _slots.Where(s => s.IsOccupied))
            {
                Console.WriteLine($"{slot.SlotNumber}\t{slot.Vehicle.RegistrationNumber}\t{slot.Vehicle.Type}\t{slot.Vehicle.Color}");
            }
        }

        public int GetVehicleCountByType(string type)
        {
            return _slots.Count(s => s.IsOccupied && s.Vehicle.Type == type);
        }

        public string GetRegistrationNumbersForOddPlate()
        {
            var oddPlates = _slots.Where(s => s.IsOccupied && IsOddPlate(s.Vehicle.RegistrationNumber))
                                .Select(s => s.Vehicle.RegistrationNumber);
            return string.Join(", ", oddPlates);
        }

        public string GetRegistrationNumbersForEvenPlate()
        {
            var evenPlates = _slots.Where(s => s.IsOccupied && !IsOddPlate(s.Vehicle.RegistrationNumber))
                                .Select(s => s.Vehicle.RegistrationNumber);
            return string.Join(", ", evenPlates);
        }

        private bool IsOddPlate(string registrationNumber)
        {
            var numbers = Regex.Match(registrationNumber, @"\d+").Value;
            return numbers.Length > 0 && int.Parse(numbers[^1].ToString()) % 2 != 0;
        }

        public string GetRegistrationNumbersByColor(string color)
        {
            var vehicles = _slots.Where(s => s.IsOccupied && s.Vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                                .Select(s => s.Vehicle.RegistrationNumber);
            return string.Join(", ", vehicles);
        }

        public string GetSlotNumbersByColor(string color)
        {
            var slots = _slots.Where(s => s.IsOccupied && s.Vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                            .Select(s => s.SlotNumber.ToString());
            return string.Join(", ", slots);
        }

        public string GetSlotNumberByRegistrationNumber(string registrationNumber)
        {
            var slot = _slots.FirstOrDefault(s => s.IsOccupied && 
                s.Vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
            return slot != null ? slot.SlotNumber.ToString() : "Not found";
        }
    }
}
