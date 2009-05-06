// Clutter.Event.cs - Custom event wrapper 
//
// Adapted from GdkEvent
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

	public class Event : GLib.IWrapper {

		IntPtr raw;

		public Event(IntPtr raw) 
		{
			this.raw = raw;
		}

		public IntPtr Handle {
			get { return raw; }
		}

		[DllImport("clutter")]
		static extern IntPtr gdk_event_get_type ();

		public static GLib.GType GType {
			get { return new GLib.GType (gdk_event_get_type ()); }
		}

		[StructLayout (LayoutKind.Sequential)]
		struct NativeStruct {
			public EventType type;
			public int time;
			public EventFlags flags;
			public IntPtr stage;
			public IntPtr source;
		}

		NativeStruct Native {
			get { return (NativeStruct) Marshal.PtrToStructure (raw, typeof(NativeStruct)); }
		}

		public EventType Type {
			get { return Native.type; }
			set {
				NativeStruct native = Native;
				native.type = value;
				Marshal.StructureToPtr (native, raw, false);
			}
		}

		public int Time {
			get { return Native.time; }
			set {
				NativeStruct native = Native;
				native.time = value;
				Marshal.StructureToPtr (native, raw, false);
			}
		}

		public EventFlags Flags {
			get { return Native.flags; }
			set {
				NativeStruct native = Native;
				native.flags = value;
				Marshal.StructureToPtr (native, raw, false);
			}
		}

		public Stage Stage {
			get { return GLib.Object.GetObject (Native.stage, false) as Stage; }
			set {
				NativeStruct native = Native;
				native.stage = value == null ? IntPtr.Zero : value.Handle;
				Marshal.StructureToPtr (native, raw, false);
			}
		}

		public Actor Source {
			get { return GLib.Object.GetObject (Native.source, false) as Actor; }
			set {
				NativeStruct native = Native;
				native.source = value == null ? IntPtr.Zero : value.Handle;
				Marshal.StructureToPtr (native, raw, false);
			}
		}

		public static Event New (IntPtr raw)
		{
			return GetEvent (raw);
		}

		public static Event GetEvent (IntPtr raw)
		{
			if (raw == IntPtr.Zero)
				return null;

			NativeStruct native = (NativeStruct) Marshal.PtrToStructure (raw, typeof(NativeStruct));
			switch (native.type) {
			case EventType.KeyPress:
			case EventType.KeyRelease:
				return new KeyEvent (raw);
			case EventType.ButtonPress:
			case EventType.ButtonRelease:
				return new ButtonEvent (raw);
			case EventType.Motion:
				return new MotionEvent (raw);
			case EventType.Enter:
			case EventType.Leave:
				return new CrossingEvent (raw);
			case EventType.Scroll:
				return new ScrollEvent (raw);
			case EventType.StageState:
				return new StageStateEvent (raw);
			case EventType.DestroyNotify:
			case EventType.ClientMessage:
			case EventType.Delete:
			case EventType.Nothing:
			default:
				return new Clutter.Event (raw);
			}
		}
	}
}

