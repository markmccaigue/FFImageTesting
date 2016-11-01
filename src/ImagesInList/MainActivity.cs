using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;

namespace ImagesInList
{
    [Activity(Label = "ImagesInList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var listView = FindViewById<ListView>(Resource.Id.listView);

            var titles = Enumerable.Range(0, 100).ToArray();

            listView.Adapter = new ListItemImageAdapter(this, titles);
        }
    }
}