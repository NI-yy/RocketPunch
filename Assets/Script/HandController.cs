using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HandController : MonoBehaviour
{
    OVRInput.Controller LeftCon;
    OVRInput.Controller RightCon;
    public GameObject normalPunch;
    public GameObject bluePunch;
    public GameObject yellowPunch;
    public GameObject redPunch;
    public float rayScale;
    public bool ColorEnable;

    float delayTime = 0.1f;
    float adjustVelocity = 40.0f;

    Vector3 posLeft;
    Vector3 posRight;
    Vector3 vLeft;
    Vector3 vRight;
    Vector3 accelerationLeft;
    Vector3 accelerationRight;
    Vector3 posTrackingSpace;

    List<Vector3> vLeftList = new List<Vector3>();
    List<float> vLeftMagnitudeList = new List<float>();
    List<Vector3> vRightList = new List<Vector3>();
    List<float> vRightMagnitudeList = new List<float>();


    public GameObject TrackingSpace;

    // Start is called before the first frame update
    void Start()
    {
        LeftCon = OVRInput.Controller.LTouch;
        RightCon = OVRInput.Controller.RTouch;
    }

    // Update is called once per frame
    void Update()
    {
        posTrackingSpace = TrackingSpace.transform.position;

        posLeft = OVRInput.GetLocalControllerPosition(LeftCon);
        posRight = OVRInput.GetLocalControllerPosition(RightCon);
        
        vLeft = OVRInput.GetLocalControllerVelocity(LeftCon);
        vRight = OVRInput.GetLocalControllerVelocity(RightCon);

        accelerationLeft = OVRInput.GetLocalControllerAcceleration(LeftCon);
        accelerationRight = OVRInput.GetLocalControllerAcceleration(RightCon);

        GetLeftPunch(posLeft,posTrackingSpace, vLeft);

        GetRightPunch(posRight, posTrackingSpace, vRight);
    }


    void GetLeftPunch(Vector3 posLeft, Vector3 posTrackingSpace, Vector3 vLeft)
    {
        if (ColorEnable)
        {
            if (vLeft.magnitude > 2.0f) //���x��2.0�𒴂�����v��
            {
                vLeftList.Add(vLeft);
                vLeftMagnitudeList.Add(vLeft.magnitude);
                int listCounttest = vLeftList.Count;
            }
            else //���x��2.0�ȉ�
            {

                int listCount = vLeftList.Count;
                if (listCount <= 1)
                {
                    return;
                }
                if (vLeftMagnitudeList[listCount - 1] > 2.0f) //���x��2.0��"�������"�Ƃ�
                {
                    Vector3 worldPosLeft = posLeft + posTrackingSpace;
                    GameObject bulletObject;
                    Debug.Log("�p���`���x�ő�l��" + vLeftMagnitudeList.Max());

                    if (vLeftMagnitudeList.Max() < 5)
                    {
                        Debug.Log("�F");
                        bulletObject = Instantiate(bluePunch, worldPosLeft, Quaternion.identity);
                    }
                    else if (vLeftMagnitudeList.Max() >= 5 && vLeftMagnitudeList.Max() < 6)
                    {
                        Debug.Log("���F");
                        bulletObject = Instantiate(yellowPunch, worldPosLeft, Quaternion.identity);
                    }
                    else
                    {
                        Debug.Log("�ԐF");
                        bulletObject = Instantiate(redPunch, worldPosLeft, Quaternion.identity);
                    }

                    Rigidbody rb = bulletObject.GetComponent<Rigidbody>();  // rigidbody���擾

                    rb.velocity = Ishit(worldPosLeft, GetAverage(vLeftList)) * adjustVelocity;
                    vLeftList.Clear();
                    vLeftMagnitudeList.Clear();
                }
            }
        }
        else
        {
            if (vLeft.magnitude > 2.0f) //���x��2.0�𒴂�����v��
            {
                vLeftList.Add(vLeft);
                vLeftMagnitudeList.Add(vLeft.magnitude);
                int listCounttest = vLeftList.Count;
            }
            else
            {
                int listCount = vLeftList.Count;
                if (listCount <= 1)
                {
                    return;
                }
                if (vLeftMagnitudeList[listCount - 1] > 2.0f) //���x��2.0��"�������"�Ƃ�
                {
                    Vector3 worldPosLeft = posLeft + posTrackingSpace;
                    GameObject bulletObject;
                    Debug.Log("�p���`���x�ő�l��" + vLeftMagnitudeList.Max());
                    Debug.Log("Normal");
                    bulletObject = Instantiate(normalPunch, worldPosLeft, Quaternion.identity);

                    Rigidbody rb = bulletObject.GetComponent<Rigidbody>();  // rigidbody���擾

                    rb.velocity = Ishit(worldPosLeft, GetAverage(vLeftList)) * adjustVelocity;
                    vLeftList.Clear();
                    vLeftMagnitudeList.Clear();
                }
            }
        }  
    }

    void GetRightPunch(Vector3 posRight, Vector3 posTrackingSpace, Vector3 vRight)
    {
        if (ColorEnable)
        {
            if (vRight.magnitude > 2.0f) //���x��2.0�𒴂�����v��
            {
                vRightList.Add(vRight);
                vRightMagnitudeList.Add(vRight.magnitude);
                int listCounttest = vRightList.Count;
            }
            else //���x��2.0�ȉ�
            {
                int listCount = vRightList.Count;
                if (listCount <= 1)
                {
                    return;
                }
                if (vRightMagnitudeList[listCount - 1] > 2.0f) //���x��2.0��"�������"�Ƃ�
                {
                    Vector3 worldPosRight = posRight + posTrackingSpace;
                    GameObject bulletObject;
                    Debug.Log("�p���`���x�ő�l��" + vRightMagnitudeList.Max());

                    if (vRightMagnitudeList.Max() < 2.5f)
                    {
                        Debug.Log("�F");
                        bulletObject = Instantiate(bluePunch, worldPosRight, Quaternion.identity);
                    }
                    else if (vRightMagnitudeList.Max() >= 3.0f && vRightMagnitudeList.Max() < 3.5f)
                    {
                        Debug.Log("���F");
                        bulletObject = Instantiate(yellowPunch, worldPosRight, Quaternion.identity);
                    }
                    else
                    {
                        Debug.Log("�ԐF");
                        bulletObject = Instantiate(redPunch, worldPosRight, Quaternion.identity);
                    }

                    Rigidbody rb = bulletObject.GetComponent<Rigidbody>();  // rigidbody���擾

                    rb.velocity = Ishit(worldPosRight, GetAverage(vRightList)) * adjustVelocity;
                    vRightList.Clear();
                    vRightMagnitudeList.Clear();
                }
            }
        }
        else
        {
            if (vRight.magnitude > 2.0f) //���x��2.0�𒴂�����v��
            {
                vRightList.Add(vRight);
                vRightMagnitudeList.Add(vRight.magnitude);
                int listCounttest = vRightList.Count;
            }
            else //���x��2.0�ȉ�
            {
                int listCount = vRightList.Count;
                if (listCount <= 1)
                {
                    return;
                }
                if (vRightMagnitudeList[listCount - 1] > 2.0f) //���x��2.0��"�������"�Ƃ�
                {
                    Vector3 worldPosRight = posRight + posTrackingSpace;
                    GameObject bulletObject;
                    Debug.Log("�p���`���x�ő�l��" + vRightMagnitudeList.Max());
                    Debug.Log("Normal");
                    bulletObject = Instantiate(normalPunch, worldPosRight, Quaternion.identity);

                    Rigidbody rb = bulletObject.GetComponent<Rigidbody>();  // rigidbody���擾

                    rb.velocity = Ishit(worldPosRight, GetAverage(vRightList)) * adjustVelocity;
                    vRightList.Clear();
                    vRightMagnitudeList.Clear();
                }
            }
        }
        
    }

    Vector3 GetAverage(List<Vector3> vList)
    {
        int i;
        Vector3 sumVector = Vector3.zero;
        Vector3 aveVector = Vector3.zero;

        for(i = 0; i < vList.Count; i++)
        {
            sumVector += vList[i];
        }

        aveVector = sumVector / vList.Count;

        return aveVector;
    }

    Vector3 Ishit(Vector3 worldHandPos, Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.BoxCast(worldHandPos, Vector3.one * rayScale, direction, out hit, Quaternion.identity, 100f, LayerMask.GetMask("Enemy")))
        {
            //Debug.Log("�␳����");
            return (hit.transform.position - worldHandPos).normalized;
        }
        else
        {
            //Debug.Log("�␳����");
            return direction.normalized;
        }
        
    }
}
