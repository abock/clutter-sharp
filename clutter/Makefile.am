SOURCES_XML = clutter-sources.xml
CLUTTER_METADATA = clutter.metadata
CLUTTER_RAW_API = clutter-api.raw
CLUTTER_FIXED_API = clutter-api.xml

ASSEMBLY_NAME = clutter-sharp
ASSEMBLY = clutter-sharp.dll

TARGET = $(ASSEMBLY) $(ASSEMBLY).config

custom_extradist= clutter-sharp.pc.in clutter-sharp.dll.config.in
custom_api_includes=
custom_references=

sources =		\
	$(srcdir)/ClutterRun.cs		\
	$(srcdir)/Idle.cs		\
	$(srcdir)/Source.cs		\
	$(srcdir)/Timeout.cs	

customs =			\
	BehaviourPath.custom		\
	Color.custom			\
	Exp.custom			\
	Knot.custom			\
	Ramp.custom			\
	Script.custom			\
	Smoothstep.custom		\
	Script.custom

include ../Makefile.include

