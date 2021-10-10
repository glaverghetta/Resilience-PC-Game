using UnityEngine;

public class JumpText : MonoBehaviour
{
    public GameObject jumpText;

    public void OnTriggerEnter()
    {
        jumpText.gameObject.SetActive(true);
    }
}
