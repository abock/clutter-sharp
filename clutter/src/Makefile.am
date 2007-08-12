ASSEMBLY_NAME = clutter-sharp
ASSEMBLY = $(ASSEMBLY_NAME).dll
SOURCES = \
	Actor.cs	\
	ActorAddedHandler.cs	\
	ActorBox.cs	\
	ActorFlags.cs	\
	ActorRemovedHandler.cs	\
	AddEventHandler.cs	\
	Alpha.cs	\
	AlphaFunc.cs	\
	AnyEvent.cs	\
	AppliedHandler.cs	\
	Backend.cs	\
	Behaviour.cs	\
	BehaviourBspline.cs	\
	BehaviourEllipse.cs	\
	BehaviourForeachFunc.cs	\
	BehaviourOpacity.cs	\
	BehaviourPath.cs	\
	BehaviourRotate.cs	\
	BehaviourScale.cs	\
	Box.cs	\
	BoxChild.cs	\
	ButtonEvent.cs	\
	ButtonPressEventHandler.cs	\
	ButtonReleaseEventHandler.cs	\
	Callback.cs	\
	CloneTexture.cs	\
	ClutterRun.cs	\
	ClutterSharp.AlphaFuncNative.cs	\
	ClutterSharp.BehaviourForeachFuncNative.cs	\
	ClutterSharp.CallbackNative.cs	\
	ClutterSharp.EffectCompleteFuncNative.cs	\
	Color.cs	\
	Container.cs	\
	CursorEventHandler.cs	\
	DebugFlag.cs	\
	Effect.cs	\
	EffectCompleteFunc.cs	\
	EffectTemplate.cs	\
	Entry.cs	\
	ErrorHandler.cs	\
	Event.cs	\
	EventType.cs	\
	Exp.cs	\
	Feature.cs	\
	FeatureFlags.cs	\
	Geometry.cs	\
	Global.cs	\
	Gravity.cs	\
	Group.cs	\
	HBox.cs	\
	Init.cs	\
	InitError.cs	\
	InputDevice.cs	\
	KeyEvent.cs	\
	KeyPressEventHandler.cs	\
	KeyReleaseEventHandler.cs	\
	Knot.cs	\
	KnotReachedHandler.cs	\
	Label.cs	\
	Layout.cs	\
	LayoutFlags.cs	\
	Main.cs	\
	Margin.cs 	\
	Media.cs	\
	ModifierType.cs	\
	MotionEvent.cs	\
	MotionEventHandler.cs	\
	NewFrameHandler.cs	\
	Padding.cs	\
	PackType.cs	\
	ParentSetHandler.cs	\
	Perspective.cs	\
	Ramp.cs	\
	Rectangle.cs	\
	RemovedHandler.cs	\
	RemoveEventHandler.cs 	\
	RotateAxis.cs	\
	RotateDirection.cs	\
	ScrollDirection.cs	\
	ScrollEvent.cs	\
	ScrollEventHandler.cs	\
	Sine.cs	\
	SizeChangeHandler.cs	\
	Smoothstep.cs	\
	Stage.cs	\
	StageState.cs	\
	StageStateEvent.cs	\
	Texture.cs	\
	TextureFlags.cs	\
	Timeline.cs	\
	TimeoutPool.cs	\
	VBox.cs	\
	Vertex.cs

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


