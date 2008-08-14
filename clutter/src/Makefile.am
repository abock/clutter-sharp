ASSEMBLY_NAME = clutter-sharp
ASSEMBLY = clutter-sharp.dll
TARGET = $(ASSEMBLY) $(ASSEMBLY).config
assemblydir = $(libdir)/clutter-sharp
assembly_DATA = $(TARGET)
CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb generated-stamp generated/*.cs $(API)
DISTCLEANFILES = $(ASSEMBLY).config
EXTRA_DIST = $(RAW_API) $(METADATA) $(customs) $(sources) clutter-sharp.pc.in clutter-sharp.dll.config.in

references = $(GTKSHARP_LIBS)

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

build_customs = $(addprefix $(srcdir)/, $(customs))
api_includes = $(GTKSHARP_CFLAGS)

$(ASSEMBLY): $(sources)
	@rm -f $(ASSEMBLY).mdb
	$(MCS) $(CSFLAGS) -out:$@ -target:library -nowarn:0169 -unsafe $(references) generated/*.cs $(sources)

