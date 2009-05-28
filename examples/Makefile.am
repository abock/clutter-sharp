SAMPLES = \
	test-cogl-primitives.cs \
	test-cogl-vertex-buffer.cs \
	test-actors.cs \
	test-behave.cs \
	test-entry.cs \
	test-shaders.cs \
	test-scale.cs \
	test-script.cs \
	test-scroll-actor.cs \
	test-threads.cs

ASSEMBLIES = clutter-sharp.dll glib-sharp.dll

if ENABLE_GTK
SAMPLES += \
	gtk-test.cs \
	gtk-test-events.cs

ASSEMBLIES += clutter-gtk-sharp.dll
endif

MCSFLAGS = -debug -unsafe $(GTKSHARP_LIBS) $(addprefix -r:, $(ASSEMBLIES)) -r:Mono.Cairo 

noinst_SCRIPTS = $(SAMPLES:.cs=.exe)

%.exe: %.cs $(ASSEMBLIES)
	$(MCS) $(MCSFLAGS) -out:$@ $<

clutter-sharp.dll: $(top_builddir)/clutter/clutter-sharp.dll
	cp $(top_builddir)/clutter/clutter-sharp.dll{,.config,.mdb} .

clutter-gtk-sharp.dll: $(top_builddir)/clutter-gtk/clutter-gtk-sharp.dll
	cp $(top_builddir)/clutter-gtk/clutter-gtk-sharp.dll{,.config,.mdb} .

glib-sharp.dll: $(top_builddir)/glib/glib-sharp.dll
	cp $(top_builddir)/glib/glib-sharp.dll{,.config} .

EXTRA_DIST = $(wildcard *.cs)
CLEANFILES = *.exe *.mdb *.dll *.config
