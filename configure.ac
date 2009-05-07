AC_PREREQ(2.52)

m4_define(clutter_sharp_version_major, 0)
m4_define(clutter_sharp_version_minor, 9)
m4_define(clutter_sharp_version_micro, 0)

AC_INIT([clutter-sharp], 
	[clutter_sharp_version_major.clutter_sharp_version_minor.clutter_sharp_version_micro])

AC_CONFIG_SRCDIR([README])
AC_CANONICAL_SYSTEM

AM_INIT_AUTOMAKE([1.9 foreign dist-bzip2 tar-ustar])
AM_MAINTAINER_MODE

PKG_PROG_PKG_CONFIG

DISTCHECK_CONFIGURE_FLAGS="--disable-docs"
AC_SUBST(DISTCHECK_CONFIGURE_FLAGS)

dnl check for Mono
AC_PATH_PROG(MONO, mono, no)
if test "x$MONO" = "xno"; then
	AC_MSG_ERROR([Cannot find the "mono" runtime in your PATH])
fi

AC_PATH_PROG(MCS, gmcs, no)
if test "x$MCS" = "xno"; then
	AC_MSG_ERROR([Cannot find the "gmcs" compiler in your PATH])
fi

AC_PATH_PROG(GACUTIL, gacutil, no)
if test "x$GACUTIL" = "xno"; then
	AC_MSG_ERROR([Cannot find the "gacutil" program in your PATH])
fi

dnl check for GAPI
PKG_CHECK_MODULES(GAPI, gapi-2.0 >= 2.12.1)
AC_PATH_PROG(GAPI_PARSER, gapi2-parser, no)
AC_PATH_PROG(GAPI_CODEGEN, gapi2-codegen, no)
AC_PATH_PROG(GAPI_FIXUP, gapi2-fixup, no)
AC_SUBST(GAPI_FIXUP)
AC_SUBST(GAPI_CODEGEN)
AC_SUBST(GAPI_PARSER)

dnl check for Gtk#
PKG_CHECK_MODULES(GTKSHARP, gtk-sharp-2.0 > 2.12)
AC_SUBST(GTKSHARP_LIBS)

dnl check for clutter
PKG_CHECK_MODULES(CLUTTER, clutter-0.9 >= 0.9.0)
PKG_CHECK_MODULES(CLUTTER_GTK, clutter-gtk-0.9 >= 0.9.0, enable_gtk=yes, enable_gtk=no)

AM_CONDITIONAL(ENABLE_GTK, test "x$enable_gtk" = "xyes")

CLUTTER_APIVERSION=$(pkg-config --variable apiversion clutter-0.9)
CLUTTER_BACKEND=$(pkg-config --variable backend clutter-0.9)
AC_SUBST(CLUTTER_APIVERSION)
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
	clutter/clutter-sharp.pc
	clutter/Makefile
	clutter/Clutter/Makefile
	clutter/Cogl/Makefile
	clutter/AssemblyInfo.cs
	clutter/clutter-sharp.dll.config
	clutter-gtk/clutter-gtk-sharp.pc
	clutter-gtk/Makefile
	clutter-gtk/AssemblyInfo.cs
	clutter-gtk/clutter-gtk-sharp.dll.config
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

