using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
	public class GildedRose
	{
		IList<Item> Items;

		public GildedRose(IList<Item> Items)
		{
			this.Items = Items;
		}

		public void UpdateQuality()
		{
			var updatedItems = QualityControl.UpdateQuality(Items);

			Items = updatedItems;
		}
	}
}
