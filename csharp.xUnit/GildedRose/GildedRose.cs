using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var currentItem = Items[i];
            
            if (currentItem.NameIsNot("Aged Brie") && currentItem.NameIsNot("Backstage passes to a TAFKAL80ETC concert"))
            {
                if (currentItem.Quality > 0 && currentItem.NameIsNot("Sulfuras, Hand of Ragnaros"))
                {
                    currentItem.Quality -= 1;
                }
            }
            else
            {
                if (currentItem.Quality < 50)
                {
                    currentItem.Quality += 1;

                    if (currentItem.NameIs("Backstage passes to a TAFKAL80ETC concert"))
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

            if (currentItem.NameIsNot("Sulfuras, Hand of Ragnaros"))
            {
                currentItem.SellIn -= 1;
            }

            if (currentItem.SellIn < 0)
            {
                if (currentItem.NameIsNot("Aged Brie"))
                {
                    if (currentItem.NameIsNot("Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (currentItem.Quality > 0 && currentItem.NameIsNot("Sulfuras, Hand of Ragnaros"))
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
}