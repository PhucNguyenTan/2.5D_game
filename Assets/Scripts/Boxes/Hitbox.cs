using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    #region Variables
    public LayerMask mask;
    public bool useSphere = false;
    public Vector3 boxSize = Vector3.one;
    public float radius = 0.5f;
    public Color inActiveColor;
    public Color colliderOpenColor;
    public Color collidingColor;
    private IHitboxResponder _responder = null;
    private ColliderState state;
    #endregion

    public enum ColliderState
    {
        Closed,
        Open,
        Colliding
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector3.zero, new Vector3(boxSize.x * 2, boxSize.y * 2, boxSize.z * 2)); // Because size is halfExtents
    }

    private void CheckGizmoColor()
    {
        switch (state)
        {
            case (ColliderState.Closed):
                Gizmos.color = inActiveColor;
                break;
            case (ColliderState.Open):
                Gizmos.color = colliderOpenColor;
                break;
            case (ColliderState.Colliding):
                Gizmos.color = collidingColor;
                break;

        }

    }

    public void startCheckingCollision()
    {
        state = ColliderState.Open;
    }

    public void stopCheckingCollision()
    {
        state = ColliderState.Closed;
    }

    #region interface
    public interface IHitboxResponder
    {
        void collisionedWith(Collider collider);
    }
    #endregion

    public void HitboxUpdate()
    {
        if (state == ColliderState.Closed) { return; }
        Collider[] colliders = Physics.OverlapBox(transform.position, boxSize, transform.rotation, mask);

        for(int i=0; i < colliders.Length; i++)
        {
            Collider aCollider = colliders[i];
            _responder?.collisionedWith(aCollider);

        }

        state = colliders.Length > 0 ? ColliderState.Colliding : ColliderState.Open;
    }

    public void useResponder(IHitboxResponder responder)
    {
        _responder = responder;
    }
}
