// 
// Idle.cs
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
	public delegate bool IdleHandler ();

	public static class Idle
	{
		[GLib.CDeclCallback]
		private delegate bool IdleHandlerInternal ();

		internal class IdleProxy : SourceProxy
		{
			public IdleProxy (IdleHandler real)
			{
				real_handler = real;
				proxy_handler = new IdleHandlerInternal (Handler);
			}

			public bool Handler ()
			{
				bool cont = ((IdleHandler)real_handler) ();
				if (!cont) {
					Remove ();
		        }
		        
				return cont;
			}
		}
		
		[DllImport ("clutter")]
		private static extern uint clutter_threads_add_idle (IdleHandlerInternal d, IntPtr data);

		public static uint Add (IdleHandler handler)
		{
			var proxy = new IdleProxy (handler);
			uint code = clutter_threads_add_idle ((IdleHandlerInternal)proxy.proxy_handler, IntPtr.Zero);
			
			lock (Source.source_handlers) {
				Source.source_handlers[code] = proxy;
            }
            
			return code;
		}
	}
}

