using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleBehaviour : PlayableBehaviour
{
    public string subtitleText;


    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = subtitleText;
        Color myColor = text.color;

        float red = myColor.r;
        float green = myColor.g;
        float blue = myColor.b;


        text.color = new Color(red, green, blue, info.weight);

    }
}
