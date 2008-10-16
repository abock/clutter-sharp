SOURCES_XML = clutter-gst-sources.xml
CLUTTER_METADATA = clutter-gst.metadata
CLUTTER_RAW_API = clutter-gst-api.raw
CLUTTER_FIXED_API = clutter-gst-api.xml

ASSEMBLY_NAME = clutter-gst-sharp
ASSEMBLY = clutter-gst-sharp.dll

if ENABLE_GST
TARGET = $(ASSEMBLY) $(ASSEMBLY).config
else
TARGET=
endif

custom_extradist=clutter-gst-sharp.pc.in clutter-gst-sharp.dll.config.in
custom_api_includes=../clutter/clutter-api.xml
custom_references=-r:../clutter/clutter-sharp.dll

sources = 

customs = 

include ../Makefile.include

