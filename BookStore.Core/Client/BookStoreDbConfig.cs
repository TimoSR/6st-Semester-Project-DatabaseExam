namespace BookStore.Core;

public class BookStoreDbConfig
{
    public string Database_Name { get; set; }
    public string Books_Collection_Name { get; set; }
    public string Wines_Collection_Name { get; set; }
    public string Wine_Producer_Collection_Name { get; set; }
    public string Connection_String { get; set; }
}