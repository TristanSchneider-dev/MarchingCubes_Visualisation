using Godot;

public partial class ShowPointCloud : CheckButton
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
			this.ButtonPressed = _pointCloud.showPointCloud;
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
			// Aktualisiere die Sichtbarkeit und die showPointCloud-Eigenschaft
			_pointCloud.showPointCloud = buttonPressed;
			_pointCloud._pointCloudInstance.Visible = buttonPressed;

			// Rufe Generate auf, um die Punktwolke neu zu generieren
			_pointCloud.Generate();
		}
		else
		{
			GD.PrintErr("PointCloud-Node ist null. Überprüfen Sie den NodePath.");
		}
	}
}
