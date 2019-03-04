using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    public string currentChallenge;

    public List<string> challengeList = new List<string>();
    public GameObject uiString;

    void Start()
    {
        RamdomChallenge();
    }

    public void RamdomChallenge()
    {
        var temp = Random.Range(0, challengeList.Count);
        currentChallenge = challengeList[temp];
        uiString.GetComponent<Text>().text = currentChallenge;
    }

}
