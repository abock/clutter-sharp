GAPI_PARSER = gapi2-parser
GAPI_CODEGEN = gapi2-codegen
GAPI_FIXUP = gapi2-fixup

SOURCES_XML = clutter-gtk-sources.xml
CLUTTER_GTK_METADATA = clutter-gtk.metadata
CLUTTER_GTK_RAW_API = clutter-gtk-api.raw
CLUTTER_GTK_FIXED_API = clutter-gtk-api.xml

gapidir = $(datadir)/gapi-2.0
gapi_DATA = $(CLUTTER_GTK_FIXED_API)

CLEANFILES = $(CLUTTER_GTK_RAW_API) $(CLUTTER_GTK_FIXED_API)
DISTCLEANFILES = Makefile.in
EXTRA_DIST = $(SOURCES_XML) $(CLUTTER_GTK_METADATA)

generate: $(CLUTTER_GTK_FIXED_API)

$(CLUTTER_GTK_FIXED_API): 
	$(GAPI_PARSER) $(SOURCES_XML)
	cp $(CLUTTER_GTK_RAW_API) $(CLUTTER_GTK_FIXED_API)
	$(GAPI_FIXUP) --api=$(CLUTTER_GTK_FIXED_API) --metadata=$(CLUTTER_GTK_METADATA)
	$(GAPI_CODEGEN) --outdir=$(top_builddir)/src --customdir=$(top_builddir)/src `pkg-config --cflags clutter-sharp` `pkg-config --cflags gtk-sharp-2.0` --generate $(CLUTTER_GTK_FIXED_API)

