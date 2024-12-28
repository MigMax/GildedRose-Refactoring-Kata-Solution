using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            item.UpdateQuality();
        }
    }
}