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
            Item.CreateDexterityVest(10, 20),
            Item.CreateAgedBrie(2, 0),
            Item.CreateElixir(5, 7),
            Item.CreateSulfuras(0, 80),
            Item.CreateSulfuras(-1, 80),
            Item.CreateBackStagePasses(15, 20),
            Item.CreateBackStagePasses(10, 49),
            Item.CreateBackStagePasses(5, 49),
            // this conjured item does not work properly yet
            Item.CreateManaCake(3, 6),
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