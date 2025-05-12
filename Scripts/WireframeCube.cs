using Godot;

public partial class WireframeCube : Node3D
{
	[Export] private int gridSize = 16;
	[Export] private float pointSpacing = 0.25f;

	public override void _Ready()
	{
		CreateBoundingCube();
	}
	
	private void CreateBoundingCube()
	{
		// Calculate the size of the entire grid
		float halfSize = (gridSize * pointSpacing) / 2f;
		
		MeshInstance3D cubeEdges = new MeshInstance3D();
		ImmediateMesh mesh = new ImmediateMesh();
		cubeEdges.Mesh = mesh;
		
		// Create material for the edges
		StandardMaterial3D material = new StandardMaterial3D();
		material.AlbedoColor = Colors.White;
		material.ShadingMode = BaseMaterial3D.ShadingModeEnum.Unshaded;
		material.Transparency = BaseMaterial3D.TransparencyEnum.Alpha;
		
		// Begin drawing lines
		mesh.SurfaceBegin(Mesh.PrimitiveType.Lines);
		
		// Set material for surface 0
		mesh.SurfaceSetMaterial(0, material);
		
		// Define the 8 corners of the cube
		Vector3[] corners = new Vector3[8];
		for (int i = 0; i < 8; i++)
		{
			corners[i] = new Vector3(
				(i & 1) == 0 ? -halfSize : halfSize,
				(i & 2) == 0 ? -halfSize : halfSize,
				(i & 4) == 0 ? -halfSize : halfSize
			);
		}
		
		// Draw all 12 edges of the cube
		// Bottom face
		mesh.SurfaceAddVertex(corners[0]);
		mesh.SurfaceAddVertex(corners[1]);
		
		mesh.SurfaceAddVertex(corners[1]);
		mesh.SurfaceAddVertex(corners[3]);
		
		mesh.SurfaceAddVertex(corners[3]);
		mesh.SurfaceAddVertex(corners[2]);
		
		mesh.SurfaceAddVertex(corners[2]);
		mesh.SurfaceAddVertex(corners[0]);
		
		// Top face
		mesh.SurfaceAddVertex(corners[4]);
		mesh.SurfaceAddVertex(corners[5]);
		
		mesh.SurfaceAddVertex(corners[5]);
		mesh.SurfaceAddVertex(corners[7]);
		
		mesh.SurfaceAddVertex(corners[7]);
		mesh.SurfaceAddVertex(corners[6]);
		
		mesh.SurfaceAddVertex(corners[6]);
		mesh.SurfaceAddVertex(corners[4]);
		
		// Vertical edges
		mesh.SurfaceAddVertex(corners[0]);
		mesh.SurfaceAddVertex(corners[4]);
		
		mesh.SurfaceAddVertex(corners[1]);
		mesh.SurfaceAddVertex(corners[5]);
		
		mesh.SurfaceAddVertex(corners[2]);
		mesh.SurfaceAddVertex(corners[6]);
		
		mesh.SurfaceAddVertex(corners[3]);
		mesh.SurfaceAddVertex(corners[7]);
		
		mesh.SurfaceEnd();
		
		AddChild(cubeEdges);
	}
}
