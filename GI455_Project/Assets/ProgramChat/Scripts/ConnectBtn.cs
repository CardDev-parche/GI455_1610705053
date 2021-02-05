using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectBtn : MonoBehaviour
{
    public InputField IPAddress;
    public InputField PortField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ConnectToChat()
    {
        if (IPAddress.text == "127.0.0.1" && PortField.text == "5500") 
        {
            SceneManager.LoadScene("ProgramChat");
        }
        
    }
}
