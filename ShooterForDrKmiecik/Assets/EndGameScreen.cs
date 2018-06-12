using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Text _text = null;

    public void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Display(string text)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        _text.text = text;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
