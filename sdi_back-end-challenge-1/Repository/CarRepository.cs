
using Newtonsoft.Json;
using static sdi_back_end_challenge_1.Models.Car;


public class CarRepository
{
    private readonly string _filePath;

    public CarRepository(string filePath)
    {
        _filePath = filePath;
    }

    public List<CarType> GetCarTypes()
    {
        // Getting Data
        string json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<CarType>>(json);
    }
}
