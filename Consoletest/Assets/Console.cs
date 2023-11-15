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
        //Input to open console.
        //Eingabe um Konsole zu öffnen.
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
          toggleConsole();
        }
        void toggleConsole()
        {
            bool currentstate = console.activeSelf;
            console.SetActive(!currentstate);
        }
        
        //Input to send command.
        //Eingabe um Befehl zu senden.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            command = inputField.text;
            inputField.text = "";
        }
        
        //Example use case: Loading a level via Command.
        //Beischpiel für die Verwendung von laden eines Levels über Befehl.
        switch (command)
        {
            //Command Name: LoadLevel_1
            case "LoadLevel_1":
                SceneManager.LoadScene("test");
                break;
            //Command Name: LoadLevel_2
            case "LoadLevel_2":
                SceneManager.LoadScene("Scene2");
                break;
            //Command Name: LoadLevel_3
            case "LoadLevel_3":
                SceneManager.LoadScene("Scene3");
                break;
        }
    }
}
