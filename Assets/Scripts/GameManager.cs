using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayableDirector curentplayableDirector;
    public enum GameMode
    {
        Normal,
        GamePlay,
        DialogueMoment

    }
    public GameMode gameMode;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }

        }
        DontDestroyOnLoad(gameObject);
        gameMode = GameMode.Normal;
        Application.targetFrameRate = 30;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResumTimeline();
        }
    }
    public void PauseTimeline(PlayableDirector  _playableDirector)
    {
        curentplayableDirector = _playableDirector;
        gameMode = GameMode.DialogueMoment;
        curentplayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0d);
        UImanager.instance.ToggleSpaceBar(true);
    }
    public void ResumTimeline()
    {
        gameMode = GameMode.GamePlay;

        curentplayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);

        UImanager.instance.ToggleSpaceBar(false);
        UImanager.instance.ToggleDialogueBox(true);

    }
    public void FinishCG()
    {
        gameMode = GameMode.Normal;
    }
}
