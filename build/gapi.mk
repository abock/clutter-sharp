GAPI_PARSER = gapi2-parser
GAPI_CODEGEN = gapi2-codegen
GAPI_FIXUP = gapi2-fixup

gapidir = $(datadir)/gapi-2.0
gapi_DATA = $(GAPI_FIXED_API)

build_symbols = $(addprefix --symbols=$(srcdir)/, $(GAPI_SYMBOLS))
api_includes = $(GTKSHARP_CFLAGS) $(API_INCLUDES)

api:
	$(GAPI_PARSER) $(GAPI_SOURCES_XML)
	$(top_srcdir)/build/gapi-parser-post.sed < $(GAPI_RAW_API) > $(GAPI_RAW_API).tmp
	mv $(GAPI_RAW_API).tmp $(GAPI_RAW_API)

$(GAPI_FIXED_API): $(GAPI_RAW_API) $(GAPI_METADATA) $(GAPI_SYMBOLS)
	cp $(GAPI_RAW_API) $(GAPI_FIXED_API)
	$(GAPI_FIXUP) --api=$(GAPI_FIXED_API) --metadata=$(GAPI_METADATA) $(build_symbols)
	$(GAPI_CODEGEN) --outdir=./generated --customdir=. $(api_includes) --generate $(GAPI_FIXED_API)

EXTRA_DIST += \
	$(GAPI_RAW_API) \
	$(GAPI_METADATA) \
	$(GAPI_SOURCES_XML) \
	$(GAPI_SYMBOLS)

CLEANFILES += \
	generated-stamp \
	generated/*.cs \
	$(GAPI_FIXED_API)
