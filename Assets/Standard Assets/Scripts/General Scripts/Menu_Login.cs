using UnityEngine;
using System.Collections;

public class Menu_Login : VRGUI {

	string url = "http://190.160.26.167/SimVR/login.php";

	string rut = "";
	string password = "";
	string label = "";

	public override void OnVRGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width*0.4f,Screen.height*0.4f,Screen.width * 0.2f,Screen.height));
		{
			GUILayout.BeginVertical(); 
			{
				GUILayout.Label ("Ingrese su RUT");
				rut = GUILayout.TextField (rut);

				GUILayout.Label ("Ingrese su Contraseña");
				password = GUILayout.TextField (password);

				if (GUILayout.Button ("Ingresar")) {
						StartCoroutine (HandleLogin (rut,password));
				}

				GUILayout.Label (label);
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}

	IEnumerator HandleLogin(string rut, string password)
	{
		label = "Buscando en la base de datos";
		string url = this.url + "?rut=" + rut + "&password=" + password;
		WWW loginReader = new WWW (url);
		yield return loginReader;

		if (loginReader.error != null) 
		{
			label = "Error al conectar a la base de datos";
		}
		else 
		{
			if(loginReader.text=="Encontrado")
			{
				PlayerPrefs.SetString("Rut",rut);
				PlayerPrefs.Save();
				Application.LoadLevel ("Menu_Principal"); 
			}
			else
			{
				label = "Rut no encontrado.";
			}
		}

	}
}
