ASSEMBLY_NAME = clutter-gtk-sharp

GAPI_SOURCES_XML = clutter-gtk-sources.xml
GAPI_METADATA = clutter-gtk.metadata
GAPI_RAW_API = clutter-gtk-api.raw
GAPI_FIXED_API = clutter-gtk-api.xml

CUSTOM_REFERENCES = -r:$(top_builddir)/clutter/clutter-sharp.dll
CUSTOM_API_INCLUDES = $(top_builddir)/clutter/Clutter/clutter-api.xml

TARGET = \
	$(ASSEMBLY_NAME).dll \
	$(ASSEMBLY_NAME).dll.config \
	$(ASSEMBLY_NAME).dll.mdb

all: $(ASSEMBLY_NAME).dll

EXTRA_DIST =
CLEANFILES =

include $(top_builddir)/build/assembly.mk
include $(top_builddir)/build/gapi.mk

MAINTAINERCLEANFILES = Makefile.in
