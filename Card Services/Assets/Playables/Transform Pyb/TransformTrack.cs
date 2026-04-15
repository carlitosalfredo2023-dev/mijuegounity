using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackBindingType(typeof(Transform))]
[TrackColor(1,0,0)]
[TrackClipType(typeof(TransformClip))]
public class TransformTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        TransformTrackMixer mixer = new TransformTrackMixer();
        return ScriptPlayable<TransformTrackMixer>.Create(graph,inputCount);
    }
}
