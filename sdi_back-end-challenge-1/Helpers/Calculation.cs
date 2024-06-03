
using static sdi_back_end_challenge_1.Models.Car;

namespace sdi_back_end_challenge_1.Helpers
{
    internal class Calculation
    {
        public static class RentalCostCalculator
        {
            public static (string size, int count, int totalCost) CalculateCost(IEnumerable<CarType> carTypes)
            {
                var (seats, _) = GetValidNumberOfSeats(); // Validate input

                List<(string, int)> possibleSolutions = new List<(string, int)>(); // Storage for possible solution/s

                foreach (var carType in carTypes)
                {
                    int numCars = seats / carType.capacity; // getting whole number
                    int remainingSeats = seats % carType.capacity; // getting remainder
                    int totalCost = numCars * carType.cost;


                    if (remainingSeats > 0) 
                    {   
 
                        foreach (var otherCarType in carTypes)
                        {
                            
                            if (otherCarType != carType && remainingSeats <= otherCarType.capacity)
                            {
                                possibleSolutions.Add(($"{carType.size} x {numCars} & {otherCarType.size} x 1", totalCost + otherCarType.cost));
                            }
                        }
                    }
                    else
                    {
                        
                        possibleSolutions.Add(($"{carType.size} x {numCars}", totalCost));
                    }
                }

                if (possibleSolutions.Count > 0)
                {
                    
                    var bestSolution = possibleSolutions.MinBy(s => s.Item2);
                    return (bestSolution.Item1, bestSolution.Item2, bestSolution.Item2);
                }
                else
                {
                    return (null, 0, 0);
                }
            }


            // Input Validation
            private static (int seats, bool isValid) GetValidNumberOfSeats()
            {
                int seats;
                bool isValidInput = false;
                do
                {
                    Console.Write("Please input number (seat): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out seats) && seats > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer greater than 0. \n");
                    }
                } while (!isValidInput);
                return (seats, true);
            }
        }
    }
}
