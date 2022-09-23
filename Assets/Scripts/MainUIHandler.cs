using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text playerText;
    [SerializeField] private Text maxScoreText;

    void Start(){
        maxScoreText.text=("Best Score: "+PlayerManager.Instance.GetBestPlayer()+" "+PlayerManager.Instance.GetBestScore());
        playerText.text=("Player: "+PlayerManager.Instance.playerName);
    }
    public void ReturnMenu(){
        SceneManager.LoadScene(0);
    }

}
