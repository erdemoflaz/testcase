public class User
{
    public int id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public bool? is_admin { get; set; }

    public List<PrimeNumber> PrimeNumbers { get; set; }
}