ASSEMBLY_NAME = clutter-gst-sharp
ASSEMBLY = $(ASSEMBLY_NAME).dll
SOURCES = 			\
	GstGlobal.cs 		\
	GstAudio.cs 		\
	GstVideoTexture.cs

all: $(ASSEMBLY)

$(ASSEMBLY): $(SOURCES)
	$(MCS) -out:$@ -debug -target:library -nowarn:0169 -unsafe $(GLIBSHARP_LIBS) $(CLUTTER_SHARP_LIBS) $(SOURCES) AssemblyInfo.cs

install-data-local:
	$(GACUTIL) /i $(ASSEMBLY) /f /package $(ASSEMBLY_NAME) /gacdir $(DESTDIR)$(libdir)

uninstall-local:
	$(GACUTIL) /u $(ASSEMBLY_NAME) /package $(ASSEMBLY_NAME) /gacdir $(libdir) /root $(DESTDIR)$(libdir)

CLEANFILES = $(ASSEMBLY) *.mdb
DISTCLEANFILES = Makefile.in
EXTRA_DIST = \
	$(SOURCES) \
	$(srcdir)/AssemblyInfo.cs.in \
	$(srcdir)/$(ASSEMBLY_NAME).snk \
	$(srcdir)/$(ASSEMBLY).config.in


