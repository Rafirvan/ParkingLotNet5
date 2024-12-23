namespace Parking.Models
{
    public class ParkingSlot
    {
        public int SlotNumber { get;set;}
        public Vehicle Vehicle { get;set; }
        public bool IsOccupied => Vehicle != null;
    }
}
