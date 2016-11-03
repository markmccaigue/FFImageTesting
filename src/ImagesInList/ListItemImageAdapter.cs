using Android.App;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using FFImageLoading.Work;

namespace ImagesInList
{
    public class ListItemImageAdapter : BaseAdapter<int>
    {
        private readonly int[] _items;
        private readonly Activity _context;

        private class JavaToDotNetWrapper<T> : Java.Lang.Object
        {
            public T Value { get; }

            public JavaToDotNetWrapper(T value)
            {
                Value = value;
            }
        }

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

            var previousWork = imageView.Tag as JavaToDotNetWrapper<IScheduledWork>;
            previousWork?.Value?.Cancel();

            imageView.SetImageDrawable(null);

            var work = ImageService.Instance.LoadUrl($@"http://192.168.0.7:8011/{item}.png").Into(imageView);

            imageView.Tag = new JavaToDotNetWrapper<IScheduledWork>(work);

            return view;
        }
    }
}