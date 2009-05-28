// 
// Event.cs
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
	public class Event : GLib.IWrapper
	{
		private IntPtr raw;

		public Event (IntPtr raw) 
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
		private struct NativeStruct
		{
			public EventType type;
			public int time;
			public EventFlags flags;
			public IntPtr stage;
			public IntPtr source;
		}

		private NativeStruct Native {
			get { return (NativeStruct)Marshal.PtrToStructure (raw, typeof (NativeStruct)); }
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
			if (raw == IntPtr.Zero) {
				return null;
            }
            
			NativeStruct native = (NativeStruct)Marshal.PtrToStructure (raw, typeof (NativeStruct));
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

