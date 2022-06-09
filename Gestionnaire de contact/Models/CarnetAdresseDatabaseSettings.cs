namespace CarnetAdresseApi.Models;

public class CarnetAdresseDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PeopleCollectionName { get; set; } = null!;
}
