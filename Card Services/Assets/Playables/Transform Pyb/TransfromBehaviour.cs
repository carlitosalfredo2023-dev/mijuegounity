using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TransfromBehaviour : PlayableBehaviour
{
    public Vector3 positionEnd;
    public Vector3 positionStart = Vector3.zero;

    public Vector3 rotationEnd;
    public Vector3 rotationStart = Vector3.zero;
    
    public Vector3 scaleEnd;
    public Vector3 scaleStart = Vector3.zero;

    public bool p, r, s;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Transform transform = playerData as Transform;

        if(positionStart == Vector3.zero) positionStart = transform.position;

        
        if(p) transform.position = Vector3.Lerp(positionStart, positionEnd, info.weight);
        if(r) transform.rotation = Quaternion.Euler( Vector3.Lerp(rotationStart, rotationEnd, info.weight));
        if(s) transform.localScale = Vector3.Lerp(scaleStart, scaleEnd, info.weight);

        
    }

}
