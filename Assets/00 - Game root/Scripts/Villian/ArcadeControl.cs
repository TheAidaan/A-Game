using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeControl : MonoBehaviour
{
    [SerializeField] GameObject[] Corners = new GameObject[4]; //0: BRight , 1: TRight ,2: Tleft ,3: BLeft


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Corners[0].GetComponent<Animator>().SetBool("Rise", true);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Corners[0].GetComponent<Animator>().SetBool("Rise", false);
        }
    }
}
