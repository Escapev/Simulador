using UnityEngine;
using System.Collections;
using System;

public class Vrsimgui : VRGUI
{
	public int reprobatorio = 0;
	public int grave = 0;
	public int leve = 0;
	public string hora_inicial = "";
	public string url = "http://190.160.26.167/SimVR/actualizar_historial.php";

	GUIStyle tamañoletra;

	void Start()
	{
		tamañoletra = new GUIStyle();
		tamañoletra.fontSize = 42;
		tamañoletra.normal.textColor = Color.white;
		hora_inicial = System.DateTime.Now.ToString("HH:mm:ss");		 
	}

	public void contadorReprobatorio()
	{
		reprobatorio = reprobatorio + 1;
	}

	public void contadorGrave()
	{
		grave = grave + 1;
	}

	public void contadorLeve()
	{
		leve = leve + 1;
	}

	public void finSimulacion()
	{
		string nombre_simulador = Application.loadedLevelName;
		string dia = System.DateTime.Now.ToString("dd");
		string mes = System.DateTime.Now.ToString("MM");
		string año = System.DateTime.Now.ToString("yyyy");
		string hora_final = System.DateTime.Now.ToString("HH:mm:ss");
		string rut = PlayerPrefs.GetString("Rut");
		StartCoroutine (actualizarhistorial (dia,mes,año,hora_inicial,hora_final,
		                                     rut,nombre_simulador,reprobatorio,grave,leve));
	}

	IEnumerator actualizarhistorial(string dia, string mes, string año,string hora_inicial, 
	                                string hora_final,string rut, string nombre_simulador,int reprobatorio, int grave, int leve)
	{
		string url = this.url + "?fecha=" + año + "-" + mes + "-" +dia + "&hora_inicial=" + hora_inicial + 
			"&hora_final=" + hora_final + "&rut=" + rut + "&nombre_simulador=" + nombre_simulador + "&e_reprobatorios=" + reprobatorio +
				"&e_graves=" + grave + "&e_leves=" + leve;
		WWW actualizar = new WWW (url);
		yield return actualizar;

		if (actualizar.error != null) 
		{
			print ("Error: " + actualizar.error);
		} 
		else
		{
			Application.LoadLevel ("Menu_Principal"); 
		}
	}
	
	public override void OnVRGUI()
	{
		GUI.color = Color.white;
		if (Application.loadedLevelName == "Simulacion_Reprobatoria") 
		{
			GUI.Label (new Rect (Screen.width * 0.4f, Screen.height * 0.4f, 125, 30), "Veces Fuera: " + reprobatorio, tamañoletra);
		}
		if (Application.loadedLevelName == "Simulacion_Mixta") 
		{
			GUI.Label (new Rect (Screen.width * 0.35f, Screen.height * 0.4f, 125, 30), "Veces Fuera: " + reprobatorio, tamañoletra);
			GUI.Label (new Rect (Screen.width * 0.35f, Screen.height * 0.5f, 125, 30), "Bocinas sin motivo: " + leve, tamañoletra);

		}
		if (Application.loadedLevelName == "Simulacion_Leve") 
		{
			GUI.Label (new Rect (Screen.width * 0.35f, Screen.height * 0.4f, 125, 30), "Bocinas sin motivo: " + leve, tamañoletra);
		}
	}
}