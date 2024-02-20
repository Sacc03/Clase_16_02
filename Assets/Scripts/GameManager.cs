using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DataJSON misDatos;
    public InputField textoJugador;
    public Text textoPlayer;
    public Text textoTitulo;
    public GameObject PanelUI;
    // Start is called before the first frame update
    void Start()
    {
        string filePat = Application.streamingAssetsPath + "/" + "data1.json";

        if (File.Exists(filePat))
        {
            string s = File.ReadAllText(filePat);
            misDatos = JsonUtility.FromJson<DataJSON>(s);
            Debug.Log(s);
            Debug.Log(misDatos);
            Debug.Log(misDatos.nombre_juego);
            Debug.Log(misDatos.nombre_jugador);
            s = JsonUtility.ToJson(misDatos, true);
            Debug.Log(s);
            File.WriteAllText(filePat, s);
        }
        cargaDatos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PanelUI.SetActive(true);
        }
    }

    void cargaDatos()
    {
        //GameObject.Find("t_titulo").GetComponent<Text>().text=misDatos.nombre_juego;
        //GameObject.Find("nombre").GetComponent<Text>().text=misDatos.nombre_jugador;
        textoTitulo.text= misDatos.nombre_juego;
        textoPlayer.text=misDatos.nombre_jugador;
    }

    public void guardarDatos()
    {
        misDatos.nombre_jugador = textoJugador.text;
        string filePat= Application.streamingAssetsPath+ "/" + "data1.json";
        string s = JsonUtility.ToJson(misDatos, true);
        File.WriteAllText(filePat, s);
    }
}
