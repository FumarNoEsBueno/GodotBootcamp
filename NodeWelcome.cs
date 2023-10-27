using Godot;
using System;

public partial class NodeWelcome : Node2D
{
	private Godot.Collections.Array<Label> opciones = new Godot.Collections.Array<Label>(); 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.opciones.Add(new Label());
		this.opciones.Add(new Label());
		this.opciones.Add(new Label());

		for(int i = 0; i < this.opciones.Count; i++){
			this.opciones[i].Text = "Opcion " + (i+1);
			this.opciones[i].Visible = true;
			this.opciones[i].Position = new Vector2(32f,32f*(i+1));
			this.AddChild(this.opciones[i]);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
