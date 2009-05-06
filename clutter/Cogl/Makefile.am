GAPI_SOURCES_XML = cogl-sources.xml
GAPI_METADATA = cogl.metadata
GAPI_RAW_API = cogl-api.raw
GAPI_FIXED_API = cogl-api.xml
GAPI_SYMBOLS = cogl-symbols.xml

CLEANFILES =
EXTRA_DIST = parse-gl-h.awk

GL.cs: parse-gl-h.awk
	./$< < /usr/include/GL/gl.h > $@

include $(top_srcdir)/build/gapi.mk

MAINTAINERCLEANFILES = Makefile.in
