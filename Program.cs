using System;
using System.Management;

namespace HWID_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Vizion HWID-Checker";

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" _          _        _           _                  _          _            _          ");
                Console.WriteLine("/\\ \\    _ / /\\      /\\ \\       /\\ \\                /\\ \\       /\\ \\         /\\ \\     _  ");
                Console.WriteLine("\\ \\ \\  /_/ / /      \\ \\ \\     /  \\ \\               \\ \\ \\     /  \\ \\       /  \\ \\   /\\_\\");
                Console.WriteLine("\\ \\ \\  /_/ / /      \\ \\ \\     /  \\ \\               \\ \\ \\     /  \\ \\       /  \\ \\   /\\_\\");
                Console.WriteLine(" \\ \\ \\ \\___\\/       /\\ \\_\\ __/ /\\ \\ \\              /\\ \\_\\   / /\\ \\ \\     / /\\ \\ \\_/ / /");
                Console.WriteLine(" / / /  \\ \\ \\      / /\\/_//___/ /\\ \\ \\            / /\\/_/  / / /\\ \\ \\   / / /\\ \\___/ / ");
                Console.WriteLine(" \\ \\ \\   \\_\\ \\    / / /   \\___\\/ / / /           / / /    / / /  \\ \\_\\ / / /  \\/____/  ");
                Console.WriteLine("  \\ \\ \\  / / /   / / /          / / /           / / /    / / /   / / // / /    / / /   ");
                Console.WriteLine("   \\ \\ \\/ / /   / / /          / / /    _      / / /    / / /   / / // / /    / / /    ");
                Console.WriteLine("    \\ \\ \\/ /___/ / /__         \\ \\ \\__/\\_\\ ___/ / /__  / / /___/ / // / /    / / /     ");
                Console.WriteLine("     \\ \\  //\\__\\/_/___\\         \\ \\___\\/ //\\__\\/_/___\\/ / /____\\/ // / /    / / /      ");
                Console.WriteLine("      \\_\\/ \\/_________/          \\/___/_/ \\/_________/\\/_________/ \\/_/     \\/_/       ");
                Console.WriteLine("                                                                                       ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                      Free and Open Source HWID-Checker software!\n\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                GetWmiInformation("Win32_Processor", "Name,DeviceID,NumberOfCores,NumberOfLogicalProcessors");
                GetWmiInformation("Win32_DiskDrive", "SerialNumber");
                GetWmiInformation("Win32_BIOS", "SerialNumber");
                GetWmiInformation("Win32_DiskDrive", "Model");
                GetWmiInformation("Win32_DiskDrive", "Size");
                GetWmiInformation("Win32_DiskDrive", "MediaType");
                GetWmiInformation("Win32_BIOS", "Version");
                GetWmiInformation("Win32_ComputerSystemProduct", "Name");
                GetWmiInformation("Win32_OperatingSystem", "Version");
                GetWmiInformation("Win32_ComputerSystemProduct", "UUID");
                Console.ResetColor();

                foreach (var nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"MAC Address ({nic.Description}): {nic.GetPhysicalAddress()}");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nAppuyez sur une touche pour actualiser.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void GetWmiInformation(string className, string properties)
        {
            var searcher = new ManagementObjectSearcher($"SELECT {properties} FROM {className}");
            foreach (ManagementObject wmiObject in searcher.Get())
            {
                Console.WriteLine($"{className}:");
                foreach (var property in properties.Split(','))
                {
                    Console.WriteLine($"{property.Trim()}: {wmiObject[property]}");
                }
                Console.WriteLine();
            }
        }
    }
}