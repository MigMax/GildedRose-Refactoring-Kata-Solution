namespace GildedRoseKata;

public class AgedBrie : Item
{
    public AgedBrie(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
    {
    }
    
    public override void UpdateQuality()
    {
        if (Quality < 50)
        {
            IncreaseQuality();
        }

        DecreaseSellIn();
        
        if (SellIn < 0 && Quality < 50)
        {
            IncreaseQuality();
        }
    }
}