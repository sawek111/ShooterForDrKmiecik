using UnityEngine;
using Zenject;

public class UnityService : ITickable
{
    private RaycastHit _hit;

    public void Tick()
    {
        if (IsLeftMouseButtonUp || IsRightMouseButtonUp)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 100f);
            _hit = hit;
        }
    }

    public bool IsLeftMouseButtonUp
    {
        get { return Input.GetMouseButtonUp(0); }
    }

    public bool IsRightMouseButtonUp
    {
        get { return Input.GetMouseButtonUp(1); }
    }

    public RaycastHit GetMouseHit()
    {
        return _hit;
    }



}
