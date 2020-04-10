// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RollerShutter.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DownButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StopButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton UpButton { get; set; }

        [Action ("DownButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DownButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("StopButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StopButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UpButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UpButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DownButton != null) {
                DownButton.Dispose ();
                DownButton = null;
            }

            if (StopButton != null) {
                StopButton.Dispose ();
                StopButton = null;
            }

            if (UpButton != null) {
                UpButton.Dispose ();
                UpButton = null;
            }
        }
    }
}