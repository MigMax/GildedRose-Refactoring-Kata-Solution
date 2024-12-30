using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private List<Item> _items;
    private GildedRose _sut;
    
    [Fact]
    public void Sulfuras1()
    {
        GivenItem(Item.CreateSulfuras(2, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Sulfuras, Hand of Ragnaros", 2, 2);
    }
    
    [Fact]
    public void Backstage1_Pass_In_All_Condition()
    {
        GivenItem(Item.CreateBackStagePasses(0, 45));

        UpdatingItem();

        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", -1, 0);
    }
    
    [Fact]
    public void Backstage4_Pass_In_1()
    {
        GivenItem(Item.CreateBackStagePasses(10, 49));

        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 9, 50);
    }
    
    [Fact]
    public void Backstage4_Pass_In_1_2()
    {
        GivenItem(Item.CreateBackStagePasses(10, 45));
        
        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 9, 47);
    }
    
    [Fact]
    public void Backstage2_Passe_In_1_2_3()
    {
        GivenItem(Item.CreateBackStagePasses(1, 45));
        
        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 0, 48);
    }
    
    [Fact]
    public void Backstage3_Pass_In_None_Condition()
    {
        GivenItem(Item.CreateBackStagePasses(1, 50));
        
        UpdatingItem();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 0, 50);
    }
    
    [Fact]
    public void AgedBrie_Pass_In_None_Condition()
    {
        GivenItem(Item.CreateAgedBrie(2, 50));
        
        UpdatingItem();
        
        ItemShouldMatch("Aged Brie", 1, 50);
    }
    
    [Fact]
    public void AgedBrie_Pass_In_1()
    {
        GivenItem(Item.CreateAgedBrie(2, 48));
        
        UpdatingItem();
        
        ItemShouldMatch("Aged Brie", 1, 49);
    }
    
    [Fact]
    public void AgedBrie_Pass_In_1_2()
    {
        GivenItem(Item.CreateAgedBrie(0, 48));
        
        UpdatingItem();
        
        ItemShouldMatch("Aged Brie", -1, 50);
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_None_Condition()
    {
        GivenItem(Item.Create("Conjured Mana Cake", 0, -1));

        UpdatingItem();
        
        ItemShouldMatch("Conjured Mana Cake", -1, -1);
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_All_Conditions()
    {
        GivenItem(Item.Create("Conjured Mana Cake", 0, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Conjured Mana Cake", -1, 0);
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_1()
    {
        GivenItem(Item.Create("Conjured Mana Cake", 1, 2));
        
        UpdatingItem();
        
        ItemShouldMatch("Conjured Mana Cake", 0, 1);
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