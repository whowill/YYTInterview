using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeData : MonoBehaviour
{
    [SerializeField] Image planetImage;

    public void setData(Sprite image)
    {
        planetImage.sprite = image;
    }
}
