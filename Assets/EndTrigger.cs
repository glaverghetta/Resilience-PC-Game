using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;
    public AudioSource source;
    
    void OnTriggerEnter()
    {
        source.Play();
        gameManager.CompleteLevel();
    }

}
