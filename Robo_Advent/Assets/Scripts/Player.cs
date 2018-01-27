using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats playerStats { get; private set; }

	void OnEnabled(){
		playerStats = PlayerPersistence.LoadData ();
	}

	// Use this for initialization
	private void Start ()
    {
		int 
	}
	
	// Update is called once per frame
	private void Update ()
    {
		
	}
}
