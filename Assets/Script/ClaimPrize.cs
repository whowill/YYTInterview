using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClaimPrize : MonoBehaviour
{
    [SerializeField] List<GameObject> prize;
    [SerializeField] List<GameObject> prizeUI;
    [SerializeField] Generator generator;

    [Header("UI Prize")]
    [SerializeField] GameObject PrizePanel;
    [SerializeField] RectTransform contentPrize;
    [SerializeField] GameObject prizePrefab;

    private void Start()
    {
        prize = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        generator.totalSpawan -= 1;
        prize.Add(collision.gameObject);
        collision.gameObject.SetActive(false);
    }


    public void showPanelPrize()
    {
        PrizePanel.SetActive(true);
        foreach (var prz in prize)
        {
                prizePrefab.GetComponent<PrizeData>().setData(prz.GetComponent<Prize>().planetImage.sprite);
                GameObject przObj = Instantiate(prizePrefab, Vector3.zero, Quaternion.identity);
                przObj.transform.SetParent(contentPrize, false);
                prizeUI.Add(przObj);
        }
    }

    public void clearChildContent()
    {
        foreach (var objectGame in prizeUI)
        {
            Destroy(objectGame.gameObject);
        }
        foreach (var planetObject in prize)
        {
            Destroy(planetObject.gameObject);
        }
        prize.Clear();
    }
}
