using Godot;

public partial class Wireframe : CheckButton
{
	private Viewport viewport;

	public override void _Ready()
	{
		// Verbinde das Toggled-Signal mit unserer Methode
		this.Toggled += OnToggled;
		
		// Finde den Viewport (kann je nach deiner Szenenstruktur variieren)
		viewport = GetViewport();
	}

	private void OnToggled(bool buttonPressed)
	{
		if (viewport == null)
			return;

		viewport.DebugDraw = buttonPressed ? Viewport.DebugDrawEnum.Wireframe : Viewport.DebugDrawEnum.Disabled;
	}
}
