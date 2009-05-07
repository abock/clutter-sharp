SUBDIRS = Clutter Cogl .

ASSEMBLY_NAME = clutter-sharp

SOURCES = \
	Clutter/ButtonEvent.cs \
	Clutter/Application.cs \
	Clutter/CrossingEvent.cs \
	Clutter/Event.cs \
	Clutter/Idle.cs \
	Clutter/KeyEvent.cs \
	Clutter/MotionEvent.cs \
	Clutter/ScrollEvent.cs \
	Clutter/Source.cs \
	Clutter/StageStateEvent.cs \
	Clutter/Timeout.cs \
	Cogl/GL.cs
	Cogl/BufferBit.cs
	Cogl/MaterialLayerFlags.cs

GENERATED_DIRS = $(builddir)/Clutter $(builddir)/Cogl

CUSTOMS = \
	Clutter/BehaviourPath.custom \
	Clutter/Color.custom \
	Clutter/Exp.custom \
	Clutter/Knot.custom \
	Clutter/Ramp.custom \
	Clutter/Script.custom \
	Clutter/Smoothstep.custom \
	Clutter/Script.custom

EXTRA_DIST =
CLEANFILES =

TARGET = \
	$(ASSEMBLY_NAME).dll \
	$(ASSEMBLY_NAME).dll.config \
	$(ASSEMBLY_NAME).dll.mdb

include $(top_srcdir)/build/assembly.mk

MAINTAINERCLEANFILES = Makefile.in
