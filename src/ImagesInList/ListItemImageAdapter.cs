using Android.App;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;

namespace ImagesInList
{
    public class ListItemImageAdapter : BaseAdapter<int>
    {
        private readonly int[] _items;
        private readonly Activity _context;

        public ListItemImageAdapter(Activity context, int[] items)
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int this[int position] => _items[position];

        public override int Count => _items.Length;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.ListItem, null);

            var item = _items[position];

            view.FindViewById<TextView>(Resource.Id.Itemname).Text = item.ToString();

            var imageView = view.FindViewById<ImageViewAsync>(Resource.Id.icon);

            ImageService.Instance.LoadUrl($@"http://192.168.0.7:8011/{item}.png").Into(imageView);

            return view;
        }
    }
}