using Godot;
using System;

public partial class SeedButton : Button
{
	[Export] private NodePath pointCloudNodePath;
	private PointCloud pointCloud;

	public override void _Ready()
	{
		// Referenz auf das PointCloud-Objekt holen
		pointCloud = GetNode<PointCloud>(pointCloudNodePath);

		// Button-Click-Event verbinden
		this.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		if (pointCloud != null)
		{
			// Neuen Seed setzen (z.B. einen zufälligen Seed verwenden)
			int newSeed = (int)GD.Randi(); // Zufälliger Seed
			pointCloud.Regenerate(newSeed);

			// Ausgabe zur Kontrolle
			GD.Print($"Seed wurde auf {newSeed} gesetzt und die Punktwolke wurde neu generiert.");
		}
		else
		{
			GD.PrintErr("PointCloud-Node konnte nicht gefunden werden. Überprüfen Sie den NodePath.");
		}
	}
}
