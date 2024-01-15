using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class DestroyablesManager : MonoBehaviour
{
    private void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Destroyable>().GetRank() <= GameManager.GetRank())
            {
                child.GetComponent<Outline>().color = 1;
            }
        }
    }
}
