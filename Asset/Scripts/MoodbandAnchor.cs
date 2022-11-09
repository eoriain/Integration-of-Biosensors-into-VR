using UnityEngine;

public class MoodbandAnchor : MonoBehaviour
{
    public GameObject UI;
    public GameObject UIAnchor;
    private bool UIActive;

    void Start()
    {
        UI.SetActive(true);
        UIActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        UI.transform.position = UIAnchor.transform.position;
        UI.transform.eulerAngles = new Vector3(UIAnchor.transform.eulerAngles.x, UIAnchor.transform.eulerAngles.y, UIAnchor.transform.eulerAngles.z);
    }
}
