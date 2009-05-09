gapidir = $(datadir)/gapi-2.0
gapi_DATA = $(GAPI_FIXED_API)

build_symbols = $(addprefix --symbols=$(srcdir)/, $(GAPI_SYMBOLS))
api_includes = $(GTKSHARP_CFLAGS) $(CUSTOM_API_INCLUDES)

api:
	$(GAPI_PARSER) $(GAPI_SOURCES_XML)
	$(top_srcdir)/build/gapi-parser-post.sed < $(GAPI_RAW_API) > $(GAPI_RAW_API).tmp
	mv $(GAPI_RAW_API).tmp $(GAPI_RAW_API)

$(GAPI_FIXED_API): $(GAPI_RAW_API) $(GAPI_METADATA) $(GAPI_SYMBOLS) $(wildcard *.custom)
	cp $(GAPI_RAW_API) $(GAPI_FIXED_API)
	chmod +w $(GAPI_FIXED_API)
	$(GAPI_FIXUP) --api=$(GAPI_FIXED_API) --metadata=$(GAPI_METADATA) $(build_symbols)
	$(GAPI_CODEGEN) --outdir=./generated --customdir=$(srcdir) $(api_includes) --generate $(GAPI_FIXED_API)

clean-local:
	rm -rf generated

EXTRA_DIST += \
	$(GAPI_RAW_API) \
	$(GAPI_METADATA) \
	$(GAPI_SOURCES_XML) \
	$(GAPI_SYMBOLS)

CLEANFILES += \
	generated-stamp \
	generated/*.cs \
	$(GAPI_FIXED_API)
