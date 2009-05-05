SOURCES_XML = clutter-sources.xml
CLUTTER_METADATA = clutter.metadata
CLUTTER_RAW_API = clutter-api.raw
CLUTTER_FIXED_API = clutter-api.xml

ASSEMBLY_NAME = clutter-sharp
ASSEMBLY = clutter-sharp.dll

SYMBOLS = clutter-symbols.xml

TARGET = $(ASSEMBLY) $(ASSEMBLY).config

custom_extradist = clutter-sharp.pc.in clutter-sharp.dll.config.in
custom_api_includes =
custom_references = -r:Mono.Cairo

sources =		\
	$(srcdir)/ButtonEvent.cs	\
	$(srcdir)/Application.cs		\
	$(srcdir)/CrossingEvent.cs	\
	$(srcdir)/Event.cs		\
	$(srcdir)/Idle.cs		\
	$(srcdir)/KeyEvent.cs		\
	$(srcdir)/MotionEvent.cs	\
	$(srcdir)/ScrollEvent.cs	\
	$(srcdir)/Source.cs		\
	$(srcdir)/StageStateEvent.cs	\
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

