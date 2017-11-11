

using UnityEngine;
using System.Collections;

public class Deformer : MonoBehaviour
{
    /// <summary>
    /// protected field to store the spacing of the deformer
    /// </summary>
    [SerializeField()]
    protected float _spacing = 0.0f;
    /// <summary>
    /// gets or sets the spacing the deformer has to a deformable
    /// </summary>
    public virtual float Spacing
    {
        get { return _spacing; }
        set { _spacing = value; }
    }

    /// <summary>
    /// protected field to store whether the Transform property should be ignored/overriden
    /// </summary>
    [SerializeField()]
    protected bool _ignoreTransformed = true;

    protected bool _transformed = false;
    /// <summary>
    /// gets whether the deformer has been transformed since the last frame (running in Update())
    /// </summary>
    public bool Transformed
    { get { return _transformed | _ignoreTransformed; } }

    // private fields to store last frame transformation data
    private Vector3 _lastPosition;
    private Quaternion _lastRotation;
    private Vector3 _lastScale;

    // runs a simple update loop to determine if it was transformed during the last frame
    void Update()
    {
        _transformed = false;
        if (this.transform.position != _lastPosition
            || this.transform.rotation != _lastRotation
            || this.transform.lossyScale != _lastScale)
            _transformed = true;

        _lastPosition = this.transform.position;
        _lastRotation = this.transform.rotation;
        _lastScale = this.transform.lossyScale;
    }
}
