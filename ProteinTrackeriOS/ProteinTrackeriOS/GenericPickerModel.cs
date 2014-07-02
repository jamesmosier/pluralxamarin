using System;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace ProteinTrackeriOS
{
	public abstract class GenericPickerModel<TItem> : UIPickerViewModel
	{
		public TItem SelectedItem { get; private set; }
		public event EventHandler ItemSelected;


		IList<TItem> _items;
		public IList<TItem> Items 
		{
			get { return _items; }
			set { _items = value; Selected (null, 0, 0); }
		}

		public GenericPickerModel()
		{
		}

		public GenericPickerModel(IList<TItem> items)
		{
			Items = items;
		}

		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			if (NoItem ()) 
			{
				return 1;
			}
			return Items.Count;
		}

		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			if (NoItem (row)) 
			{
				return "";
			}
			var item = Items [row];
			return GetTitleForItem (item);
		}

		public override void Selected(UIPickerView picker, int row, int component)
		{
			if (NoItem (row)) {
				SelectedItem = default(TItem);
			} else {
				SelectedItem = Items [row];
			}
			if(ItemSelected != null){
				ItemSelected (this, null);
			}
		}

		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public virtual string GetTitleForItem(TItem item)
		{
			return item.ToString ();
		}

	}
}

