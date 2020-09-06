/*
 * Camera2DFollow: FIXED! Allows the camera to follow the player. Original camera from asset snapped the player around. Now, camera and player are like 1.
 *
 * author: Allison Poh (commented code provided by asset)
 *
 * Timestamp: 11/3/19
 */

using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour {
        //position of camera
        public float xMin;
        public float xMax;
        public float yMin;
        public float yMax;

        public GameObject gObject; //player

        //after all other updates, update position of camera
        void LateUpdate() {
            float x = Mathf.Clamp(gObject.transform.position.x, xMin, xMax);
            float y = Mathf.Clamp(gObject.transform.position.y, yMin, yMax);

            gameObject.transform.position = new Vector3(x,y,gameObject.transform.position.z);
        }
    }

}


/* 
//ORIGINAL CAMERA CODE PROVIDED BY ASSET -- FAULTY!

using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }
    }
}

*/
