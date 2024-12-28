namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    private const string AgedBrie = "Aged Brie";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    
    public void UpdateQuality()
    {
        if (NameIs(Sulfuras))
        {
            return;
        }
        
        if (NameIs(AgedBrie))
        {
            UpdateQualityAsAgedBrie();
        }
        else if (NameIs(BackstagePasses))
        {
            UpdateQualityAsBackstagePasses();
        }
        else
        {
            UpdateQualityAsOtherItem();
        }
    }
    
    private void UpdateQualityAsOtherItem()
    {
        if (Quality > 0)
        {
            DecreaseQuality();
        }

        SellIn -= 1;

        if (SellIn >= 0)
        {
            return;
        }
        
        if (Quality > 0)
        {
            DecreaseQuality();
        }
    }
    
    private void UpdateQualityAsBackstagePasses()
    {
        if (Quality < 50)
        {
            IncreaseQuality();

            if (SellIn < 11 && Quality < 50)
            {
                IncreaseQuality();
            }

            if (SellIn < 6 && Quality < 50)
            {
                IncreaseQuality();
            }
        }

        SellIn -= 1;

        if (SellIn < 0)
        {
            DecreaseQualityByCurrentQuality();
        }
    }
    
    private void UpdateQualityAsAgedBrie()
    {
        if (Quality < 50)
        {
            IncreaseQuality();
        }
        
        SellIn -= 1;
        
        if (SellIn < 0 && Quality < 50)
        {
            IncreaseQuality();
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