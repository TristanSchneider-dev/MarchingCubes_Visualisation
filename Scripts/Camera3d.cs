using Godot;

public partial class Camera3d : Camera3D
{
	[Export]
	public float RotationSpeed = 0.1f;
	
	[Export]
	public float CameraHeight = 0.0f;
	
	[Export]
	public float Radius = 7.0f;
	
	private float _angle = 0.0f;

	public override void _Process(double delta)
	{
		// Winkel basierend auf der Zeit und der Rotationsgeschwindigkeit aktualisieren
		_angle += RotationSpeed * (float)delta;
		
		// Kamera positionieren
		Position = new Vector3(
			Mathf.Sin(_angle) * Radius,
			CameraHeight,
			Mathf.Cos(_angle) * Radius
		);
		
		// Kamera auf den Ursprung ausrichten
		LookAt(Vector3.Zero, Vector3.Up);
	}
}
