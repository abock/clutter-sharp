AC_INIT(README)
AC_CANONICAL_SYSTEM

AM_INIT_AUTOMAKE(clutter-sharp, 0.1.0)

AM_MAINTAINER_MODE

AC_PATH_PROG(MONO, mono, no)
if test "x$MONO" = "xno"; then
	AC_MSG_ERROR([Cannot find the "mono" runtime in your PATH])
fi

AC_PATH_PROG(MCS, mcs, no)
if test "x$MCS" = "xno"; then
	AC_MSG_ERROR([Cannot find the "mcs" compiler in your PATH])
fi

AC_PATH_PROG(GACUTIL, gacutil, no)
if test "x$GACUTIL" = "xno"; then
	AC_MSG_ERROR([Cannot find the "gacutil" program in your PATH])
fi

AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
	AC_MSG_ERROR([Cannot find the "pkg-config" program in your PATH])
fi

AC_ARG_ENABLE(docs,
              AC_HELP_STRING([--disable-docs],
                             [Do not build Monodoc documentation]),
              with_docs=no, with_docs=yes)

if test "x$with_docs" = "xyes"; then
	AC_PATH_PROG(MONODOCER, monodocer, no)
	if test "x$MONODOCER" = "xno"; then
		AC_MSG_ERROR([You need to install monodoc])
	fi

	AC_PATH_PROG(MDASSEMBLER, mdassembler, no)
	if test "x$MDASSEMBLER" = "xno"; then
		AC_MSG_ERROR([You need to install mdassembler])
	fi

	DOCDIR=`$PKG_CONFIG monodoc --variable=sourcesdir`
	AC_SUBST(DOCDIR)

	AM_CONDITIONAL(BUILD_DOCS, true)
else
	AC_MSG_NOTICE([not building API documentation])
	AM_CONDITIONAL(BUILD_DOCS, false)
fi

PKG_CHECK_MODULES(GTKSHARP, gtk-sharp-2.0 > 2.3.92)
AC_SUBST(GTKSHARP_LIBS)

PKG_CHECK_MODULES(CLUTTER, clutter-0.2 >= 0.2.0)

AC_OUTPUT([
	Makefile
	clutter-sharp.pc
	gapi/Makefile
	src/Makefile
	src/AssemblyInfo.cs
	src/clutter-sharp.dll.config
	examples/Makefile
])

