// 
// StageStateEvent.cs
//  
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
// 
// Copyright 2009 Novell, Inc.
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
	public class StageStateEvent : Event
	{
		public StageStateEvent (IntPtr raw) : base(raw)
		{
		}

		[StructLayout (LayoutKind.Sequential)]
		private struct NativeStruct
		{
			public EventType type;
			public int time;
			public EventFlags flags;
			public IntPtr stage;
			public IntPtr source;
			public StageState changed_mask;
			public StageState new_state;
		}

		private NativeStruct Native {
			get { return (NativeStruct)Marshal.PtrToStructure (Handle, typeof (NativeStruct)); }
		}

		public StageState ChangedMask {
			get { return Native.changed_mask; }
			set {
				NativeStruct native = Native;
				native.changed_mask = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public StageState NewState {
			get { return Native.new_state; }
			set {
				NativeStruct native = Native;
				native.new_state = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}
	}
}

