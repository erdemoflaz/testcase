public class PrimeNumber
{
    public int id { get; set; }
    public int number { get; set; }

    // UserId property'si eklendi
    public int userId { get; set; }

    // User ile ilişkiyi temsil eden navigation property
    public User User { get; set; }
}