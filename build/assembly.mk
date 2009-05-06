ASSEMBLY = $(ASSEMBLY_NAME).dll
REFERENCES = $(GTKSHARP_LIBS) -r:Mono.Cairo $(CUSTOM_REFERENCES)

assemblydir = $(prefix)/lib/clutter-sharp
assembly_DATA = $(TARGET)

pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = $(ASSEMBLY_NAME).pc

clutter-sharp.snk:
	cp $(top_builddir)/clutter-sharp.snk .

$(ASSEMBLY): $(GAPI_FIXED_API) $(SOURCES) clutter-sharp.snk
	@rm -f $(ASSEMBLY).mdb
	$(MCS) $(CSFLAGS) -out:$@ -target:library -nowarn:0169 -unsafe \
		$(REFERENCES) $(SOURCES) AssemblyInfo.cs

$(ASSEMBLY).mdb: $(ASSEMBLY)

install-data-local:
	$(GACUTIL) /i $(ASSEMBLY) /f /package clutter-sharp /gacdir $(DESTDIR)$(prefix)/lib

uninstall-local:
	$(GACUTIL) /u $(ASSEMBLY_NAME) /package clutter-sharp /gacdir $(DESTDIR)$(prefix)/lib

EXTRA_DIST += \
	$(ASSEMBLY_NAME).pc.in \
	$(ASSEMBLY).config.in \
	$(SOURCES) \
	$(CUSTOMS)

CLEANFILES += \
	$(ASSEMBLY) \
	$(ASSEMBLY).mdb \
	clutter-sharp.snk

DISTCLEANFILES = \
	$(ASSEMBLY).config \
	$(ASSEMBLY_NAME).pc \
	AssemblyInfo.cs