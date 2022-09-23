using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string playerName;
    private string playerNameMaxScore;
    private int maxScore;

    private void Awake(){
        if(Instance!=null){
            Destroy(gameObject);
            return;
        }
        Instance=this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetBestPlayer(){
        return playerNameMaxScore;
    }
    public int GetBestScore(){
        return maxScore;
    }

    public void ChargeScore(int score){
        if(score>maxScore){
            maxScore=score;
            playerNameMaxScore=playerName;
        }
    }
}
