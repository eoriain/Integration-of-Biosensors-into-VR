using UnityEngine;

public class UIMenu2 : MonoBehaviour
{
    public GameObject UI;
    public GameObject UIAnchor;
    private bool UIActive;

    void Start()
    {
        UI.SetActive(false);
        UIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            UIActive = !UIActive;
            UI.SetActive(UIActive);
        }

        if (UIActive)
        {
            UI.transform.position = UIAnchor.transform.position;
            UI.transform.eulerAngles = new Vector3(UIAnchor.transform.eulerAngles.x, UIAnchor.transform.eulerAngles.y, 0);
        }
    }
}
