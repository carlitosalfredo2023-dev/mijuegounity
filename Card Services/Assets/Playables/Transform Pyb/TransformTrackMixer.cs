using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Windows;

public class TransformTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Transform transform = playerData as Transform;
        float advance = 0f;

        Vector3 destinationP = transform.position;
        Vector3 destinationR = transform.rotation.eulerAngles;
        Vector3 destinationS = transform.localScale;
        Vector3 startP = transform.position;
        Vector3 startR = transform.position;
        Vector3 startS = transform.position;

        bool p = false, r = false, s = false;

        if (!transform) { return; }
        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {

            if (i == 0)
            {
                float inputWeight = playable.GetInputWeight(0);
                if (inputWeight > 0f)
                {

                    ScriptPlayable<TransfromBehaviour> inputP1ayab1e = (ScriptPlayable<TransfromBehaviour>)playable.GetInput(0);
                    TransfromBehaviour input = inputP1ayab1e.GetBehaviour();

                    p = input.p; r = input.r; s = input.s;

                    if (p)
                    {
                        startP = input.positionStart;
                        destinationP = input.positionEnd;
                    }
                    if (r)
                    {
                        startR = input.rotationStart;
                        destinationR = input.rotationEnd;
                    }
                    if (s)
                    {
                        startS = input.scaleStart;
                        destinationS = input.scaleEnd;
                    }

                    advance = inputWeight;
                }
            }
            else if (i > 0)
            {
                float inputWeight = playable.GetInputWeight(i - 1);
                float inputWeight2 = playable.GetInputWeight(i);
                if (inputWeight2 > 0f)
                {

                    ScriptPlayable<TransfromBehaviour> inputP1ayab1e = (ScriptPlayable<TransfromBehaviour>)playable.GetInput(i - 1);
                    ScriptPlayable<TransfromBehaviour> inputP1ayab1e2 = (ScriptPlayable<TransfromBehaviour>)playable.GetInput(i);

                    TransfromBehaviour input = inputP1ayab1e.GetBehaviour();
                    TransfromBehaviour input2 = inputP1ayab1e2.GetBehaviour();


                    if (inputWeight > 0f)
                    {
                        startP = input.positionEnd;
                        startR = input.rotationEnd;
                        startS = input.scaleEnd;
                    }
                    else
                    {
                        startP = input.positionStart;
                        startR = input.rotationStart;
                        startS = input.scaleStart;
                    }

                    input2.positionStart = startP;
                    input2.rotationStart = startR;
                    input2.scaleStart = startS;
                    destinationP = input2.positionEnd;
                    destinationR = input2.rotationEnd;
                    destinationS = input2.scaleEnd;

                    //advance = inputWeight;
                    advance = inputWeight2;

                }
            }

        }

        if(p)transform.position = Vector3.Lerp(startP, destinationP, advance);
        if(r)transform.rotation = Quaternion.Euler(Vector3.Lerp(startR, destinationR, advance));
        if(s)transform.localScale = Vector3.Lerp(startS, destinationS, advance);
    }
}
