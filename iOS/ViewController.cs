using System;
using RollerShutter.NET;
using UIKit;

namespace RollerShutter.iOS
{
    public partial class ViewController : UIViewController
    {
        private readonly RollerShutterManager _manager = new RollerShutterManager("192.168.2.56");

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        async partial void StopButton_TouchUpInside(UIButton sender)
        {
            sender.Enabled = false;
            await _manager.Stop();
            sender.Enabled = true;
        }

        async partial void UpButton_TouchUpInside(UIButton sender)
        {
            sender.Enabled = false;
            await _manager.MoveUp();
            sender.Enabled = true;
        }

        async partial void DownButton_TouchUpInside(UIButton sender)
        {
            sender.Enabled = false;
            await _manager.MoveDown();
            sender.Enabled = true;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}