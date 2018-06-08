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

    public bool GetKeyUp(KeyCode code)
    {
        return Input.GetKeyUp(code);
    }

    public bool IsLeftMouseButtonUp
    {
        get { return Input.GetMouseButtonUp(0); }
    }

    public bool IsRightMouseButtonUp
    {
        get { return Input.GetMouseButtonUp(1); }
    }

    public float GetAxis(Axis axis)
    {
        return Input.GetAxis(axis.ToString());
    }

    public RaycastHit GetMouseHit()
    {
        return _hit;
    }



}
