SAMPLES=test-actors.cs test-behave.cs test-entry.cs test-scale.cs test-shaders.cs test-script.cs test-threads.cs
MCSFLAGS= -debug -nologo -r:clutter-sharp.dll

EXTRA_DIST=$(SAMPLES)
CLEANFILES= *.exe *.mdb *.pdb *.dll

noinst_SCRIPTS=$(SAMPLES:.cs=.exe)

%.exe: %.cs clutter-sharp.dll
	$(MCS) $(MCSFLAGS) `pkg-config --libs gtk-sharp-2.0` -out:$@ $<

clutter-sharp.dll: $(top_builddir)/src/clutter-sharp.dll
	cp $(top_builddir)/src/clutter-sharp.dll* .

