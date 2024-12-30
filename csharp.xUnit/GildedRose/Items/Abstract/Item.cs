using System;

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

    public static Item Create(ItemType itemType, int sellIn, int quality)
    {
        return itemType switch
        {
            ItemType.AgedBrie => new AgedBrie(sellIn, quality),
            ItemType.BackStagePasses => new BackstagePasses(sellIn, quality),
            ItemType.Sulfuras => new Sulfuras(sellIn, quality),
            ItemType.Elixir => new Elixir(sellIn, quality),
            ItemType.DexterityVest => new DexterityVest(sellIn, quality),
            ItemType.ManaCake => new ManaCake(sellIn, quality),
            _ => throw new ArgumentException("Invalid ItemType", nameof(itemType))
        };
    }
}