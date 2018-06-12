using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerHealthPanel : MonoBehaviour
{
    [SerializeField] Text _text = null;

    private Player _player = null;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }


    public void LateUpdate()
    {
        _text.text = _player.GetHealth().ToString();
    }
}


