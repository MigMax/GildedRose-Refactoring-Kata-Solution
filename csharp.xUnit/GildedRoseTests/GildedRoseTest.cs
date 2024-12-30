using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void Sulfuras1()
    {
        IList<Item> items = new List<Item> {
            Item.CreateSulfuras(2, 2)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        ItemShouldMatch("Sulfuras, Hand of Ragnaros", 2, 2, items[0]);
    }
    
    [Fact]
    public void Backstage1_Pass_In_All_Condition()
    {
        IList<Item> items = new List<Item> { 
            Item.CreateBackStagePasses(0, 45)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", -1, 0, items[0]);
    }
    
    [Fact]
    public void Backstage4_Pass_In_1()
    {
        IList<Item> items = new List<Item> { 
            Item.CreateBackStagePasses(10, 49)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 9, 50, items[0]);
    }
    
    [Fact]
    public void Backstage4_Pass_In_1_2()
    {
        IList<Item> items = new List<Item> {
            Item.CreateBackStagePasses(10, 45)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 9, 47, items[0]);
    }
    
    [Fact]
    public void Backstage2_Passe_In_1_2_3()
    {
        IList<Item> items = new List<Item> {
            Item.CreateBackStagePasses(1, 45)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 0, 48, items[0]);
    }
    
    [Fact]
    public void Backstage3_Pass_In_None_Condition()
    {
        IList<Item> items = new List<Item> {
            Item.CreateBackStagePasses(1, 50)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Backstage passes to a TAFKAL80ETC concert", 0, 50, items[0]);
    }
    
    [Fact]
    public void AgedBrie_Pass_In_None_Condition()
    {
        IList<Item> items = new List<Item> {
            Item.CreateAgedBrie(2, 50)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Aged Brie", 1, 50, items[0]);
    }
    
    [Fact]
    public void AgedBrie_Pass_In_1()
    {
        IList<Item> items = new List<Item> { 
            Item.CreateAgedBrie(2, 48)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Aged Brie", 1, 49, items[0]);
    }
    
    [Fact]
    public void AgedBrie_Pass_In_1_2()
    {
        IList<Item> items = new List<Item> { 
            Item.CreateAgedBrie(0, 48)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Aged Brie", -1, 50, items[0]);
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_None_Condition()
    {
        IList<Item> items = new List<Item> {
            Item.Create("Conjured Mana Cake", 0, -1)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Conjured Mana Cake", -1, -1, items[0]);
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_All_Conditions()
    {
        IList<Item> items = new List<Item> { 
            Item.Create("Conjured Mana Cake", 0, 2)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Conjured Mana Cake", -1, 0, items[0]);
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_1()
    {
        IList<Item> items = new List<Item> { 
            Item.Create("Conjured Mana Cake", 1, 2)
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();
        
        ItemShouldMatch("Conjured Mana Cake", 0, 1, items[0]);
    }

    private static void ItemShouldMatch(string name, int sellIn, int quality, Item item)
    {
        item.Name.Should().Be(name);
        item.SellIn.Should().Be(sellIn);
        item.Quality.Should().Be(quality);
    }
}