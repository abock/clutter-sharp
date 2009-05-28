// 
// Timeout.cs
//  
// Authors:
//   Thomas Van Machelen <thomas.vanmachelen@gmail.com>
//   Aaron Bockover <abockover@novell.com>
// 
// Copyright 2009 Thomas Van Machelen, Novell, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Runtime.InteropServices;

namespace Clutter
{
	public delegate bool TimeoutHandler ();

	public static class Timeout
	{
		[GLib.CDeclCallback]
		private delegate bool TimeoutHandlerInternal ();

		internal class TimeoutProxy : SourceProxy
		{
			public TimeoutProxy (TimeoutHandler real)
			{
				real_handler = real;
				proxy_handler = new TimeoutHandlerInternal (Handler);
			}

			public bool Handler ()
			{
				bool cont = ((TimeoutHandler)real_handler) ();
				if (!cont) {
					Remove ();
				}
				
				return cont;
			}
		}
		
		[DllImport ("libclutter-win32-0.9-0.dll")]
		private static extern uint clutter_threads_add_timeout (uint interval, TimeoutHandlerInternal d, IntPtr data);

		public static uint Add (uint interval, TimeoutHandler handler)
		{
			var proxy = new TimeoutProxy (handler);
			uint code = clutter_threads_add_timeout (interval, (TimeoutHandlerInternal)proxy.proxy_handler, IntPtr.Zero);
			
			lock (Source.source_handlers) {
				Source.source_handlers[code] = proxy;
            }
            
			return code;
		}
	}
}

