using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("FadeManager").
            GetComponentInChildren<Fade>().ChangeFade(FadeType.FadeOut);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
