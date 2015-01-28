using UnityEngine;
using System.Collections;

public class Menu_Principal : VRGUI
{

	public override void OnVRGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width*0.4f,Screen.height*0.35f,Screen.width * 0.2f,Screen.height));
		{
			GUILayout.BeginVertical(); 
			{
				GUILayout.Label ("Simulador de Entrenamiento");
				GUILayout.Label ("---------Clase B----------");

				if (GUILayout.Button ("Simulacion Reprobatoria")) 
				{
					Application.LoadLevel ("Simulacion_Reprobatoria"); 
				}
				if (GUILayout.Button ("Simulacion Mixta")) 
				{
					Application.LoadLevel ("Simulacion_Mixta"); 
				}
				if (GUILayout.Button ("Simulacion Leve")) 
				{
					Application.LoadLevel ("Simulacion_Leve"); 
				}
				if (GUILayout.Button ("Salir")) 
				{
					Application.Quit();
				}
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}
}