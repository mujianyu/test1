using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
[System.Serializable]
public class DialogueBehavior : PlayableBehaviour
{
    private PlayableDirector playableDirector;
    public string characterName;
    [TextArea(8, 1)] public string dialogueLine;
    public int dialoguesize;

    private bool isClipPlayed;//CLIP是否已经播放
    public bool requirePause;//是否需要按下空格
    private bool pauseScheduled;

    public override void OnPlayableCreate(Playable playable)
    {
        playableDirector = playable.GetGraph().GetResolver() as PlayableDirector;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if(isClipPlayed==false&&info.weight>0)
        {
            UImanager.instance.SetUpDialogue(characterName, dialogueLine, dialoguesize);
            if (requirePause )
                pauseScheduled = true;
            isClipPlayed = true;
        }
    }
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        isClipPlayed = false;
      if(pauseScheduled)
        {
            pauseScheduled = false;
            GameManager.instance.PauseTimeline(playableDirector);

        }
      else
        {
            UImanager.instance.ToggleDialogueBox(false);
        }
    }

}
