using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Items
{
	class BackstagePass : Item, IUpdateable
	{
		public void UpdateItem()
		{
			SellIn--;

			if (SellIn < 0)
			{
				Quality = 0;
			}
			else if (SellIn < 5)
			{
				Quality += 3;
			}
			else if (SellIn < 10)
			{
				Quality += 2;
			}
			else
			{
				Quality++;
			}
		}
	}
}
