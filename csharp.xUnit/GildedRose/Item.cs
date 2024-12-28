namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public void UpdateQuality()
    {
        if (NameIsNot("Aged Brie") && NameIsNot("Backstage passes to a TAFKAL80ETC concert"))
        {
            if (Quality > 0 && NameIsNot("Sulfuras, Hand of Ragnaros"))
            {
                DecreaseQuality();
            }
        }
        else
        {
            if (Quality < 50)
            {
                IncreaseQuality();

                if (NameIs("Backstage passes to a TAFKAL80ETC concert"))
                {
                    if (SellIn < 11 && Quality < 50)
                    {
                        IncreaseQuality();
                    }

                    if (SellIn < 6 && Quality < 50)
                    {
                        IncreaseQuality();
                    }
                }
            }
        }

        if (NameIsNot("Sulfuras, Hand of Ragnaros"))
        {
            SellIn -= 1;
        }

        if (SellIn < 0)
        {
            if (NameIsNot("Aged Brie"))
            {
                if (NameIsNot("Backstage passes to a TAFKAL80ETC concert"))
                {
                    if (Quality > 0 && NameIsNot("Sulfuras, Hand of Ragnaros"))
                    {
                        DecreaseQuality();
                    }
                }
                else
                {
                    DecreaseQualityByCurrentQuality();
                }
            }
            else
            {
                if (Quality < 50)
                {
                    IncreaseQuality();
                }
            }
        }
    }

    private bool NameIs(string name)
    {
        return Name == name;
    }

    private bool NameIsNot(string name)
    {
        return !NameIs(name);
    }

    private void IncreaseQuality()
    {
        Quality += 1;
    }

    private void DecreaseQuality()
    {
        Quality -= 1;
    }

    private void DecreaseQualityByCurrentQuality()
    {
        Quality -= Quality;
    }
}