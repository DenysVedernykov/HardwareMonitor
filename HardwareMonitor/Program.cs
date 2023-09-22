using LibreHardwareMonitor.Hardware;

var _computer = new Computer()
{
    IsCpuEnabled = true,
    IsMemoryEnabled = true,
    IsStorageEnabled = true,
};

_computer.Open();

foreach (var hardware in _computer.Hardware)
{
    hardware.Update();

    foreach (var sensor in hardware.Sensors)
    {
        if (sensor.SensorType == SensorType.Load)
        {
            if (sensor.Name.Contains("CPU Total"))
            {
                Console.WriteLine($"{sensor.Name} {sensor.Value.GetValueOrDefault()}");
            }
            else if (sensor.Name.Contains("Virtual Memory"))
            {
                Console.WriteLine($"{sensor.Name} {sensor.Value.GetValueOrDefault()}");
            }
            else if (sensor.Name.Contains("Memory"))
            {
                Console.WriteLine($"{sensor.Name} {sensor.Value.GetValueOrDefault()}");
            }
        }
    }
}

_computer.Close();

Console.ReadKey();