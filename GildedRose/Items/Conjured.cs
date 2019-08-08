using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Items
{
	class Conjured : Item, IUpdateable
	{
		public void UpdateItem()
		{
			SellIn--;

			if (Quality > 0)
			{
				Quality -= 2;
			}
		}
	}
}
