using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public InputField inputField;
    public GameObject console;

    public string command;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
          toggleConsole();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
            {
                command = inputField.text;
                inputField.text = "";
            }
        void toggleConsole()
        {
            bool currentstate = console.activeSelf;
            console.SetActive(!currentstate);
        }



        switch (command)
        {
            case "LoadLevel_2":
                SceneManager.LoadScene("Scene2");
                break;
        }
    }
}
