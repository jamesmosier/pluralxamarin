using System;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ProteinTrackerMVC.Api;
using ProteinTrackerTest;
using System.Collections.Generic;
using ServiceStack.ServiceClient.Web;

namespace ProteinTrackeriOS
{
	public partial class ProteinTrackeriOSViewController : UIViewController
	{
		private JsonServiceClient client;
		private IList<User> users;

		//public ProteinTrackeriOSViewController () : base ("ProteinTrackeriOSViewController")
		public ProteinTrackeriOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//allows us to get rid of keyboard by tapping outside an input
			var tap = new UITapGestureRecognizer ();
			tap.AddTarget (() => {
				View.EndEditing (true);
			});
			View.AddGestureRecognizer (tap);


			client = new JsonServiceClient ("http://192.168.1.8:8080/api");

			PopulateUsers ();

			addUserButton.TouchUpInside += (object sender, EventArgs e) => {
				client.Send (new AddUser{ Name = nameText.Text, Goal = int.Parse (goalText.Text) });
				nameText.Text = string.Empty;
				goalText.Text = string.Empty;
				PopulateUsers ();
			};

			addAmountButton.TouchUpInside += (object sender, EventArgs e) => {
				var userPickerModel = selectUserPicker.Model as UserPickerModel;
				var response = client.Send (new AddProtein{ Amount = int.Parse (amountText.Text), UserId = userPickerModel.SelectedItem.Id });
				userPickerModel.SelectedItem.Total = response.NewTotal;
				totalLabel.Text = response.NewTotal.ToString ();
			};
		}


		void PopulateUsers ()
		{
			users = client.Get (new Users ()).Users.ToList ();

			var model = new UserPickerModel (users);
			model.ItemSelected += (object sender, EventArgs e) => {
				goalLabel.Text = model.SelectedItem.Goal.ToString();
				totalLabel.Text = model.SelectedItem.Total.ToString();
			};

			selectUserPicker.Model = model;
		}

		//public override bool ShouldAutorotateToInterfaceOrientation
	}

	public class UserPickerModel : GenericPickerModel<User>
	{
		public UserPickerModel (IList<User> users) : base (users)
		{
		}
	}
}

