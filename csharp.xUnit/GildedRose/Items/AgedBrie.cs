using GildedRoseKata.Constantes;

namespace GildedRoseKata;

public class AgedBrie(int sellIn, int quality) : Item(ItemNames.AgedBrie, sellIn, quality)
{
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