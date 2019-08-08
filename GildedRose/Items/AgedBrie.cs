using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Items
{
	class AgedBrie : Item, IUpdateable
	{
		public void UpdateItem()
		{
			SellIn--;

			if (Quality < 50)
			{
				Quality++;
			}
		}
	}
}
