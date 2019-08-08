using GildedRose;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTestProject
{
	public class GildedRoseTest
	{
		[Fact]
		public void ItemNameDoesNotChange()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
			GildedRose.GildedRose app = new GildedRose.GildedRose(Items);
			app.UpdateQuality();

			Assert.Equal("Aged Brie", Items[0].Name);
		}

		[Fact]
		public void QualityOfAnItemIsNeverNegative()
		{
			var Items = new List<Item> { new Item { Name = "Apple", SellIn = 10, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 20; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(0, Items[0].Quality);
		}

		[Fact]
		public void QualityOfAgedBrieIncreasesAsItGetsOlder()
		{
			var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 10; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(0, Items[0].SellIn);
			Assert.Equal(20, Items[0].Quality);
		}

		[Fact]
		public void QualityOfAnItemIsNeverGreaterThan50()
		{
			var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 50, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 100; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(50, Items[0].Quality);
		}

		[Fact]
		public void OnceSellInDatePassedQualityDecresesByDouble()
		{
			var Items = new List<Item> { new Item { Name = "Apple", SellIn = 1, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 2; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(-1, Items[0].SellIn);
			Assert.Equal(7, Items[0].Quality);
		}

		[Fact]
		public void SulfurasNeverSoldOrLowersInQuality()
		{
			var Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
			var app = new GildedRose.GildedRose(Items);
			app.UpdateQuality();

			Assert.Equal(10, Items[0].SellIn);
			Assert.Equal(80, Items[0].Quality);
		}

		[Fact]
		public void BackstagePassesIncreaseAt1WhenMoreThan10Days()
		{
			var Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);
			
			for (var i = 0; i < 10; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(20, Items[0].Quality);
		}

		[Fact]
		public void BackstagePassesIncreaseAt2WhenLessThan10Days()
		{
			var Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 11; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(22, Items[0].Quality);
		}

		[Fact]
		public void BackstagePassesIncreaseAt3WhenLessThan5Days()
		{
			var Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 16; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(33, Items[0].Quality);
		}

		[Fact]
		public void BackstagePassesStillHaveQualityAtDayOf()
		{
			var Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 20; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(45, Items[0].Quality);
		}

		[Fact]
		public void BackstagePassesDropTo0AfterSellByDatePasses()
		{
			var Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 21; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(0, Items[0].Quality);
		}

		[Fact]
		public void ConjuredItemsDegradeInQuality2TimesAsFastAsNormalItems()
		{
			var Items = new List<Item> { new Item { Name = "Conjured", SellIn = 10, Quality = 10 } };
			var app = new GildedRose.GildedRose(Items);

			for (var i = 0; i < 1; i++)
			{
				app.UpdateQuality();
			}

			Assert.Equal(8, Items[0].Quality);
		}
	}
}
