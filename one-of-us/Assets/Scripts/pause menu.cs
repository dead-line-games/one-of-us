using UnityEngine;
using System.Collections;

public class pausemenu : MonoBehaviour {
    bool pause = false;
    string chapter;
    string main;
    GameObject pauseMenuCanvas;
	// Use this for initialization
	void Start () {
        bool pause = false;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = togglePause();
        }
        if (pause)
        {
            pauseMenuCanvas.SetActive(true);
        }else
        {
            pauseMenuCanvas.SetActive(false);
        }
	}

    void OnGUI()
    {
        if (pause)
        {
            GUILayout.Label("Menu");
            if (GUILayout.Button("resume"))
            {
                pause = togglePause();
            }
        }
    }
    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
