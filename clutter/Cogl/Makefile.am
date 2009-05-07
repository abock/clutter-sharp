GAPI_SOURCES_XML = $(srcdir)/cogl-sources.xml
GAPI_METADATA = $(srcdir)/cogl.metadata
GAPI_RAW_API = $(srcdir)/cogl-api.raw
GAPI_SYMBOLS = $(srcdir)/cogl-symbols.xml

GAPI_FIXED_API = $(builddir)/cogl-api.xml

CLEANFILES =
EXTRA_DIST = parse-gl-h.awk

GL.cs: parse-gl-h.awk
	./$< < /usr/include/GL/gl.h > $@

include $(top_srcdir)/build/gapi.mk

MAINTAINERCLEANFILES = Makefile.in
