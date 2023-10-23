using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    public SpriteRenderer planetImage;
    [SerializeField] List<Sprite> planets;

    void Start()
    {
        //planetImage.size = transform.localScale;
        changeSpriteAndScale();
    }

    void changeSpriteAndScale()
    {
        var randomScale = Random.Range(1f, 2f);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        planetImage.sprite = planets[Random.Range(0, planets.Count)];
    }

}
