using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			Parallel.ForEach(Items, (item) =>
			{
				
			});
			//var updatedItems = QualityControl.UpdateQuality(Items);

			//Items = updatedItems;
		}
	}
}
