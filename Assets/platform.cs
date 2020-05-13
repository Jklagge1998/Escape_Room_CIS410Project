using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public int box_count;
    private Vector3 hiddenPos;
    private Vector3 openPos;

    // Start is called before the first frame update
    void Start()
    {
        hiddenPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show()
    {
        box_count -= 1;
        if (box_count <= 0)
        {
            Debug.Log("Platform position is " + hiddenPos);
            //gameObject.SetActive(true);
            transform.position = new Vector3(hiddenPos.x, hiddenPos.y + 10f, hiddenPos.z);
        }
    }
}
