SOURCES_XML = clutter-cairo-sources.xml
CLUTTER_METADATA = clutter-cairo.metadata
CLUTTER_RAW_API = clutter-cairo-api.raw
CLUTTER_FIXED_API = clutter-cairo-api.xml

ASSEMBLY_NAME = clutter-cairo-sharp
ASSEMBLY = clutter-cairo-sharp.dll

if ENABLE_CAIRO
TARGET = $(ASSEMBLY) $(ASSEMBLY).config
else
TARGET=
endif

custom_extradist=clutter-cairo-sharp.pc.in clutter-cairo-sharp.dll.config.in
custom_api_includes=../clutter/clutter-api.xml
custom_references=-r:Mono.Cairo.dll -r:../clutter/clutter-sharp.dll

sources = 

customs = 

include ../Makefile.include

