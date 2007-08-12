GAPI_PARSER = gapi2-parser
GAPI_CODEGEN = gapi2-codegen
GAPI_FIXUP = gapi2-fixup

SOURCES_XML = clutter-sources.xml
CLUTTER_METADATA = clutter.metadata
CLUTTER_RAW_API = clutter-api.raw
CLUTTER_FIXED_API = clutter-api.xml

gapidir = $(datadir)/gapi-2.0
gapi_DATA = $(CLUTTER_FIXED_API)

CLEANFILES = $(CLUTTER_RAW_API) $(CLUTTER_FIXED_API)
DISTCLEANFILES = Makefile.in
EXTRA_DIST = $(SOURCES_XML) $(CLUTTER_METADATA)

$(CLUTTER_FIXED_API): 
	$(GAPI_PARSER) $(SOURCES_XML)
	cp $(CLUTTER_RAW_API) $(CLUTTER_FIXED_API)
	$(GAPI_FIXUP) --api=$(CLUTTER_FIXED_API) --metadata=$(CLUTTER_METADATA)
	$(GAPI_CODEGEN) --outdir=$(top_builddir)/src --customdir=$(top_builddir)/src `pkg-config --cflags gtk-sharp-2.0` --generate $(CLUTTER_FIXED_API)

