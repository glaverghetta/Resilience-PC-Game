using UnityEngine;

/* This class handles the completion of levels. */
public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject completeLevelUI;              // UI that displays after completing a level
    public AudioSource source;                      // Sound effect played after completing a level
    
    void OnTriggerEnter()
    {
        source.Play();
        completeLevelUI.SetActive(true);
    }

}
