{
	if ($0 ~ /default void ConnectDefaultHandlers/) {
		method_found = 1
	} else if (method_found == 1 && $0 ~ /{/) {
		in_method = 1
		if (mode == 1) {
			print
			print "// BEGIN PATCH"
			system ("monodis patch.dll | awk -v mode=0 -f " self)
			print "// END PATCH"
		}
	} else if (in_method == 1 && $0 ~ /}/) {
		in_method = 0
	}

	if (in_method == 1 && method_found == 1) {
		method_found = 0
	} else if ((in_method == 1 && mode == 0) || (in_method == 0 && mode == 1)) {
		print
	}
}
