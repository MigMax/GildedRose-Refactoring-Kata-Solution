using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var currentItem = Items[i];
            
            if (ItemNameIsNot(currentItem, "Aged Brie") && ItemNameIsNot(currentItem, "Backstage passes to a TAFKAL80ETC concert"))
            {
                if (currentItem.Quality > 0 && ItemNameIsNot(currentItem, "Sulfuras, Hand of Ragnaros"))
                {
                    currentItem.Quality -= 1;
                }
            }
            else
            {
                if (currentItem.Quality < 50)
                {
                    currentItem.Quality += 1;

                    if (ItemNameIs(currentItem, "Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (currentItem.SellIn < 11 && currentItem.Quality < 50)
                        {
                            currentItem.Quality += 1;
                        }

                        if (currentItem.SellIn < 6 && currentItem.Quality < 50)
                        {
                            currentItem.Quality += 1;
                        }
                    }
                }
            }

            if (ItemNameIsNot(currentItem, "Sulfuras, Hand of Ragnaros"))
            {
                currentItem.SellIn -= 1;
            }

            if (currentItem.SellIn < 0)
            {
                if (ItemNameIsNot(currentItem, "Aged Brie"))
                {
                    if (ItemNameIsNot(currentItem, "Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (currentItem.Quality > 0 && ItemNameIsNot(currentItem, "Sulfuras, Hand of Ragnaros"))
                        {
                            currentItem.Quality -= 1;
                        }
                    }
                    else
                    {
                        currentItem.Quality -= currentItem.Quality;
                    }
                }
                else
                {
                    if (currentItem.Quality < 50)
                    {
                        currentItem.Quality += 1;
                    }
                }
            }
        }
    }

    private static bool ItemNameIs(Item item, string name)
    {
        return item.Name == name;
    }
    
    private static bool ItemNameIsNot(Item item, string name)
    {
        return !ItemNameIs(item, name);
    }
}