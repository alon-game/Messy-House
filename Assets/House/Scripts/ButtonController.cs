using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject information;
    // Start is called before the first frame update
    void Start()
    {
        information.SetActive(false);
    }

    public void ButtonClick()
    {
        if (!information.activeSelf)
        {
            information.SetActive(true);
        }
        else
        {
            information.SetActive(false);
        }
    }

}
