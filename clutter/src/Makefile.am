ASSEMBLY_NAME = clutter-sharp
ASSEMBLY = $(ASSEMBLY_NAME).dll
SOURCES = \
	Actor.cs					\
	ActorAddedHandler.cs				\
	ActorBox.cs					\
	ActorFlags.cs					\
	ActorRemovedHandler.cs				\
	AddedHandler.cs					\
	Alpha.cs					\
	AlphaFunc.cs					\
	AnyEvent.cs					\
	AppliedHandler.cs				\
	Backend.cs					\
	Behaviour.cs					\
	BehaviourBspline.cs				\
	BehaviourDepth.cs				\
	BehaviourEllipse.cs				\
	BehaviourForeachFunc.cs				\
	BehaviourOpacity.cs				\
	BehaviourPath.cs				\
	BehaviourRotate.cs				\
	BehaviourScale.cs				\
	ButtonEvent.cs					\
	ButtonPressEventHandler.cs			\
	ButtonReleaseEventHandler.cs			\
	Callback.cs					\
	ChildMeta.cs					\
	ChildNotifyHandler.cs				\
	CloneTexture.cs					\
	ClutterRun.cs					\
	ClutterSharp.AlphaFuncNative.cs			\
	ClutterSharp.BehaviourForeachFuncNative.cs	\
	ClutterSharp.CallbackNative.cs			\
	ClutterSharp.EffectCompleteFuncNative.cs	\
	ClutterSharp.ModelFilterFuncNative.cs		\
	ClutterSharp.ModelForeachFuncNative.cs		\
	ClutterSharp.ModelSortFuncNative.cs		\
	ClutterSharp.ScriptConnectFuncNative.cs		\
	Color.cs					\
	Container.cs					\
	ContainerAdapter.cs				\
	CrossingEvent.cs				\
	CursorEventHandler.cs				\
	DebugFlag.cs					\
	Effect.cs					\
	EffectCompleteFunc.cs				\
	EffectTemplate.cs				\
	EnterEventHandler.cs				\
	Entry.cs					\
	ErrorHandler.cs					\
	Event.cs					\
	EventFlags.cs					\
	EventType.cs					\
	Exp.cs						\
	Feature.cs					\
	FeatureFlags.cs					\
	Fog.cs						\
	Frame.cs					\
	GLibSharp.GSourceFuncNative.cs			\
	Geometry.cs					\
	Global.cs					\
	Grab.cs						\
	Gravity.cs					\
	Group.cs					\
	IDPool.cs					\
	Idle.cs						\
	Init.cs						\
	InitError.cs					\
	InputDevice.cs					\
	KeyEvent.cs					\
	KeyPressEventHandler.cs				\
	KeyReleaseEventHandler.cs			\
	Knot.cs						\
	KnotReachedHandler.cs				\
	Label.cs					\
	LeaveEventHandler.cs				\
	ListModel.cs					\
	Main.cs						\
	MarkerReachedHandler.cs				\
	Media.cs					\
	MediaAdapter.cs					\
	Model.cs					\
	ModelFilterFunc.cs				\
	ModelForeachFunc.cs				\
	ModelIter.cs					\
	ModelSortFunc.cs				\
	ModifierType.cs					\
	MotionEvent.cs					\
	MotionEventHandler.cs				\
	NewFrameHandler.cs				\
	ParentSetHandler.cs				\
	Perspective.cs					\
	Ramp.cs						\
	Rectangle.cs					\
	RemovedHandler.cs				\
	RequestMode.cs					\
	RotateAxis.cs					\
	RotateDirection.cs				\
	RowAddedHandler.cs				\
	RowChangedHandler.cs				\
	RowRemovedHandler.cs				\
	Score.cs					\
	Script.cs					\
	ScriptConnectFunc.cs				\
	ScriptError.cs					\
	Scriptable.cs					\
	ScriptableAdapter.cs				\
	ScrollDirection.cs				\
	ScrollEvent.cs					\
	ScrollEventHandler.cs				\
	Shader.cs					\
	ShaderError.cs					\
	Sine.cs						\
	SizeChangeHandler.cs				\
	Smoothstep.cs					\
	Source.cs					\
	Stage.cs					\
	StageAddedHandler.cs				\
	StageManager.cs					\
	StageRemovedHandler.cs				\
	StageState.cs					\
	StageStateEvent.cs				\
	StageWindow.cs					\
	StageWindowAdapter.cs				\
	Texture.cs					\
	TextureError.cs					\
	TextureFlags.cs					\
	TextureQuality.cs				\
	Threads.cs					\
	Timeline.cs					\
	TimelineCompletedHandler.cs			\
	TimelineDirection.cs				\
	TimelineStartedHandler.cs			\
	Timeout.cs					\
	TimeoutPool.cs					\
	Ungrab.cs					\
	Value.cs					\
	Vertex.cs

all: $(ASSEMBLY)

$(ASSEMBLY): $(SOURCES)
	$(MCS) -out:$@ -debug -target:library -nowarn:0169 -unsafe $(GTKSHARP_LIBS) $(SOURCES) AssemblyInfo.cs

install-data-local:
	$(GACUTIL) /i $(ASSEMBLY) /f /package $(ASSEMBLY_NAME) /gacdir $(DESTDIR)$(libdir)

uninstall-local:
	$(GACUTIL) /u $(ASSEMBLY_NAME) /package $(ASSEMBLY_NAME) /gacdir $(libdir) /root $(DESTDIR)$(libdir)
	
CLEANFILES = $(ASSEMBLY) *.mdb
DISTCLEANFILES = Makefile.am
EXTRA_DIST = \
	$(SOURCES) \
	$(srcdir)/AssemblyInfo.cs.in \
	$(srcdir)/$(ASSEMBLY_NAME).snk \
	$(srcdir)/$(ASSEMBLY).config.in


