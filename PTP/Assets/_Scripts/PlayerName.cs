using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    public TextMeshPro playerNameText;

    private void Start()
    {
        if(GameManager.S != null) playerNameText.text = GameManager.S.playerName;
    }
}
