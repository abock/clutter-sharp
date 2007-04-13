ASSEMBLY_NAME = clutter-sharp
ASSEMBLY = $(ASSEMBLY_NAME).dll
SOURCES = \
	Actor.cs		\
	ActorBox.cs		\
	ActorFlags.cs		\
	AddEventHandler.cs	\
	Alpha.cs		\
	AlphaFunc.cs		\
	AnyEvent.cs		\
	Behaviour.cs		\
	BehaviourForeachFunc.cs	\
	BehaviourOpacity.cs	\
	BehaviourPath.cs	\
	BehaviourScale.cs	\
	ButtonEvent.cs		\
	ButtonPressEventHandler.cs	\
	ButtonReleaseEventHandler.cs	\
	Callback.cs	\
	CloneTexture.cs	\
	ClutterRun.cs \
	ClutterSharp.AlphaFuncNative.cs	\
	ClutterSharp.BehaviourForeachFuncNative.cs	\
	ClutterSharp.CallbackNative.cs	\
	Color.cs	\
	DebugFlag.cs	\
	ErrorHandler.cs	\
	Event.cs	\
	EventType.cs	\
	Feature.cs	\
	FeatureFlags.cs	\
	Geometry.cs	\
	Global.cs	\
	Gravity.cs	\
	Group.cs	\
	Init.cs	\
	InitError.cs	\
	InputDevice.cs	\
	KeyEvent.cs	\
	KeyPressEventHandler.cs	\
	KeyReleaseEventHandler.cs	\
	Knot.cs	\
	KnotReachedHandler.cs	\
	Label.cs	\
	Main.cs	\
	Media.cs	\
	MotionEvent.cs	\
	MotionEventHandler.cs	\
	NewFrameHandler.cs	\
	ParentSetHandler.cs	\
	Ramp.cs	\
	Rectangle.cs	\
	RemoveEventHandler.cs	\
	SizeChangeHandler.cs	\
	Stage.cs	\
	Texture.cs	\
	Threads.cs	\
	Timeline.cs	

all: $(ASSEMBLY)

$(ASSEMBLY): $(SOURCES)
	$(MCS) -out:$@ -debug -target:library -nowarn:0169 -unsafe $(GTKSHARP_LIBS) $(SOURCES) AssemblyInfo.cs

install-data-local:
	$(GACUTIL) /i $(ASSEMBLY) /f /package $(ASSEMBLY_NAME) /gacdir $(DESTDIR)$(libdir)

uninstall-local:
	$(GACUTIL) /u $(ASSEMBLY_NAME) /package $(ASSEMBLY_NAME) /gacdir $(libdir) /root $(DESTDIR)$(libdir)

CLEANFILES = $(ASSEMBLY) *.mdb
DISTCLEANFILES = Makefile.in
EXTRA_DIST = \
	$(SOURCES) \
	$(srcdir)/AssemblyInfo.cs.in \
	$(srcdir)/$(ASSEMBLY_NAME).snk \
	$(srcdir)/$(ASSEMBLY).config.in


