// 
// ButtonEvent.cs
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
	public class ButtonEvent : Event
	{
		public ButtonEvent (IntPtr raw) : base (raw)
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
			public int x;
			public int y;
			public ModifierType modifier_state;
			public int button;
			public uint click_count;
			public IntPtr axes; // gdouble *, reserved for future use
			public IntPtr device; // InputDevice *, reserved for future use
		}

		private NativeStruct Native {
			get { return (NativeStruct)Marshal.PtrToStructure (Handle, typeof (NativeStruct)); }
		}

		public int X {
			get { return Native.x; }
			set {
				NativeStruct native = Native;
				native.x = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public int Y {
			get { return Native.y; }
			set {
				NativeStruct native = Native;
				native.y = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public ModifierType ModifierState {
			get { return Native.modifier_state; }
			set {
				NativeStruct native = Native;
				native.modifier_state = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public int Button {
			get { return Native.button; }
			set {
				NativeStruct native = Native;
				native.button = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public uint ClickCount {
			get { return Native.click_count; }
			set {
				NativeStruct native = Native;
				native.click_count = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}
	}
}

