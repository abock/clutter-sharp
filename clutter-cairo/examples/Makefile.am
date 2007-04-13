SAMPLES=Flowers.cs
MCSFLAGS= -debug -nologo -r:clutter-cairo-sharp.dll -r:Mono.Cairo.dll -pkg:clutter-sharp -pkg:gtk-sharp-2.0

EXTRA_DIST=$(SAMPLES)
CLEANFILES= *.exe *.mdb *.pdb *.dll

noinst_SCRIPTS=$(SAMPLES:.cs=.exe)

%.exe: %.cs clutter-cairo-sharp.dll
	$(MCS) $(MCSFLAGS) -out:$@ $<

clutter-cairo-sharp.dll: $(top_builddir)/src/clutter-cairo-sharp.dll
	cp $(top_builddir)/src/clutter-cairo-sharp.dll* .

