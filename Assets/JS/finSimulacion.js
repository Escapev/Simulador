#pragma strict
  

var guisim : GameObject;
var GuiScript : Vrsimgui;

function Start () 
{
	guisim = GameObject.Find("RightEyeAnchor"); 
	GuiScript = guisim.GetComponent(Vrsimgui);
}

function OnTriggerEnter ()
{
	GuiScript.finSimulacion();
}