using Godot;
using System;

[Tool]
public partial class ColorPaletteButton : Godot.TextureButton
{
	[Export] Color color;
	EditorInterface edi;
	EditorSelection eds;
	
	public override void _EnterTree()
	{
		Pressed += ColorizeSelection;
	}
	
	public void ColorizeSelection()
	{
		EditorPlugin plugin = new EditorPlugin();
		edi = plugin.GetEditorInterface();
		eds = edi.GetSelection();
		var nodes = eds.GetSelectedNodes();
		
		StandardMaterial3D mat = new StandardMaterial3D();
		mat.AlbedoColor = color;
		
		foreach (MeshInstance3D node in nodes)
		{
			node.SetSurfaceOverrideMaterial(0, mat);
		}
	}
}
