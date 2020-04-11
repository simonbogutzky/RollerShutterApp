/*
 The MIT License (MIT)
 Copyright (c) 2020 Simon Bogutzky
 
 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

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