// Clutter.KeyEvent.cs - Custom key event wrapper 
//
// Author:  Stephane Delcroix <stephane@delcroix.org> 
//
// Copyright (c) 2009 Novell, Inc.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of version 2 of the Lesser GNU General 
// Public License as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this program; if not, write to the
// Free Software Foundation, Inc., 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.


namespace Clutter {

	using System;
	using System.Runtime.InteropServices;

	public class KeyEvent : Event {

		public KeyEvent(IntPtr raw) : base(raw)
		{
		}

		[StructLayout (LayoutKind.Sequential)]
		struct NativeStruct {
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

		NativeStruct Native {
			get { return (NativeStruct) Marshal.PtrToStructure (Handle, typeof(NativeStruct)); }
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

