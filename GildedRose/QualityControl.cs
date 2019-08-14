using System;
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
			"Sulfuras, Hand of Ragnaros"
		};
		private static string[] customItemTypes =
		{
			"Conjured"
		};

		public static IList<Item> UpdateQuality(IList<Item> items)
		{
			items = UpdateAgedBrie(items);
			items = UpdateBackstagePass(items);
			items = UpdateSulfuras(items);
			items = UpdateConjured(items);
			items = UpdateOther(items);

			return items;
		}

		private static IList<Item> UpdateConjured(IList<Item> items)
		{
			items.Where(item => item.Name.Contains(customItemTypes[0])).ToList().ForEach(item =>
			{
				item.SellIn--;

				if (item.Quality > 0)
				{
					if (item.SellIn < 0)
					{
						if (item.Quality >= 4)
							item.Quality -= 4;
						else
							item.Quality = 0;
					}
					else
					{
						if (item.Quality >= 2)
							item.Quality -= 2;
						else
							item.Quality = 0;
					}
				}

			});

			return items;
		}

		private static IList<Item> UpdateOther(IList<Item> items)
		{
			items.Where(item => !customItems.Contains(item.Name))
				.Where(item => !item.Name.Contains(customItemTypes[0])).ToList().ForEach(item =>
			{
				item.SellIn--;
				
				if (item.Quality > 0)
				{
					if (item.SellIn < 0 && item.Quality >= 2)
					{
						item.Quality -= 2;
					}
					else
					{
						item.Quality--;
					}
				}
			});

			return items;
		}

		private static IList<Item> UpdateSulfuras(IList<Item> items)
		{
			items.Where(item => item.Name == customItems[2]).ToList().ForEach(item =>
			{
				item.SellIn = item.SellIn;
				item.Quality = 80;
			});

			return items;
		}

		private static IList<Item> UpdateBackstagePass(IList<Item> items)
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

				if (item.Quality > 50) item.Quality = 50;
			});

			return items;
		}

		private static IList<Item> UpdateAgedBrie(IList<Item> items)
		{
			items.Where(item => item.Name == customItems[0]).ToList().ForEach(item =>
			{
				item.SellIn--;
				
				if (item.Quality < 50)
				{
					if (item.SellIn < 0)
					{
						item.Quality += 2;
					}
					else
					{
						item.Quality++;
					}
				}
			});

			return items;
		}
	}
}
