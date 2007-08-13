SAMPLES=PlayVideo.cs
MCSFLAGS= -debug -nologo -r:clutter-gst-sharp.dll -pkg:clutter-sharp -pkg:gtk-sharp-2.0

EXTRA_DIST=$(SAMPLES)
CLEANFILES= *.exe *.mdb *.pdb *.dll

noinst_SCRIPTS=$(SAMPLES:.cs=.exe)

%.exe: %.cs clutter-gst-sharp.dll
	$(MCS) $(MCSFLAGS) -out:$@ $<

clutter-gst-sharp.dll: $(top_builddir)/src/clutter-gst-sharp.dll
	cp $(top_builddir)/src/clutter-gst-sharp.dll* .

