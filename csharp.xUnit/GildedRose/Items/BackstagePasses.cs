﻿namespace GildedRoseKata;

public class BackstagePasses : Item
{
    public BackstagePasses(int sellIn, int quality) : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
    {
    }
    
    public override void UpdateQuality()
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

        DecreaseSellIn();

        if (SellIn < 0)
        {
            DecreaseQualityByCurrentQuality();
        }
    }

    private void DecreaseQualityByCurrentQuality()
    {
        Quality -= Quality;
    }
}