using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class LevelManager : MonoBehaviour
{
    private Text _text;


    public void Display(int value)
    {
        _text.text = $"Вы набрали {value}";
    }







}
