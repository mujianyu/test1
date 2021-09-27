using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class DialogueClip : PlayableAsset
{
    public DialogueBehavior temp = new DialogueBehavior();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {


        var playable = ScriptPlayable<DialogueBehavior>.Create(graph,temp);
        return playable;
    }
}
