using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float Range = 2.0f;
    public Color ChangeColour = Color.green;

    private Color StartingColour;
    public float Distance;
    private Material Mat;
    private Transform Player;

	// Use this for initialization
	void Start ()
    {
        Mat = GetComponent<MeshRenderer>().material;
        StartingColour = Mat.color;
        Player = FindObjectOfType<PlayerScript>().transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Distance = Vector3.Distance(transform.position, Player.position) / 8;

        if (Distance <= Range)
        {
            
            Mat.color = Color.Lerp(ChangeColour, StartingColour, Distance);
        }
	}
}
