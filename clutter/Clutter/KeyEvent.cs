// 
// KeyEvent.cs
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
	public class KeyEvent : Event
	{
		public KeyEvent (IntPtr raw) : base (raw)
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
			public ModifierType modifier_state;
			public uint keyval;
			public ushort hardware_keycode;
			public char unicode_value;
		}

		private NativeStruct Native {
			get { return (NativeStruct)Marshal.PtrToStructure (Handle, typeof (NativeStruct)); }
		}

		public ModifierType ModifierState {
			get { return Native.modifier_state; }
			set {
				NativeStruct native = Native;
				native.modifier_state = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public uint Symbol {
			get { return Native.keyval; }
			set {
				NativeStruct native = Native;
				native.keyval = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public ushort HardwareKeycode {
			get { return Native.hardware_keycode; }
			set {
				NativeStruct native = Native;
				native.hardware_keycode = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}

		public char UnicodeValue {
			get { return Native.unicode_value; }
			set {
				NativeStruct native = Native;
				native.unicode_value = value;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}
	}
}

