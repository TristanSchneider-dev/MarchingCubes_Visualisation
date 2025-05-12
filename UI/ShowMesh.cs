using Godot;

public partial class ShowMesh : CheckButton
{
	[Export] private NodePath pointCloudNodePath;
	private PointCloud _pointCloud;

	public override void _Ready()
	{
		// Verbinde das Toggled-Signal
		this.Toggled += OnToggled;

		// Hole die PointCloud-Referenz
		if (pointCloudNodePath != "")
		{
			_pointCloud = GetNode<PointCloud>(pointCloudNodePath);
		}
		else
		{
			// Falls kein Pfad angegeben, suche im Eltern-Node
			_pointCloud = GetParent<PointCloud>();
		}

		// Synchronisiere den Button-Status mit der aktuellen Sichtbarkeit
		if (_pointCloud != null)
		{
			this.ButtonPressed = _pointCloud.showMesh;
		}
		else
		{
			GD.PrintErr("PointCloud-Node konnte nicht gefunden werden.");
		}
	}

	private void OnToggled(bool buttonPressed)
	{
		if (_pointCloud != null)
		{
			// Update die Sichtbarkeit und die showMesh-Eigenschaft
			_pointCloud.showMesh = buttonPressed;
			_pointCloud._meshInstance.Visible = buttonPressed;

			// Rufe Generate auf, um die Mesh-Anzeige zu aktualisieren
			_pointCloud.Generate();
		}
		else
		{
			GD.PrintErr("PointCloud-Node ist null. Überprüfen Sie den NodePath.");
		}
	}
}
