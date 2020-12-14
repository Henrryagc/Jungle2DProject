using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    private Transform transformBar;

    void Start()
    {
        transformBar = transform.Find("Barra");
    }

    public void SetScaleSize(float sizeNormalized)
    {
        transformBar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
