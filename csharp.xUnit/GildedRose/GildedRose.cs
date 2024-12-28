using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var currentItem = Items[i];
            
            if (currentItem.Name != "Aged Brie" && currentItem.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (currentItem.Quality > 0)
                {
                    if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        currentItem.Quality = currentItem.Quality - 1;
                    }
                }
            }
            else
            {
                if (currentItem.Quality < 50)
                {
                    currentItem.Quality = currentItem.Quality + 1;

                    if (currentItem.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (currentItem.SellIn < 11)
                        {
                            if (currentItem.Quality < 50)
                            {
                                currentItem.Quality = currentItem.Quality + 1;
                            }
                        }

                        if (currentItem.SellIn < 6)
                        {
                            if (currentItem.Quality < 50)
                            {
                                currentItem.Quality = currentItem.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
            {
                currentItem.SellIn = currentItem.SellIn - 1;
            }

            if (currentItem.SellIn < 0)
            {
                if (currentItem.Name != "Aged Brie")
                {
                    if (currentItem.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (currentItem.Quality > 0)
                        {
                            if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                currentItem.Quality = currentItem.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        currentItem.Quality = currentItem.Quality - currentItem.Quality;
                    }
                }
                else
                {
                    if (currentItem.Quality < 50)
                    {
                        currentItem.Quality = currentItem.Quality + 1;
                    }
                }
            }
        }
    }
}