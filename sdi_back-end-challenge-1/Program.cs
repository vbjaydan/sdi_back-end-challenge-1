using Microsoft.Extensions.Configuration;
using sdi_back_end_challenge_1.Helpers;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string carTypeListPath = configuration["file_path"];
            var carTypeRepository = new CarRepository(carTypeListPath);
            var carTypes = carTypeRepository.GetCarTypes();

            while (true)
            {
                var (size, count, totalCost) = Calculation.RentalCostCalculator.CalculateCost(carTypes);


                // Display output
                Console.WriteLine($"\n {size} \n\n Total: PHP {totalCost.ToString("N2")}\n");

                // Ask if they want to continue
                Console.Write("Do you want to calculate another cost? (Enter 'Y' to continue): ");


                string continueInput = Console.ReadLine();
                if (continueInput.ToLower() != "y")
                {
                    break; // Exit loop if does not want to continue
                }
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong: {ex.Message}");
        }
    }
}
