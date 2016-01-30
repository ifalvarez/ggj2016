using UnityEngine;


/// <summary>
/// A singleton class for MonoBehaviour.
/// </summary>
/// <typeparam name="T">The type of the singleton. If the type is "FooBar", this value should be "FooBar".</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; protected set; }

    /// <summary>
    /// Replaces the Awake function, as Singleton uses the Awake event.
    /// </summary>
    protected virtual void OnAwake() { }
    private void Awake()
    {
        if (typeof(T) != this.GetType() && !typeof(T).IsAssignableFrom(this.GetType())) throw new System.InvalidOperationException("Type argument does not match singleton type!");

        if (Instance == null)
        {
            Instance = this as T;
            OnAwake();
        }

        else
        {
            Debug.LogWarning("Only one instance of " + this.GetType() + " is allowed per scene!");
            Destroy(gameObject);
            //else throw new System.InvalidOperationException("Only one instance of "+this.GetType()+" is allowed per scene!");
        }
    }
}