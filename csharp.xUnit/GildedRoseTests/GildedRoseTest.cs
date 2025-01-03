﻿using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private List<Item> _items;
    private GildedRose _sut;
    
    [Fact]
    public void Sulfuras_Should_NotUpdateState()
    {
        GivenItem(Item.Create(ItemType.Sulfuras, 2, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Sulfuras, Hand of Ragnaros", 2, 2);
    }
    
    [Fact]
    public void Backstage_Should_DecreaseSellInOnce_And_SoldOutQuality()
    {
        GivenItem(Item.Create(ItemType.BackStagePasses, 0, 45));

        UpdatingItem();

        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", -1, 0);
    }
    
    [Fact]
    public void Backstage_Pass_Should_DecreaseSellInOnce_And_IncreaseQualityOnce()
    {
        GivenItem(Item.Create(ItemType.BackStagePasses, 10, 49));

        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 9, 50);
    }
    
    [Fact]
    public void Backstage_Pass_Should_DecreaseSellInOnce_And_IncreaseQualityTwice()
    {
        GivenItem(Item.Create(ItemType.BackStagePasses, 10, 45));
        
        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 9, 47);
    }
    
    [Fact]
    public void Backstage_Pass_Should_DecreaseSellInOnce_And_IncreaseQualityThreeTimes()
    {
        GivenItem(Item.Create(ItemType.BackStagePasses, 1, 45));
        
        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 0, 48);
    }
    
    [Fact]
    public void Backstage_Pass_Should_OnlyDecreaseSellInOnce()
    {
        GivenItem(Item.Create(ItemType.BackStagePasses, 1, 50));
        
        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 0, 50);
    }
    
    [Fact]
    public void AgedBrie_Should_OnlyDecreaseSellInOnce()
    {
        GivenItem(Item.Create(ItemType.AgedBrie, 2, 50));
        
        UpdatingItem();
        
        ItemShouldMatch("Aged Brie", 1, 50);
    }
    
    [Fact]
    public void AgedBrie_Should_DecreaseSellInOnce_And_IncreaseQualityOnce()
    {
        GivenItem(Item.Create(ItemType.AgedBrie, 2, 48));
        
        UpdatingItem();
        
        ItemShouldMatch("Aged Brie", 1, 49);
    }
    
    [Fact]
    public void AgedBrie_Should_DecreaseSellInOnce_And_IncreaseQualityTwice()
    {
        GivenItem(Item.Create(ItemType.AgedBrie, 0, 48));
        
        UpdatingItem();
        
        ItemShouldMatch("Aged Brie", -1, 50);
    }
    
    [Fact]
    public void ManaCake_Should_OnlyDecreaseSellInOnce()
    {
        GivenItem(Item.Create(ItemType.ManaCake, 0, -1));

        UpdatingItem();
        
        ItemShouldMatch("Conjured Mana Cake", -1, -1);
    }
    
    [Fact]
    public void ManaCake_Should_DecreaseSellInOnce_And_DecreaseQualityTwice()
    {
        GivenItem(Item.Create(ItemType.ManaCake, 0, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Conjured Mana Cake", -1, 0);
    }
    
    [Fact]
    public void ManaCake_Should_DecreaseSellInOnce_And_DecreaseQualityOnce()
    {
        GivenItem(Item.Create(ItemType.ManaCake, 1, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Conjured Mana Cake", 0, 1);
    }
    
    
    [Fact]
    public void Elixir_Should_OnlyDecreaseSellInOnce()
    {
        GivenItem(Item.Create(ItemType.Elixir, 0, -1));

        UpdatingItem();
        
        ItemShouldMatch("Elixir of the Mongoose", -1, -1);
    }
    
    [Fact]
    public void Elixir_Should_DecreaseSellInOnce_And_DecreaseQualityTwice()
    {
        GivenItem(Item.Create(ItemType.Elixir, 0, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Elixir of the Mongoose", -1, 0);
    }
    
    [Fact]
    public void Elixir_Should_DecreaseSellInOnce_And_DecreaseQualityOnce()
    {
        GivenItem(Item.Create(ItemType.Elixir, 1, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Elixir of the Mongoose", 0, 1);
    }
    
    [Fact]
    public void DexterityVest_Should_OnlyDecreaseSellInOnce()
    {
        GivenItem(Item.Create(ItemType.DexterityVest, 0, -1));

        UpdatingItem();
        
        ItemShouldMatch("+5 Dexterity Vest", -1, -1);
    }
    
    [Fact]
    public void DexterityVest_Should_DecreaseSellInOnce_And_DecreaseQualityTwice()
    {
        GivenItem(Item.Create(ItemType.DexterityVest, 0, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("+5 Dexterity Vest", -1, 0);
    }
    
    [Fact]
    public void DexterityVest_Should_DecreaseSellInOnce_And_DecreaseQualityOnce()
    {
        GivenItem(Item.Create(ItemType.DexterityVest, 1, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("+5 Dexterity Vest", 0, 1);
    }
    
    private void GivenItem(Item item)
    {
        _items = [item];
        _sut = new GildedRose(_items);
    }
    
    private void UpdatingItem()
    {
        _sut.UpdateQuality();
    }
    
    private void ItemShouldMatch(string name, int sellIn, int quality)
    {
        _items[0].Name.Should().Be(name);
        _items[0].SellIn.Should().Be(sellIn);
        _items[0].Quality.Should().Be(quality);
    }
}