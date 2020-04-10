using Android.App;
using Android.OS;
using Android.Widget;
using RollerShutter.NET;

namespace RollerShutter.Droid
{
    [Activity(Label = "RollerShutter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private readonly RollerShutterManager _manager = new RollerShutterManager("192.168.2.56");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var stopButton = FindViewById<Button>(Resource.Id.stopButton);
            var upButton = FindViewById<Button>(Resource.Id.upButton);
            var downButton = FindViewById<Button>(Resource.Id.downButton);

            stopButton.Click += async delegate
            {
                stopButton.Enabled = false;
                await _manager.Stop();
                stopButton.Enabled = true;
            };

            upButton.Click += async delegate
            {
                upButton.Enabled = false;
                await _manager.MoveUp();
                upButton.Enabled = true;
            };

            downButton.Click += async delegate
            {
                downButton.Enabled = false;
                await _manager.MoveDown();
                downButton.Enabled = true;
            };
        }
    }
}