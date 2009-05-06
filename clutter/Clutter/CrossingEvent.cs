// Clutter.CrossingEvent.cs - Custom crossing event wrapper 
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

	public class CrossingEvent : Event {

		public CrossingEvent(IntPtr raw) : base(raw)
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
			public IntPtr device; /* InputDevice*, reserved for future use */
			public IntPtr related;
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

		public Actor Related {
			get { return GLib.Object.GetObject (Native.related, false) as Actor; }
			set {
				NativeStruct native = Native;
				native.related = value == null ? IntPtr.Zero : value.Handle;
				Marshal.StructureToPtr (native, Handle, false);
			}
		}
	}
}

