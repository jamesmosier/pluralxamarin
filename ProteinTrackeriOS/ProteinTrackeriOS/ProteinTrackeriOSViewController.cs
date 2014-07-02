using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ProteinTrackerMVC.Api;
using ProteinTrackerTest;
using System.Collections.Generic;

namespace ProteinTrackeriOS
{
	public partial class ProteinTrackeriOSViewController : UIViewController
	{
		//OG ..was here before july 2
//		public ProteinTrackeriOSViewController (IntPtr handle) : base (handle)
//		{
//		}

		public ProteinTrackeriOSViewController () : base ("ProteinTrackeriOSViewController")
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		//#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			

		}

//		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation)
//		{
//
//		}

//		public override void ViewWillAppear (bool animated)
//		{
//			base.ViewWillAppear (animated);
//		}
//
//		public override void ViewDidAppear (bool animated)
//		{
//			base.ViewDidAppear (animated);
//		}
//
//		public override void ViewWillDisappear (bool animated)
//		{
//			base.ViewWillDisappear (animated);
//		}
//
//		public override void ViewDidDisappear (bool animated)
//		{
//			base.ViewDidDisappear (animated);
//		}

		//#endregion
	}

	public class UserPickerModel : GenericPickerModel<User>
	{
		public UserPickerModel(IList<User> users) : base(users)
		{
		}
	}
}

