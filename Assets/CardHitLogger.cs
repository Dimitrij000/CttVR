using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CardHitLogger : MonoBehaviour
{
    private XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    void OnEnable()
    {
        interactable.hoverEntered.AddListener(OnHoverEntered);
    }

    void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEntered);
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Check if it's the right hand controller
        if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            Debug.Log("Hit card: " + gameObject.name);
            Logger.Instance.Add(gameObject.name);
        }
    }
}
