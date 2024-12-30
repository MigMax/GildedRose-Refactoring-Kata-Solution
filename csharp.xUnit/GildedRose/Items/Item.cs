namespace GildedRoseKata;

public class Item
{
    public string Name { get; init; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public Item(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }
    
    public virtual void UpdateQuality()
    {
        if (Quality > 0)
        {
            DecreaseQuality();
        }

        DecreaseSellIn();

        if (SellIn < 0 && Quality > 0)
        {
            DecreaseQuality();
        }
    }
    
    protected void IncreaseQuality()
    {
        Quality += 1;
    }
    
    protected void DecreaseSellIn()
    {
        SellIn -= 1;
    }

    private void DecreaseQuality()
    {
        Quality -= 1;
    }
    
    public static Item CreateAgedBrie(int sellIn, int quality)
    {
        return new AgedBrie(sellIn, quality);
    }
    
    public static Item CreateBackStagePasses(int sellIn, int quality)
    {
        return new BackstagePasses(sellIn, quality);
    }
    
    public static Item CreateSulfuras(int sellIn, int quality)
    {
        return new Sulfuras(sellIn, quality);
    }
    
    public static Item Create(string name, int sellIn, int quality)
    {
        return new Item(name, sellIn, quality);
    }
}