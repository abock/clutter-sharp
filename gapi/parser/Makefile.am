noinst_SCRIPTS = gapi-fixup.exe gapi-parser.exe

sources = \
	gapi-fixup.cs \
	gapi-parser.cs

EXTRA_DIST = \
	$(sources) \
	gapi_pp.pl \
	gapi2xml.pl

gapi-fixup.exe: $(srcdir)/gapi-fixup.cs
	$(MCS) -out:gapi-fixup.exe $(srcdir)/gapi-fixup.cs

gapi-parser.exe: $(srcdir)/gapi-parser.cs
	$(MCS) -out:gapi-parser.exe $(srcdir)/gapi-parser.cs

CLEANFILES = gapi-fixup.exe gapi-parser.exe
MAINTAINERCLEANFILES = Makefile.in
