using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ImageBehaviour : PlayableBehaviour
{
    public Sprite image;
    public Color color = Color.white;
    public bool alphaOnly = true;
    public bool ignoreSprite = false;


    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Image img = playerData as Image;

        if (img == null) return;

        if(!ignoreSprite)img.sprite = image;
        Color myColor = img.color;
        float red = color.r;
        float green = color.g;
        float blue = color.b;

        if (alphaOnly)
        {
             red = myColor.r;
             green = myColor.g;
             blue = myColor.b;
        }


        img.color = new Color(red, green, blue, info.weight);

    }
}
