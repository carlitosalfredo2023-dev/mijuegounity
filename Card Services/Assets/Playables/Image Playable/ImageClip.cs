using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ImageClip : PlayableAsset
{
    public Sprite image;
    public Color color = Color.white;
    public bool alphaOnly = true;
    public bool ignoreSprite = false;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<ImageBehaviour>.Create(graph);

        ImageBehaviour imageBehaviour = playable.GetBehaviour();
        if(!ignoreSprite)imageBehaviour.image = image;
        imageBehaviour.color = color;
        imageBehaviour.alphaOnly = alphaOnly;
        imageBehaviour.ignoreSprite = ignoreSprite;

        return playable;
    }
}
