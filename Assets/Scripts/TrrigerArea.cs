using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TrrigerArea : MonoBehaviour
{

    public PlayableDirector playableDirector;
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            playableDirector.Play();
            GameManager.instance.gameMode = GameManager.GameMode.GamePlay;
        }
    }
}
