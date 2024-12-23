# Parking System

A console-based parking management system implemented in .NET 5. This system manages parking slots for cars and motorcycles, with features for check-in, check-out, and various reporting capabilities.

## Features

- Parking lot initialization with configurable number of slots
- Vehicle check-in with automatic slot allocation
- Vehicle check-out with slot release
- Status reporting for occupied slots
- Vehicle counting by type (Car/Motorcycle)
- Registration number filtering (odd/even plates)
- Color-based vehicle queries
- Slot number lookup by registration number

## Prerequisites

- .NET 5 SDK
- Visual Studio / code

## Installation

1. Clone the repository or download the source code
2. Open the solution in Visual Studio or your preferred IDE
3. Build the solution
4. Run the application

## Usage

The system accepts the following commands:

### Creating Parking Lot
```
create_parking_lot [number_of_slots]
Example: create_parking_lot 6
```

### Parking a Vehicle
```
park [registration_number] [color] [vehicle_type]
Example: park B-1234-XYZ Putih Mobil
```

### Removing a Vehicle
```
leave [slot_number]
Example: leave 4
```

### Viewing Current Status
```
status
```

### Vehicle Type Count
```
type_of_vehicles [vehicle_type]
Example: type_of_vehicles Mobil
```

### Registration Numbers by Plate Type
```
registration_numbers_for_vehicles_with_ood_plate
registration_numbers_for_vehicles_with_event_plate
```

### Color-based Queries
```
registration_numbers_for_vehicles_with_colour [color]
Example: registration_numbers_for_vehicles_with_colour Putih

slot_numbers_for_vehicles_with_colour [color]
Example: slot_numbers_for_vehicles_with_colour Putih
```

### Registration Number Lookup
```
slot_number_for_registration_number [registration_number]
Example: slot_number_for_registration_number B-3141-ZZZ
```

### Exit Application
```
exit
```



## Error Handling

The system handles various error scenarios:
- Full parking lot
- Invalid slot numbers
- Uninitialized parking lot
- Invalid commands
- Invalid vehicle types

## Project Structure

- `Models`: Directory containing the object models
- `Services`: Directory containing the services or business logics
- `Program.cs`: Contains the main program loop and command processing
