// Clutter.ButtonEvent.cs - Custom button event wrapper 
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

	public class ButtonEvent : Event {

		public ButtonEvent(IntPtr raw) : base(raw)
		{
		}

		[StructLayout (LayoutKind.Sequential)]
		struct NativeStruct {
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
			public IntPtr axes; /* gdouble*, reserved for future use */
			public IntPtr device; /* InputDevice*, reserved for future use */
		}

		NativeStruct Native {
			get { return (NativeStruct) Marshal.PtrToStructure (Handle, typeof(NativeStruct)); }
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

