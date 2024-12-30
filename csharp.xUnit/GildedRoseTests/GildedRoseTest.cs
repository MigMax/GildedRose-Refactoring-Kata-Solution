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
            new Item
            {
                Name = "Sulfuras, Hand of Ragnaros", 
                SellIn = 2, 
                Quality = 2
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Sulfuras, Hand of Ragnaros",
            SellIn = 2,
            Quality = 2
        });
    }
    
    [Fact]
    public void Sulfuras2()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Aged Brie", 
                SellIn = 5, 
                Quality = 45
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Aged Brie", 
            SellIn = 4, 
            Quality = 46
        });
    }
    
    [Fact]
    public void Sulfuras3()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Aged Brie", 
                SellIn = 0, 
                Quality = 45
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Aged Brie", 
            SellIn = -1, 
            Quality = 47
        });
    }
    
    [Fact]
    public void Sulfuras4()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Aged Brie", 
                SellIn = 1, 
                Quality = 50
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Aged Brie", 
            SellIn = 0, 
            Quality = 50
        });
    }
    
    
    
    [Fact]
    public void Backstage1_Pass_In_All_Condition()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert", 
                SellIn = 0, 
                Quality = 45
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = -1, 
            Quality = 0
        });
    }
    
    [Fact]
    public void Backstage4_Pass_In_1()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert", 
                SellIn = 10, 
                Quality = 49
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 9, 
            Quality = 50
        });
    }
    
    [Fact]
    public void Backstage4_Pass_In_1_2()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert", 
                SellIn = 10, 
                Quality = 45
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 9, 
            Quality = 47
        });
    }
    
    [Fact]
    public void Backstage2_Passe_In_1_2_3()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert", 
                SellIn = 1, 
                Quality = 45
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 0, 
            Quality = 48
        });
    }
    
    [Fact]
    public void Backstage3_Pass_In_None_Condition()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert", 
                SellIn = 1, 
                Quality = 50
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert", 
            SellIn = 0, 
            Quality = 50
        });
    }
    
    [Fact]
    public void AgedBrie_Pass_In_None_Condition()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Aged Brie", 
                SellIn = 2, 
                Quality = 50
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Aged Brie", 
            SellIn = 1, 
            Quality = 50
        });
    }
    
    [Fact]
    public void AgedBrie_Pass_In_1()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Aged Brie", 
                SellIn = 2, 
                Quality = 48
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Aged Brie", 
            SellIn = 1, 
            Quality = 49
        });
    }
    
    [Fact]
    public void AgedBrie_Pass_In_1_2()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Aged Brie", 
                SellIn = 0, 
                Quality = 48
            } 
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Aged Brie", 
            SellIn = -1, 
            Quality = 50
        });
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_None_Condition()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Conjured Mana Cake", 
                SellIn = 0, 
                Quality = -1
            }
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Conjured Mana Cake", 
            SellIn = -1, 
            Quality = -1
        });
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_All_Conditions()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Conjured Mana Cake", 
                SellIn = 0, 
                Quality = 2
            }
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Conjured Mana Cake", 
            SellIn = -1, 
            Quality = 0
        });
    }
    
    [Fact]
    public void Other_Pass_In_Pass_In_1()
    {
        IList<Item> items = new List<Item> { 
            new Item
            {
                Name = "Conjured Mana Cake", 
                SellIn = 1, 
                Quality = 2
            }
        };
        
        GildedRose app = new GildedRose(items);
        
        app.UpdateQuality();

        items[0].Should().BeEquivalentTo(new Item
        {
            Name = "Conjured Mana Cake", 
            SellIn = 0, 
            Quality = 1
        });
    }
}