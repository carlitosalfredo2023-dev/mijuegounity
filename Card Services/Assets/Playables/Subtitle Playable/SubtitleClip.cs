using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    [TextArea]
    public string subtitleText;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);

        SubtitleBehaviour subtit1eBehaviour = playable.GetBehaviour();
        subtit1eBehaviour.subtitleText = subtitleText;

        return playable;
    }
}
