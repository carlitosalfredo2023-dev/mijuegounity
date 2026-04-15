using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TransformClip : PlayableAsset
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public bool posEnable = true;
    public bool rotEnable = false;
    public bool scaEnable = false;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TransfromBehaviour>.Create(graph);

        TransfromBehaviour transfromBehaviour = playable.GetBehaviour();

        
        transfromBehaviour.positionEnd = position;
        transfromBehaviour.rotationEnd = rotation;
        transfromBehaviour.scaleEnd = scale;
        transfromBehaviour.p = posEnable;
        transfromBehaviour.r = rotEnable;
        transfromBehaviour.s = scaEnable;
        

        return playable;

    }

}
