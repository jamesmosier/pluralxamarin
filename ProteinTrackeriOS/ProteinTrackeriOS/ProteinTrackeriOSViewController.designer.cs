// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace ProteinTrackeriOS
{
	[Register ("ProteinTrackeriOSViewController")]
	partial class ProteinTrackeriOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton addAmountButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton addUserButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField amountText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel goalLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField goalText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField nameText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIPickerView selectUserPicker { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel totalLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (nameText != null) {
				nameText.Dispose ();
				nameText = null;
			}

			if (goalText != null) {
				goalText.Dispose ();
				goalText = null;
			}

			if (addUserButton != null) {
				addUserButton.Dispose ();
				addUserButton = null;
			}

			if (amountText != null) {
				amountText.Dispose ();
				amountText = null;
			}

			if (addAmountButton != null) {
				addAmountButton.Dispose ();
				addAmountButton = null;
			}

			if (selectUserPicker != null) {
				selectUserPicker.Dispose ();
				selectUserPicker = null;
			}

			if (totalLabel != null) {
				totalLabel.Dispose ();
				totalLabel = null;
			}

			if (goalLabel != null) {
				goalLabel.Dispose ();
				goalLabel = null;
			}
		}
	}
}
