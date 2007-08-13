SAMPLES=Test.cs TestEvents.cs
MCSFLAGS= -debug -nologo -r:clutter-gtk-sharp.dll -pkg:clutter-sharp -pkg:gtk-sharp-2.0

EXTRA_DIST=$(SAMPLES)
CLEANFILES= *.exe *.mdb *.pdb *.dll

noinst_SCRIPTS=$(SAMPLES:.cs=.exe)

%.exe: %.cs clutter-gtk-sharp.dll
	$(MCS) $(MCSFLAGS) -out:$@ $<

clutter-gtk-sharp.dll: $(top_builddir)/src/clutter-gtk-sharp.dll
	cp $(top_builddir)/src/clutter-gtk-sharp.dll* .

