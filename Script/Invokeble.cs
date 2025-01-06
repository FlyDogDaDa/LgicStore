using UnityEngine;

public abstract class Invokeble : MonoBehaviour
{
    public abstract void Click();
    public abstract void Drop(GameObject visitor);
    public abstract bool IsDroppable(GameObject visitor);
    public void Drag() { }
    public void InDrag() { }
    public void OutDrag() { }
}
