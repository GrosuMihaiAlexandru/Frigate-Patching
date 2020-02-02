using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    private SpriteRenderer thisrenderer;

    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Awake()
    {
        thisrenderer = GetComponent<SpriteRenderer>();
        Random.InitState(System.DateTime.Now.Millisecond);
        int selectedIsland = Random.Range(0, sprites.Count);
        thisrenderer.sprite = sprites[selectedIsland];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
