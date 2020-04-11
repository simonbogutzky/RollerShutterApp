/*
 The MIT License (MIT)
 Copyright (c) 2020 Simon Bogutzky
 
 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RollerShutter.NET
{
    public class RollerShutterManager
    {
        /// <summary>
        ///     The server IP address.
        /// </summary>
        private readonly string _serverIpAddress;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:RollerShutter.NET.RollerShutterManager" /> class.
        /// </summary>
        /// <param name="serverIpAddress">The server IP address.</param>
        public RollerShutterManager(string serverIpAddress)
        {
            _serverIpAddress = serverIpAddress;
        }

        /// <summary>
        ///     Stops the roller shutters.
        /// </summary>
        /// <returns><c>true</c>, when the stop command is received, otherwise <c>false</c>.</returns>
        public async Task<bool> Stop()
        {
            return await SendCommand("stop");
        }

        /// <summary>
        ///     Moves the roller shutters up.
        /// </summary>
        /// <returns><c>true</c>, if the up command has been received, otherwise <c>false</c>.</returns>
        public async Task<bool> MoveUp()
        {
            return await SendCommand("up");
        }

        /// <summary>
        ///     Moves the roller shutters down.
        /// </summary>
        /// <returns><c>true</c>, if the down command has arrived, otherwise <c>false</c>.</returns>
        public async Task<bool> MoveDown()
        {
            return await SendCommand("down");
        }

        /// <summary>
        ///     Returns the firmware version.
        /// </summary>
        /// <returns>The firmware version.</returns>
        public async Task<string> GetFirmwareVersion()
        {
            var url = $@"http://{_serverIpAddress}/{"version"}";
            var response = await GetHttpWebResponse(url);
            return response;
        }

        /// <summary>
        ///     Sends a command.
        /// </summary>
        /// <returns><c>true</c>, if the command is received, otherwise <c>false</c>.</returns>
        /// <param name="command">The command.</param>
        private async Task<bool> SendCommand(string command)
        {
            var url = $@"http://{_serverIpAddress}/{command}";
            var response = await GetHttpWebResponse(url);
            return response == command;
        }

        /// <summary>
        ///     Returns a response from a URL.
        /// </summary>
        /// <returns>The content of the URL.</returns>
        /// <param name="url">The URL.</param>
        private static async Task<string> GetHttpWebResponse(string url)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "text/plain";
            request.Method = "GET";

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    if (response != null) throw new Exception("Server returned status code: " + response.StatusCode);
                    throw new Exception("Response is null.");
                }

                using (var reader = new StreamReader(response.GetResponseStream() ??
                                                     throw new Exception("Could not get response stream.")))
                {
                    var content = await reader.ReadToEndAsync();
                    if (string.IsNullOrWhiteSpace(content)) throw new Exception("Response contained an empty body.");

                    return content;
                }
            }
        }
    }
}