using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<PressurePlate> pressurePlates;
    public int openDir; // 0 - up/down, 1 - left/right (really left/right could be anything that's not 0)
    public float openDist; // 
    public float lTime;
    public int box_count;
    private Vector3 closedPos;
    private Vector3 openPos;
    private AudioSource door_audio;
    private WaitForSeconds openDuration = new WaitForSeconds(.07f);
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        door_audio = GetComponent<AudioSource>();

        closedPos = transform.position;
        if (openDir == 0)
        {
            

            // the door will open up or down depending on whether openDist is negative or positive
            openPos = new Vector3(closedPos.x, closedPos.y + openDist, closedPos.z);
        }
        else
        {
            //StartCoroutine(SoundEffect());

            // the door will open left or right depending on whether openDist is negative or positive
            openPos = new Vector3(closedPos.x + openDist, closedPos.y, closedPos.z);
        }
        //print("closePos: " + closedPos);
        //print("openPos: " + openPos);
    }

    // Update is called once per frame
    void Update()
    {
        int pressurePlatesActivated = 0;
        foreach (PressurePlate p in pressurePlates)
        {
            // iterate through all pressure plates linked to door
            if (p.triggered == true)
            {
                pressurePlatesActivated++;
                
            }
        }
        float openPct = pressurePlatesActivated / pressurePlates.Count;
        //print("pct " + openPct);
        transform.position = Vector3.Lerp(closedPos, openPos, openPct); // fraction of how much the door should be open

    }

    public void Open()
    {
        box_count -= 1;
        if (box_count <= 0)
        {
            Debug.Log("Tried to Open");
            //door_audio.Play();
            StartCoroutine(SoundEffect());
            gameObject.SetActive(false);
            platform.SetActive(true);
            //closedPos = transform.position;
            //openPos = new Vector3(closedPos.x, closedPos.y + 1000, closedPos.z);
        }
    }

    private IEnumerator SoundEffect()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            Debug.Log("Audio Source detected on door... should be playing?");
            door_audio.Play();
        }
            
        yield return openDuration;
    }
}