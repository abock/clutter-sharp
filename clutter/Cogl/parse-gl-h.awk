#!/usr/bin/awk -f

BEGIN {
	print "// This file was generated by parse-gl-h.awk."
	print "// Any changes made will be lost if regenerated."
	print ""
	print "using System;"
	print ""
	print "namespace Clutter.Cogl"
	print "{"
	print "    internal class GL"
	print "    {"
}

/^\/\*.*\*\/$|^#define/ { 
	if ($0 ~ /^#/) {
		if ($2 ~ /^GL_/ && $3 ~ /^[0-9]/ && !($2 ~ /WIN32/)) {
			if (length ($3) > 6) {
				type = "uint"
			} else {
				type = "int"
			}

			print "        public const " type " " $2 " = " $3 ";"
		}
	} else {
		print ""
	}
}

END {
	print ""
	print "    }"
	print "}"
}

