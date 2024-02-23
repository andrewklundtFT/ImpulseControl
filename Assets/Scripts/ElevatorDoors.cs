using UnityEngine;

public class ElevatorDoors : MonoBehaviour
{
    public GameObject player;
    public Vector3 start;
    public Vector3 center;
    public bool isOpen;

    // Update is called once per frame
    private void Start()
    {
        start = transform.GetChild(0).transform.position;
        center = transform.GetChild(0).transform.position - transform.TransformDirection(new Vector3(0, 0, 2));
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 2)
        {
            transform.GetChild(0).transform.position = Vector3.Lerp(transform.GetChild(0).transform.position, center, 0.01f);
            transform.GetChild(1).transform.position = Vector3.Lerp(transform.GetChild(1).transform.position, center, 0.01f);
            isOpen = true;
        }
        else
        {
            transform.GetChild(0).transform.position = Vector3.Lerp(transform.GetChild(0).transform.position, start, 0.01f);
            transform.GetChild(1).transform.position = Vector3.Lerp(transform.GetChild(1).transform.position, start, 0.01f);
            isOpen = false;
        }
    }
}