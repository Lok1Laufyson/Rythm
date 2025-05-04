using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [Header("Audio & Timing")]
    public AudioSource musicSource;
    public float bpm = 120f;

    [Header("Awwor Setup")]
    public GameObject arrowPrefab;
    public Transform[] spawnPoints;

    public Transform noteHolder;

    private double nextBeatTime;
    private double beatInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatInterval = 60.0 / bpm;
        nextBeatTime = AudioSettings.dspTime + beatInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance == null || !GameManager.instance.startPlaying)
            return;
        if (GameManager.instance.IsGameEnded())
            return;

        double dspTime = AudioSettings.dspTime;

        if (dspTime >= nextBeatTime)
        {
            SpawnArrow();
            nextBeatTime += beatInterval;
        }
    }

    void SpawnArrow()
    {
        int laneIndex = Random.Range(0, spawnPoints.Length);
        Transform lane = spawnPoints[laneIndex];

        GameObject arrow = Instantiate(arrowPrefab,lane.position, lane.rotation, noteHolder);

        Arrow arrowScript = arrow.GetComponent<Arrow>();

        switch (laneIndex)
        {
            case 0: // Left
                arrowScript.arrowKey = KeyCode.LeftArrow;
                break;
            case 1: // Up
                arrowScript.arrowKey = KeyCode.UpArrow;
                break;
            case 2: // Down
                arrowScript.arrowKey = KeyCode.DownArrow;
                break;
            case 3: // Right
                arrowScript.arrowKey = KeyCode.RightArrow;
                break;
        }
    }

}
