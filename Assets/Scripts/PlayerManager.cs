using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string playerName;
    private string playerNameMaxScore="";
    private int maxScore=0;

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
            SavePlayer();
        }
    }

    [System.Serializable]
    class PlayerData{
        public string playerName;
        public string bestPlayerName;
        public int bestPlayerScore;
    }

    public void SavePlayer(){
        PlayerData data=new PlayerData();
        data.playerName=playerName;
        data.bestPlayerName=playerNameMaxScore;
        data.bestPlayerScore=maxScore;
        string json=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath+"/player.json",json);
    }

    public void LoadPlayer(){
        if(File.Exists(Application.persistentDataPath+"/player.json")){
            string json=File.ReadAllText(Application.persistentDataPath+"/player.json");
            PlayerData data=JsonUtility.FromJson<PlayerData>(json);
            playerName=data.playerName;
            playerNameMaxScore=data.bestPlayerName;
            maxScore=data.bestPlayerScore;
        }
    }
}
