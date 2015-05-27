using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ListaAgrupadaApp
{
	public class Group<TKey, TItem> : ObservableCollection<TItem>
	{
		public TKey Key { get; private set; }

		public Group (TKey key, IEnumerable<TItem> items)
		{
			this.Key = key;
			foreach (var item in items)
				this.Items.Add (item);
		}
	}
}

