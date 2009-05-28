ASSEMBLY = $(ASSEMBLY_NAME).dll
REFERENCES = $(GTKSHARP_LIBS) -r:Mono.Cairo $(CUSTOM_REFERENCES)

assemblydir = $(prefix)/lib/clutter-sharp
assembly_DATA = $(TARGET)

pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = $(ASSEMBLY_NAME).pc

SOURCES_BUILD = $(addprefix $(srcdir)/, $(SOURCES))

$(ASSEMBLY): $(GAPI_FIXED_API) $(SOURCES_BUILD)
	@rm -f $(ASSEMBLY).mdb
	$(MCS) $(CSFLAGS) -out:$@ -debug -target:library -nowarn:0169 -unsafe \
		$(REFERENCES) $(SOURCES_BUILD) AssemblyInfo.cs $(top_srcdir)/glib/*.cs $(foreach dir, $(GENERATED_DIRS), $(dir)/generated/*.cs)

$(ASSEMBLY).mdb: $(ASSEMBLY)

EXTRA_DIST += \
	$(ASSEMBLY_NAME).pc.in \
	$(ASSEMBLY).config.in \
	$(SOURCES) \
	$(CUSTOMS)

CLEANFILES += \
	$(ASSEMBLY) \
	$(ASSEMBLY).mdb

DISTCLEANFILES = \
	$(ASSEMBLY).config \
	$(ASSEMBLY_NAME).pc \
	AssemblyInfo.cs
