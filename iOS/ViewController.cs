/*
 The MIT License (MIT)
 Copyright (c) 2020 Simon Bogutzky
 
 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

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