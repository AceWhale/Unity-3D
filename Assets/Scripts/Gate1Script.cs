using UnityEngine;

public class Gate1Script : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private string author;
    private AudioSource closedSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Character")
        {
            MessageScript.ShowMessage($"Необхідний ключ №{key}. Продовжуйте пошуки!", author);
            closedSound.volume = GameState.effectsVolume;
            closedSound.Play();
        }
    }

    void Start()
    {
        closedSound = GetComponent<AudioSource>();
    }
}
