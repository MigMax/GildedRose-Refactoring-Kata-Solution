namespace GildedRoseKata;

public abstract class Item
{
    public string Name { get; }
    public int SellIn { get; private set; }
    public int Quality { get; protected set; }

    protected Item(string name, int sellIn, int quality)
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
    
    public static Item CreateElixir(int sellIn, int quality)
    {
        return new Elixir(sellIn, quality);
    }
    
    public static Item CreateDexterityVest(int sellIn, int quality)
    {
        return new DexterityVest(sellIn, quality);
    }
    
    public static Item CreateManaCake(int sellIn, int quality)
    {
        return new ManaCake(sellIn, quality);
    }
}