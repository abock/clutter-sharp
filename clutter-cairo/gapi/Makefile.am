GAPI_PARSER = gapi2-parser
GAPI_CODEGEN = gapi2-codegen
GAPI_FIXUP = gapi2-fixup

SOURCES_XML = $(srcdir)/clutter-cairo-sources.xml
CLUTTER_CAIRO_METADATA = $(srcdir)/clutter-cairo.metadata
CLUTTER_CAIRO_RAW_API = $(srcdir)/clutter-cairo-api.raw
CLUTTER_CAIRO_FIXED_API = $(srcdir)/clutter-cairo-api.xml

CLEANFILES = $(CLUTTER_CAIRO_RAW_API) $(CLUTTER_CAIRO_FIXED_API)
DISTCLEANFILES = Makefile.in
EXTRA_DIST = $(SOURCES_XML) $(CLUTTER_CAIRO_METADATA)

gapidir = $(datadir)/gapi-2.0
gapi_DATA = $(CLUTTER_CAIRO_FIXED_API)

$(CLUTTER_CAIRO_FIXED_API):
	$(GAPI_PARSER) $(SOURCES_XML)
	cp $(CLUTTER_CAIRO_RAW_API) $(CLUTTER_CAIRO_FIXED_API)
	$(GAPI_FIXUP) --api=$(CLUTTER_CAIRO_FIXED_API) --metadata=$(CLUTTER_CAIRO_METADATA)
	$(GAPI_CODEGEN) --outdir=$(top_builddir)/src `pkg-config --cflags gtk-sharp-2.0` `pkg-config --cflags clutter-sharp` --customdir=$(top_builddir)/src --generate $(CLUTTER_CAIRO_FIXED_API)

