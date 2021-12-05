using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVisuals : MonoBehaviour
{
    [SerializeField] GameObject[] damageSplatter;
    [SerializeField] float splatterDisplayTime = 1f;
    [SerializeField] int splatterRow;

    private void Start()
    {
        ClearSplatters();
        splatterRow = 0;
    }

    void ClearSplatters()
    {
        foreach (GameObject damageSplatter in damageSplatter)
        { damageSplatter.SetActive(false); }
    }

    public void ActivateRandomSplatter()
    {
        ClearSplatters();
        splatterRow++;
        int i = Random.Range(0, gameObject.transform.childCount);
        //damageSplatter[i].SetActive(true);
        StartCoroutine(ShowSplatter(i, splatterRow));
    }

    IEnumerator ShowSplatter(int splatterNumber, int currentSplatter)
    {
        damageSplatter[splatterNumber].SetActive(true);
        yield return new WaitForSeconds(splatterDisplayTime);
        if (splatterRow == currentSplatter)
        {
            damageSplatter[splatterNumber].SetActive(false);
            splatterRow = 0;
        }

    }
}