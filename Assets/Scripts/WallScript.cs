using UnityEngine;

public class WallScript : MonoBehaviour
{
    private AudioSource hitSound;
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Character")
            hitSound.Play();
    }
}
