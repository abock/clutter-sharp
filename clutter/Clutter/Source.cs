// 
// Source.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Clutter
{
	// Base class for IdleProxy and TimeoutProxy
	internal class SourceProxy
	{
		internal Delegate real_handler;
		internal Delegate proxy_handler;

		internal void Remove ()
		{
			var keys = new List<uint> ();
			
			lock (Source.source_handlers) {
				foreach (uint code in Source.source_handlers.Keys) {
					if (Source.source_handlers [code] == this) {
						keys.Add (code);
					}
				}
				
				foreach (uint key in keys) {
					Source.source_handlers.Remove (key);
		        }
			}
			
			real_handler = null;
			proxy_handler = null;
		}
	}
	
    public static class Source
    {
		internal static Dictionary<uint, SourceProxy> source_handlers
		    = new Dictionary<uint, SourceProxy> ();
		
		[DllImport ("libglib-2.0-0.dll")]
		private static extern bool g_source_remove (uint tag);

		public static bool Remove (uint tag)
		{
			lock (source_handlers) {
				source_handlers.Remove (tag);
		    }
		    
			return g_source_remove (tag);
		}
	}
}
