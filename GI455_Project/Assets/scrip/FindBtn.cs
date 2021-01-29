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
        if (_boxText.text == "Dota2" || _boxText.text == "ROV"|| _boxText.text == "LOL"|| _boxText.text == "ResidentEvil" || _boxText.text == "Ragnarok")
        {
             //_text.color= Color.green;
            _text.text = "[ <color=green>" + _textWord + "</color> ] is found";
        }
        else 
        {
            //_text.color = Color.red;
            _text.text = "[ <color=red>" + _textWord + "</color> ] is not found";
        }



    }
}
