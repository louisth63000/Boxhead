using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDemon : MonoBehaviour
{
    public float vie=2f;
	public int degat=5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,vie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
