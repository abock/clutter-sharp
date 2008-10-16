if ENABLE_CAIRO
CAIRO_ASSEMBLY=clutter-cairo-sharp.dll
CAIRO_REF=-r:clutter-cairo-sharp.dll -r:Mono.Cairo.dll
CAIRO_EXAMPLES=Flowers.exe
else
CAIRO_ASSEMBLY=
CAIRO_REF=
CAIRO_EXAMPLES=
endif

if ENABLE_GTK
GTK_ASSEMBLY=clutter-gtk-sharp.dll
GTK_REF=-r:clutter-gtk-sharp.dll
GTK_EXAMPLES=gtk-test.cs gtk-test-events.cs
else
GTK_ASSEMBLY=
GTK_REF=
GTK_EXAMPLES=
endif

if ENABLE_GST
GST_ASSEMBLY=clutter-gst-sharp.dll
GST_REF=-r:clutter-gst-sharp.dll
GST_EXAMPLES=gst-play-video.cs
else
GST_ASSEMBLY=
GST_REF=
GST_EXAMPLES=
endif

SAMPLES=test-actors.cs test-behave.cs test-entry.cs test-scale.cs test-shaders.cs test-script.cs test-scroll-actor.cs test-threads.cs $(CAIRO_EXAMPLES) $(GTK_EXAMPLES) $(GST_EXAMPLES)
MCSFLAGS= -debug -nologo -r:clutter-sharp.dll $(CAIRO_REF) $(GTK_REF) $(GST_REF)

assemblies=clutter-sharp.dll $(CAIRO_ASSEMBLY) $(GTK_ASSEMBLY) $(GST_ASSEMBLY)

noinst_SCRIPTS=$(SAMPLES:.cs=.exe)
%.exe: %.cs $(assemblies)
	$(MCS) $(MCSFLAGS) $(GTKSHARP_LIBS) -out:$@ $<

clutter-sharp.dll: $(top_builddir)/clutter/clutter-sharp.dll
	cp $(top_builddir)/clutter/clutter-sharp.dll* .

clutter-cairo-sharp.dll: $(top_builddir)/clutter-cairo/clutter-cairo-sharp.dll
	cp $(top_builddir)/clutter-cairo/clutter-cairo-sharp.dll* .

clutter-gtk-sharp.dll: $(top_builddir)/clutter-gtk/clutter-gtk-sharp.dll
	cp $(top_builddir)/clutter-gtk/clutter-gtk-sharp.dll* .

clutter-gst-sharp.dll: $(top_builddir)/clutter-gst/clutter-gst-sharp.dll
	cp $(top_builddir)/clutter-gst/clutter-gst-sharp.dll* .

EXTRA_DIST=$(SAMPLES)
CLEANFILES= *.exe *.mdb *.pdb *.dll

