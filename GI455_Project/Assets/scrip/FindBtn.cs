using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindBtn : MonoBehaviour
{
    public InputField _boxText;
    public Text _text;
    public Text test;
    public string _textWord;
    public Color _color;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FindWord()
    {
        // _text.text= _boxText.text;
        //var _textWord = _boxText.text;
        // Debug.Log(_text);
        _textWord = _boxText.text;
        
        
        Debug.Log(_textWord);
        if (_boxText.text == "Unity" || _boxText.text == "Unreal"|| _boxText.text == "Google"|| _boxText.text == "ResidentEvil" || _boxText.text == "MongoDB")
        {
             _text.color= Color.green;
            _text.text = "[ " + _textWord + " ] is found";
        }
        else 
        {
            _text.color = Color.red;
            _text.text = "[ " + _textWord + " ] is not found";
        }



    }
}
