using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;
        if (!text) { return; }
        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {

            float inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0f)
            {

                ScriptPlayable<SubtitleBehaviour> inputP1ayab1e = (ScriptPlayable<SubtitleBehaviour>)playable.GetInput(i);
                SubtitleBehaviour input = inputP1ayab1e.GetBehaviour();
                currentText = input.subtitleText;
                currentAlpha = inputWeight;
            }
        }

        text.text = currentText;
        Color myColor = text.color;

        float red = myColor.r;
        float green = myColor.g;
        float blue = myColor.b;


        text.color = new Color(red, green, blue, currentAlpha);
    }
}
