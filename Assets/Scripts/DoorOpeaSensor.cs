using UnityEngine;
using UnityEngine.Events;

public class DoorOpeaSensor : MonoBehaviour
{
    public Transform PlayerTransform;

    public Animator DoorAnimator;

    public float Distance = 3;

    public UnityEvent OnDoorOpen;

    public UnityEvent OnDoorClose;

    private bool isDoorOpen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDoorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDoorOpen && Vector3.Distance(transform.position, PlayerTransform.position) < Distance)
        {
            DoorAnimator.Play("open");
            isDoorOpen = true;

            //if(OnDoorOpen != nu11)
            //{
            //    OnDoorOpen.Invoke();
            //}
            OnDoorOpen?.Invoke();
        }
        else if (isDoorOpen &&Vector3.Distance(transform.position, PlayerTransform.position) > Distance)
        {
            DoorAnimator.Play("Close");
            isDoorOpen = false;
            OnDoorClose?.Invoke();
        }
    }

    

    void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Distance);
    }
}
