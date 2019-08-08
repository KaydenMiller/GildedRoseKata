﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose
{
	static class QualityControl
	{
		private static string[] customItems =
		{
			"Aged Brie",
			"Backstage passes to a TAFKAL80ETC concert",
			"Sulfuras, Hand of Ragnaros",
			"Conjured"
		};

		public static IList<Item> UpdateQuality(IList<Item> items)
		{
			UpdateAgedBrie(ref items);
			UpdateBackstagePass(ref items);
			UpdateSulfuras(ref items);
			UpdateConjured(ref items);
			UpdateOther(ref items);

			return items;
		}

		private static void UpdateConjured(ref IList<Item> items)
		{
			items.Where(item => item.Name == customItems[3]).ToList().ForEach(item =>
			{
				item.SellIn--;

				if (item.Quality > 0)
				{
					item.Quality -= 2;
				}
			});
		}

		private static void UpdateOther(ref IList<Item> items)
		{
			items.Where(item => !customItems.Contains(item.Name)).ToList().ForEach(item =>
			{
				item.SellIn--;
				
				if (item.Quality > 0)
				{
					if (item.SellIn < 0)
					{
						item.Quality -= 2;
					}
					else
					{
						item.Quality--;
					}
				}
			});
		}

		private static void UpdateSulfuras(ref IList<Item> items)
		{
			items.Where(item => item.Name == customItems[2]).ToList().ForEach(item =>
			{
				item.SellIn = item.SellIn;
				item.Quality = 80;
			});
		}

		private static void UpdateBackstagePass(ref IList<Item> items)
		{
			items.Where(item => item.Name == customItems[1]).ToList().ForEach(item =>
			{
				item.SellIn--;

				if (item.SellIn < 0)
				{
					item.Quality = 0;
				}
				else if (item.SellIn < 5)
				{
					item.Quality += 3;
				}
				else if (item.SellIn < 10)
				{
					item.Quality += 2;
				}
				else
				{
					item.Quality++;
				}
			});
		}

		private static void UpdateAgedBrie(ref IList<Item> items)
		{
			items.Where(item => item.Name == customItems[0]).ToList().ForEach(item =>
			{
				item.SellIn--;

				if (item.Quality < 50)
				{
					item.Quality++;
				}
			});
		}
	}
}
