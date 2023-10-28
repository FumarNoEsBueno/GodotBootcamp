using Godot;
using System;

public partial class NodeWelcome : Node2D
{
	private Godot.Collections.Array<Label> opciones = new Godot.Collections.Array<Label>(); 
	private Label cursor;
	private int cursorPosition = 0;
	private const int nodosMercelo = 0;
	private const int nodosColita = 1;
	private const int nodosCanilla = 2;
	private const int nodosKriss = 3;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.cursor = new Label();
		this.cursor.Text = ">";
		this.cursor.Visible = true;
		this.cursor.Position = new Vector2(24f,32f);
		this.AddChild(this.cursor);

		this.opciones.Add(new Label());
		this.opciones.Add(new Label());
		this.opciones.Add(new Label());
		this.opciones.Add(new Label());

		for(int i = 0; i < this.opciones.Count; i++){
			switch(i){
				case 0:
					this.opciones[i].Text = "Nodos del Mercelo";
					break;
				case 1:
					this.opciones[i].Text = "Nodos del Colita";
					break;
				case 2:
					this.opciones[i].Text = "Nodos del Canilla";
					break;
				case 3:
					this.opciones[i].Text = "Nodos del Kriss";
					break;
			}
			this.opciones[i].Visible = true;
			this.opciones[i].Position = new Vector2(32f,32f*(i+1));
			this.AddChild(this.opciones[i]);
		}
	}

	private void controler(){

		if(Input.IsActionJustPressed("flechaAbajo")){
			cursorPosition++;
			if(cursorPosition > 3) cursorPosition = 0;
			this.cursor.Position = new Vector2(24f,32f + (cursorPosition * 32));
		}
		if(Input.IsActionJustPressed("flechaArriba")){
			cursorPosition--;
			if(cursorPosition < 0) cursorPosition = 3;
			this.cursor.Position = new Vector2(24f,32f + (cursorPosition * 32));
		}

		if(Input.IsActionJustPressed("enter")){//Aqui poner que se instancien los nodos de cada uno
		   switch(cursorPosition){
				case nodosMercelo:
					QueueFree();
					break;
				case nodosColita:
					QueueFree();
					break;
				case nodosKriss:
					QueueFree();
					break;
				case nodosCanilla:
					QueueFree();
					break;
		   } 
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.controler();
	}
}
