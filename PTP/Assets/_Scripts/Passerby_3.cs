using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerby_3 : Passerby_2
{
    [SerializeField] private Renderer rend;
    private Color color;
    private bool canChangeColor;

    protected override void Start()
    {
        color = rend.material.color;

        base.Start();
    }

    protected override void Update()
    {
        ChangeColor();

        base.Update();
    }

    private void ChangeColor()
    {
        if (!canChangeColor && !applyGravityScript.isGrounded)
        {
            canChangeColor = true;
        }
        else if (canChangeColor && applyGravityScript.isGrounded)
        {
            float h = Random.Range(0f, 1f);
            color = Color.HSVToRGB(h, 1f, 0.8f);
            rend.material.color = color;
            canChangeColor = false;
        }
    }
}
