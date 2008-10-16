SOURCES_XML = clutter-gtk-sources.xml
CLUTTER_METADATA = clutter-gtk.metadata
CLUTTER_RAW_API = clutter-gtk-api.raw
CLUTTER_FIXED_API = clutter-gtk-api.xml

ASSEMBLY_NAME = clutter-gtk-sharp
ASSEMBLY = clutter-gtk-sharp.dll

if ENABLE_GTK
TARGET = $(ASSEMBLY) $(ASSEMBLY).config
else
TARGET=
endif

custom_extradist=clutter-gtk-sharp.pc.in clutter-gtk-sharp.dll.config.in
custom_references=-r:../clutter/clutter-sharp.dll
custom_api_includes=../clutter/clutter-api.xml

sources = 

customs = 

include ../Makefile.include

