if ENABLE_GTK
GTK_ASSEMBLY=clutter-gtk-sharp.dll
GTK_REF=-r:clutter-gtk-sharp.dll
GTK_EXAMPLES=gtk-test.cs gtk-test-events.cs
else
GTK_ASSEMBLY=
GTK_REF=
GTK_EXAMPLES=
endif

SAMPLES=test-actors.cs test-behave.cs test-entry.cs test-scale.cs test-shaders.cs test-script.cs test-scroll-actor.cs test-threads.cs $(GTK_EXAMPLES)
MCSFLAGS= -debug -nologo -r:clutter-sharp.dll $(CAIRO_REF) $(GTK_REF) $(GST_REF)

assemblies=clutter-sharp.dll $(GTK_ASSEMBLY)

noinst_SCRIPTS=$(SAMPLES:.cs=.exe)
%.exe: %.cs $(assemblies)
	$(MCS) $(MCSFLAGS) $(GTKSHARP_LIBS) -out:$@ $<

clutter-sharp.dll: $(top_builddir)/clutter/clutter-sharp.dll
	cp $(top_builddir)/clutter/clutter-sharp.dll* .

clutter-gtk-sharp.dll: $(top_builddir)/clutter-gtk/clutter-gtk-sharp.dll
	cp $(top_builddir)/clutter-gtk/clutter-gtk-sharp.dll* .

EXTRA_DIST=$(SAMPLES)
CLEANFILES= *.exe *.mdb *.pdb *.dll

