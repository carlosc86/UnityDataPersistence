using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private TMP_InputField newPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText("Best Score: "+PlayerManager.Instance.GetBestPlayer()+" "+PlayerManager.Instance.GetBestScore());
        playerText.SetText("Player: "+PlayerManager.Instance.playerName); 
    }

    public void StartNew(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void ChangePlayer(){
        PlayerManager.Instance.playerName=newPlayerName.text;
        playerText.SetText("Player: "+PlayerManager.Instance.playerName);
    }
}
