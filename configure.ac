AC_PREREQ(2.52)

dnl major.minor follows Clutter API version
m4_define([clutter_sharp_version_major], [0])
m4_define([clutter_sharp_version_minor], [9])

dnl micro is specific to clutter-sharp
m4_define([clutter_sharp_version_micro], [0])

dnl set to 0 when doing a stable/supported release
m4_define([clutter_sharp_version_pre_release], [alpha1])

m4_define([concat], $1$2$3$4)

dnl create base version string
m4_define([clutter_sharp_version], concat(
	clutter_sharp_version_major.,
	clutter_sharp_version_minor.,
	clutter_sharp_version_micro))

dnl create the assembly version
m4_define([clutter_sharp_assembly_version], concat(
	clutter_sharp_version, [.0]))

dnl create the release version
m4_define([clutter_sharp_version],
	m4_if(clutter_sharp_version_pre_release, [0],
		clutter_sharp_version,
		concat(clutter_sharp_version, clutter_sharp_version_pre_release)))

AC_INIT([clutter-sharp], clutter_sharp_version)

AC_CONFIG_SRCDIR([README])
AC_CANONICAL_SYSTEM

AM_INIT_AUTOMAKE([1.9 foreign dist-bzip2 tar-ustar])
AM_MAINTAINER_MODE

PKG_PROG_PKG_CONFIG

DISTCHECK_CONFIGURE_FLAGS="--disable-docs"
AC_SUBST(DISTCHECK_CONFIGURE_FLAGS)

ASSEMBLY_VERSION=clutter_sharp_assembly_version
AC_SUBST(ASSEMBLY_VERSION)

dnl check for Mono
dnl 2.4 is required for non-signal VMs that we
dnl get with the in-tree GAPI and GType extensions
PKG_CHECK_MODULES(MONO_RUNTIME, mono >= 2.4)

AC_PATH_PROG(MONO, mono, no)
if test "x$MONO" = "xno"; then
	AC_MSG_ERROR([Cannot find the "mono" runtime in your PATH])
fi

AC_PATH_PROG(MCS, gmcs, no)
if test "x$MCS" = "xno"; then
	AC_MSG_ERROR([Cannot find the "gmcs" compiler in your PATH])
fi

dnl check for GAPI
dnl GAPI from gtk-sharp trunk is now required,
dnl so we are bundling it. Necessary for generating
dnl VM support for non-signal methods
#PKG_CHECK_MODULES(GAPI, gapi-2.0 >= 2.12.9)
#AC_PATH_PROG(GAPI_PARSER, gapi2-parser, no)
#AC_PATH_PROG(GAPI_FIXUP, gapi2-fixup, no)
#AC_PATH_PROG(GAPI_CODEGEN, gapi2-codegen, no)
GAPI_FIXUP="mono \$(top_builddir)/gapi/parser/gapi-fixup.exe"
GAPI_PARSER="mono \$(top_builddir)/gapi/parser/gapi-parser.exe \$(top_srcdir)/gapi/parser/"
GAPI_CODEGEN="mono \$(top_builddir)/gapi/generator/gapi_codegen.exe"
AC_SUBST(GAPI_FIXUP)
AC_SUBST(GAPI_PARSER)
AC_SUBST(GAPI_CODEGEN)

dnl check for Gtk#
PKG_CHECK_MODULES(GTKSHARP, gtk-sharp-2.0 >= 2.12.1)
AC_SUBST(GTKSHARP_LIBS)

dnl check for clutter
PKG_CHECK_MODULES(CLUTTER, clutter-0.9 >= 0.9.3)
PKG_CHECK_MODULES(CLUTTER_GTK, clutter-gtk-0.9 >= 0.9.1, enable_gtk=yes, enable_gtk=no)

AM_CONDITIONAL(ENABLE_GTK, test "x$enable_gtk" = "xyes")

CLUTTER_API_VERSION=$(pkg-config --variable apiversion clutter-0.9)
CLUTTER_BACKEND=$(pkg-config --variable backend clutter-0.9)
AC_SUBST(CLUTTER_API_VERSION)
AC_SUBST(CLUTTER_BACKEND)

dnl check for monodoc
AC_ARG_ENABLE(docs, AC_HELP_STRING([--disable-docs], 
	[Do not build documentation]), enable_docs=no, enable_docs=yes)

if test "x$enable_docs" = "xyes"; then
	AC_PATH_PROG(MONODOCER, monodocer, no)
	if test "x$MONODOCER" = "xno"; then
		AC_MSG_ERROR([You need to install monodoc, or pass --disable-docs to configure to skip documentation installation])
	fi

	AC_PATH_PROG(MDASSEMBLER, mdassembler, no)
	if test "x$MDASSEMBLER" = "xno"; then
		AC_MSG_ERROR([You need to install mdassembler, or pass --disable-docs to configure to skip documentation installation])
	fi

	DOCDIR=`$PKG_CONFIG monodoc --variable=sourcesdir`
	AC_SUBST(DOCDIR)
	AM_CONDITIONAL(BUILD_DOCS, true)
else
	AC_MSG_NOTICE([not building ${PACKAGE} API documentation])
	AM_CONDITIONAL(BUILD_DOCS, false)
fi

AC_OUTPUT([
	Makefile
	
	build/Makefile
	
	docs/Makefile
	docs/clutter-sharp/Makefile
	docs/clutter-gtk-sharp/Makefile
	
	gapi/Makefile
	gapi/parser/Makefile
	gapi/generator/Makefile
	
	glib/Makefile

	clutter/Makefile
	clutter/AssemblyInfo.cs
	clutter/clutter-sharp.pc
	clutter/clutter-sharp.dll.config
	clutter/Clutter/Makefile
	clutter/Cogl/Makefile

	clutter-gtk/Makefile
	clutter-gtk/clutter-gtk-sharp.pc
	clutter-gtk/clutter-gtk-sharp.dll.config
	clutter-gtk/AssemblyInfo.cs

	examples/Makefile
])

cat <<EOF

${PACKAGE}-${VERSION}

  Build Environment
    Install Prefix:    ${prefix}

    Mono C# Compiler:  ${MCS} ${CSFLAGS}
    Mono Runtime:      ${MONO}

  Build Features
    GTK Support:       ${enable_gtk}
    API Documentation: ${enable_docs}

EOF

