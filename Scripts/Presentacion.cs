using Godot;
using System;

public partial class Presentacion : Label
{
	private int contador = 0;
	private Timer timer;
	private Label label;
	private bool eliminarNodo = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.timer = this.GetNode("Timer") as Timer;
		this.label = this.GetNode("Label") as Label;
		this.timer.Start(0.01f);
		this.VisibleCharacters = contador;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(eliminarNodo && Input.IsActionJustPressed("enter")){
			this.GetParent().AddChild(ResourceLoader.Load<PackedScene>("res://Scenes/node_welcome.tscn").Instantiate() as Node2D);
			QueueFree();
		}
	}
	
	private void _on_timer_timeout()
	{
		this.contador++;
		this.VisibleCharacters = contador;
		if(this.VisibleCharacters == this.Text.Length){
			this.timer.Stop();
			this.label.Visible = true;
			this.label.GetNode<AnimationPlayer>("AnimationPlayer").Play("new_animation");
			this.eliminarNodo = true;
		} 
	}
}



