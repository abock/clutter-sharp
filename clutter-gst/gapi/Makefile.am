GAPI_PARSER = gapi2-parser
GAPI_CODEGEN = gapi2-codegen
GAPI_FIXUP = gapi2-fixup

SOURCES_XML = clutter-gst-sources.xml
CLUTTER_GST_METADATA = clutter-gst.metadata
CLUTTER_GST_RAW_API = clutter-gst-api.raw
CLUTTER_GST_FIXED_API = clutter-gst-api.xml

gapidir = $(datadir)/gapi-2.0
gapi_DATA = $(CLUTTER_GST_FIXED_API)

CLEANFILES = $(CLUTTER_GST_RAW_API) $(CLUTTER_GST_FIXED_API)
DISTCLEANFILES = Makefile.in
EXTRA_DIST = $(SOURCES_XML) $(CLUTTER_GST_METADATA)

generate: $(CLUTTER_GST_FIXED_API)

$(CLUTTER_GST_FIXED_API): 
	$(GAPI_PARSER) $(SOURCES_XML)
	cp $(CLUTTER_GST_RAW_API) $(CLUTTER_GST_FIXED_API)
	$(GAPI_FIXUP) --api=$(CLUTTER_GST_FIXED_API) --metadata=$(CLUTTER_GST_METADATA)
	$(GAPI_CODEGEN) --outdir=$(top_builddir)/src --customdir=$(top_builddir)/src `pkg-config --cflags clutter-sharp` `pkg-config --cflags gtk-sharp-2.0` --generate $(CLUTTER_GST_FIXED_API)

