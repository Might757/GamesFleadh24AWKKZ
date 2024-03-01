    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject nearestNpc;
    [SerializeField] private GameObject[] allNpcs;
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject unsuccess;
    [SerializeField] private GameObject blackBg;

    private NPCInteractable npc;
    [SerializeField ]private ScoreScript scoreObj;
    private CountdownTimer countTime;

    float distance;
    float nearestDistance = 10000;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        allNpcs = GameObject.FindGameObjectsWithTag("Person");

        for (int i = 0; i < allNpcs.Length; i++)
        {
            distance = Vector3.Distance(player.transform.position, allNpcs[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestNpc = allNpcs[i];
                nearestDistance = distance;
            }
            npc = nearestNpc.GetComponent<NPCInteractable>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreObj.ScoreNum == 6 && countTime.currentTime > 0f && npc.minigameOn)
        {
            blackBg.SetActive(true);
            success.SetActive(true);
            npc.isInfected = true;
            infectedSO.ScoreMultiplier += 0.1f;
            infectedSO.Score = infectedSO.Score + (1 * infectedSO.ScoreMultiplier);
            player.SetActive(true);
        }
        else
        {
            unsuccess.SetActive(true);
            npc.isInfected = false;
            infectedSO.ScoreMultiplier = 1f; // reset infect multiplier
            player.SetActive(true);
        }
        npc.minigameOn = false;
    }
}
