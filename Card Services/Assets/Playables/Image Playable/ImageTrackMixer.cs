using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ImageTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Image img = playerData as Image;

        if (!img) { return; }
        int inputCount = playable.GetInputCount();

        float currentAlpha = 0f;
        bool onlyAlpha = true;
        bool ignoreSprite = false;
        Color imgColor = Color.white;
        float red, green, blue, alpha;


        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0f)
            {
                ScriptPlayable<ImageBehaviour> inputP1ayab1e = (ScriptPlayable<ImageBehaviour>)playable.GetInput(i);
                ImageBehaviour input = inputP1ayab1e.GetBehaviour();
                ignoreSprite = input.ignoreSprite;
                if(!ignoreSprite)img.sprite = input.image;
                currentAlpha = inputWeight;
                onlyAlpha = input.alphaOnly;
                imgColor = input.color;
            }
        }

        if (onlyAlpha)
        {
            red = img.color.r;
            green = img.color.g;
            blue = img.color.b;
            alpha = img.color.a;

        }
        else
        {
            red = imgColor.r;
            green = imgColor.g;
            blue = imgColor.b;
            alpha = imgColor.a;
        }


        img.color = new Color(red, green, blue, currentAlpha);
    }
}
