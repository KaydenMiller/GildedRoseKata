using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Items
{
	class StandardItem : Item, IUpdateable
	{
		public void UpdateItem()
		{
			SellIn--;

			if (Quality > 0)
			{
				if (SellIn < 0)
				{
					Quality -= 2;
				}
				else
				{
					Quality--;
				}
			}
		}
	}
}
