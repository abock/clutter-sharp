ASSEMBLY_NAME = clutter-gtk-sharp

GAPI_SOURCES_XML = $(srcdir)/clutter-gtk-sources.xml
GAPI_METADATA = $(srcdir)/clutter-gtk.metadata
GAPI_RAW_API = $(srcdir)/clutter-gtk-api.raw

GAPI_FIXED_API = clutter-gtk-api.xml

CUSTOM_REFERENCES = -r:$(top_builddir)/clutter/clutter-sharp.dll
CUSTOM_API_INCLUDES = $(top_builddir)/clutter/Clutter/clutter-api.xml

GENERATED_DIRS = .

if ENABLE_GTK
TARGET = \
	$(ASSEMBLY_NAME).dll \
	$(ASSEMBLY_NAME).dll.config \
	$(ASSEMBLY_NAME).dll.mdb
else
TARGET =
endif

EXTRA_DIST =
CLEANFILES =

include $(top_srcdir)/build/gapi.mk
include $(top_srcdir)/build/assembly.mk

MAINTAINERCLEANFILES = Makefile.in
