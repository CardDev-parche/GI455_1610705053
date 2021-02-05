using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;


namespace ProgramChat
{
    
    public class WebsocketConnection : MonoBehaviour
    {
        public InputField IPAddress;
        public InputField PortField;
        public InputField TextMessage;
        private WebSocket websocket;

        public int MaxMessage = 25;
        public GameObject ChatPanel;
        public GameObject TextObject;
        public GameObject Login;
        public GameObject Chat;


        List<Message> messageList = new List<Message>();
        // Start is called before the first frame update
        void Start()
        {
           // websocket = new WebSocket("ws://127.0.0.1:5500/");

            //websocket.OnMessage += OnMessage;

           // websocket.Connect();

            //websocket.Send("I'am coming here.");
        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (TextMessage.text != "")
                {
                    if (websocket.ReadyState == WebSocketState.Open)
                    {
                        websocket.Send("me : " + TextMessage.text);

                    }


                    TextMessage.text = "";
                }
                /*if (Input.GetKeyDown( KeyCode.Return)) 
                {
                    SendMessageToChat(TextMessage.text);
                    TextMessage.text = "";
                } */
            }
           /* if (Input.GetKeyDown(KeyCode.Return)) 
            {
                if (websocket.ReadyState == WebSocketState.Open)
                {
                    websocket.Send("Random nummer : " + Random.Range(0,999999));
                }
            }*/

        }
        public void ConnectToChat()
        {
            if (IPAddress.text == "127.0.0.1" && PortField.text == "5500")
            {
                Login.SetActive(false);
                Chat.SetActive(true);
                websocket = new WebSocket("ws://127.0.0.1:5500/");

                websocket.OnMessage += OnMessage;

                websocket.Connect();
            }
            

        }
        public void SendMessage() 
        {
            if (TextMessage.text != "")
            {
                
             
                    if (websocket.ReadyState == WebSocketState.Open)
                    {
                        websocket.Send(TextMessage.text);

                       // websocket.OnMessage += OnMessage;
                    }
                //SendMessageToChat(TextMessage.text);

                TextMessage.text = "";
            }
               /* if (websocket.ReadyState == WebSocketState.Open)
            {
                websocket.Send(TextMessage.text);
            }*/

        }

        private void OnDestroy()
        {
            if (websocket != null) 
            {
                websocket.Close();
            }
        }

        public void OnMessage(object sender,MessageEventArgs messageEventArgs) 
        {
            Debug.Log("Recive msg : " + messageEventArgs.Data);
            Debug.Log("Recive msgssss : " + messageEventArgs.Data);
            GameObject newText = Instantiate(TextObject, ChatPanel.transform) as GameObject;
            
            newText.GetComponentInChildren<Text>().text = messageEventArgs.Data;
           
            
            //Message newMessage2 = new Message();
            //newMessage2.text = messageEventArgs.Data;
            //Debug.Log(newMessage2.text);
            //SendMessageToChat("[1] "+messageEventArgs.Data);


        }

        public void SendMessageToChat(string message)
        {
            if (messageList.Count>=MaxMessage)
            {
                Destroy(messageList[0].TextObject.gameObject);
                messageList.Remove(messageList[0]);
            }
            //Message newMessage = new Message();
           // newMessage.text = message;
            Debug.Log("sendtochat " + message);
            GameObject newText =Instantiate(TextObject,ChatPanel.transform) as GameObject;
            newText.GetComponentInChildren<Text>().text= message;
           // newMessage.TextObject = newText.GetComponent<Text>();
           // newMessage.TextObject.text = message;
            

           // messageList.Add(newMessage);
            
            
        }

        public class Message
        {
            public string text;
            public Text TextObject;
        }


    }
}

