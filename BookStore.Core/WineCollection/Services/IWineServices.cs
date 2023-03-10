using BookStore.Core.WineCollection.Models;

namespace BookStore.Core.WineCollection.Services;

public interface IWineServices
{
    List<Wine> GetWines();
    Wine AddWine(Wine wine);
    Wine GetWine(string id);
    void DeleteWine(string id);
    Wine UpdateWine(Wine wine);

}

