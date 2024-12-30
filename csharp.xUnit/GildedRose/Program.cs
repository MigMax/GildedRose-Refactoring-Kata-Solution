using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Item> items = new List<Item>
        {
            Item.Create(ItemType.DexterityVest, 10, 20),
            Item.Create(ItemType.AgedBrie, 2, 0),
            Item.Create(ItemType.Elixir, 5, 7),
            Item.Create(ItemType.Sulfuras, 0, 80),
            Item.Create(ItemType.Sulfuras, -1, 80),
            Item.Create(ItemType.BackStagePasses, 15, 20),
            Item.Create(ItemType.BackStagePasses, 10, 49),
            Item.Create(ItemType.BackStagePasses, 5, 49),
            // this conjured item does not work properly yet
            Item.Create(ItemType.ManaCake, 3, 6),
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}