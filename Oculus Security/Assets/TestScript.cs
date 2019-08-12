using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class TestScript : MonoBehaviour
{

    // Use this for initialization
    string RightP_X;
    string RightP_Y;
    string RightP_Z;
    string RightR_W;
    string RightR_X;
    string RightR_Y;
    string RightR_Z;

    string LeftP_X;
    string LeftP_Y;
    string LeftP_Z;
    string LeftR_W;
    string LeftR_X;
    string LeftR_Y;
    string LeftR_Z;

    string playerpos_X;
    string playerpos_Y;
    string playerpos_Z;

    string playerrot_W;
    string playerrot_X;
    string playerrot_Y;
    string playerrot_Z;


    string fileName;
    string filePath;

    /// Gets the linear acceleration of the given Controller local to its tracking space
    string Laccel_X;
    string Laccel_Y;
    string Laccel_Z;

    string Raccel_X;
    string Raccel_Y;
    string Raccel_Z;

    string Raaccel_X;
    string Raaccel_Y;
    string Raaccel_Z;

    string Laaccel_X;
    string Laaccel_Y;
    string Laaccel_Z;

    string Rvel_X;
    string Rvel_Y;
    string Rvel_Z;

    string Lvel_X;
    string Lvel_Y;
    string Lvel_Z;

    string Ravel_X;
    string Ravel_Y;
    string Ravel_Z;

    string Lavel_X;
    string Lavel_Y;
    string Lavel_Z;


    string Cam_pos_X;
    string Cam_pos_Y;
    string Cam_pos_Z;


    string Cam_rot_W;
    string Cam_rot_X;
    string Cam_rot_Y;
    string Cam_rot_Z;

    string PrimaryHandTrigger;
    string SecondaryHandTrigger;

    int frameCount = 0;

    string id = "7";
    string task = "2";
    string round = "2";


    private List<string[]> rowData = new List<string[]>();

    void Start()
    {

        fileName = "ID" + id +"_T" + task + "_R" + round + ".csv";
        //fileName = DateTime.Now.ToString() + ".txt";

        filePath = "Assets/Data/";
        // File.Create(filePath);    
        Save();
    }

    // Update is called once per frame
    void Update()
    {

        AddData();


    }

    void Save()
    {

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[55];
        rowDataTemp[0] = "Frame";
        rowDataTemp[1] = "RtouchPos_X";
        rowDataTemp[2] = "RtouchPos_Y";
        rowDataTemp[3] = "RtouchPos_Z";

        rowDataTemp[4] = "RtouchRot_W";
        rowDataTemp[5] = "RtouchRot_X";
        rowDataTemp[6] = "RtouchRot_Y";
        rowDataTemp[7] = "RtouchRot_Z";

        rowDataTemp[8] = "LtouchPos_X";
        rowDataTemp[9] = "LtouchPos_Y";
        rowDataTemp[10] = "LtouchPos_Z";

        rowDataTemp[11] = "LtouchRot_W";
        rowDataTemp[12] = "LtouchRot_X";
        rowDataTemp[13] = "LtouchRot_Y";
        rowDataTemp[14] = "LtouchRot_Z";

        rowDataTemp[15] = "PlayerPos_X";
        rowDataTemp[16] = "PlayerPos_Y";
        rowDataTemp[17] = "PlayerPos_Z";

        rowDataTemp[18] = "PlayerRot_W";
        rowDataTemp[19] = "PlayerRot_X";
        rowDataTemp[20] = "PlayerRot_Y";
        rowDataTemp[21] = "PlayerRot_Z";

        rowDataTemp[22] = "Right_Accel_X";
        rowDataTemp[23] = "Right_Accel_Y";
        rowDataTemp[24] = "Right_Accel_Z";

        rowDataTemp[25] = "Left_Accel_X";
        rowDataTemp[26] = "Left_Accel_Y";
        rowDataTemp[27] = "Left_Accel_Z";

        rowDataTemp[28] = "Camera_Pos_X";
        rowDataTemp[29] = "Camera_Pos_Y";
        rowDataTemp[30] = "Camera_Pos_Z";

        rowDataTemp[31] = "Camera_Rot_W";
        rowDataTemp[32] = "Camera_Rot_X";
        rowDataTemp[33] = "Camera_Rot_Y";
        rowDataTemp[34] = "Camera_Rot_Z";

        rowDataTemp[35] = "Right_Angular_Accel_X";
        rowDataTemp[36] = "Right_Angular_Accel_Y";
        rowDataTemp[37] = "Right_Angular_Accel_Z";

        rowDataTemp[38] = "Left_Angular_Accel_X";
        rowDataTemp[39] = "Left_Angular_Accel_Y";
        rowDataTemp[40] = "Left_Angular_Accel_Z";

        rowDataTemp[41] = "Right_Vel_X";
        rowDataTemp[42] = "Right_Vel_Y";
        rowDataTemp[43] = "Right_Vel_Z";

        rowDataTemp[44] = "Left_Vel_X";
        rowDataTemp[45] = "Left_Vel_Y";
        rowDataTemp[46] = "Left_Vel_Z";

        rowDataTemp[47] = "Right_Angular_Vel_X";
        rowDataTemp[48] = "Right_Angular_Vel_Y";
        rowDataTemp[49] = "Right_Angular_Vel_Z";

        rowDataTemp[50] = "Left_Angular_Vel_X";
        rowDataTemp[51] = "Left_Angular_Vel_Y";
        rowDataTemp[52] = "Left_Angular_Vel_Z";

        rowDataTemp[53] = "Primary Hand Trigger";
        rowDataTemp[54] = "Secondary Hand Trigger";


        rowData.Add(rowDataTemp);


        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        StreamWriter outStream = File.CreateText(filePath + fileName);
        outStream.Write(sb);
        outStream.Close();
    }

    void AddData()
    {

        RightP_X = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch).x.ToString();
        RightP_Y = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch).y.ToString();
        RightP_Z = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch).z.ToString();

        RightR_W = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).w.ToString();
        RightR_X = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).x.ToString();
        RightR_Y = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).y.ToString();
        RightR_Z = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).z.ToString();


        LeftP_X = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).x.ToString();
        LeftP_Y = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).y.ToString();
        LeftP_Z = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).z.ToString();

        LeftR_W = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).w.ToString();
        LeftR_X = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).x.ToString();
        LeftR_Y = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).y.ToString();
        LeftR_Z = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).z.ToString();


        playerpos_X = Camera.main.gameObject.transform.position.x.ToString();
        playerpos_Y = Camera.main.gameObject.transform.position.y.ToString();
        playerpos_Z = Camera.main.gameObject.transform.position.z.ToString();


        playerrot_W = Camera.main.gameObject.transform.rotation.w.ToString();
        playerrot_X = Camera.main.gameObject.transform.rotation.x.ToString();
        playerrot_Y = Camera.main.gameObject.transform.rotation.y.ToString();
        playerrot_Z = Camera.main.gameObject.transform.rotation.z.ToString();

        Raccel_X = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.RTouch).x.ToString();
        Raccel_Y = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.RTouch).y.ToString();
        Raccel_Z = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.RTouch).z.ToString();

        Laccel_X = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.LTouch).x.ToString();
        Laccel_Y = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.LTouch).y.ToString();
        Laccel_Z = OVRInput.GetLocalControllerAcceleration(OVRInput.Controller.LTouch).z.ToString();

        Cam_pos_X = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye).x.ToString();
        Cam_pos_Y = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye).y.ToString();
        Cam_pos_Z = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye).z.ToString();

        Cam_rot_X = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).x.ToString();
        Cam_rot_Y = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).y.ToString();
        Cam_rot_Z = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).z.ToString();
        Cam_rot_W = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).w.ToString();

        Raaccel_X = OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.RTouch).x.ToString();
        Raaccel_Y = OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.RTouch).y.ToString();
        Raaccel_Z = OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.RTouch).z.ToString();

        Laaccel_X = OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.LTouch).x.ToString();
        Laaccel_Y = OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.LTouch).y.ToString();
        Laaccel_Z = OVRInput.GetLocalControllerAngularAcceleration(OVRInput.Controller.LTouch).z.ToString();

        Rvel_X = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).x.ToString();
        Rvel_Y = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).y.ToString();
        Rvel_Z = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).z.ToString();

        Lvel_X = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).x.ToString();
        Lvel_Y = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).y.ToString();
        Lvel_Z = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).z.ToString();

        Ravel_X = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch).x.ToString();
        Ravel_Y = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch).y.ToString();
        Ravel_Z = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch).z.ToString();

        Lavel_X = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).x.ToString();
        Lavel_Y = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).y.ToString();
        Lavel_Z = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).z.ToString();

        PrimaryHandTrigger = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch).ToString();
        SecondaryHandTrigger = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch).ToString();



        string[] rowDataTemp = new string[55];
        List<string[]> rowData1 = new List<string[]>();
        // You can add up the values in as many cells as you want.

        rowDataTemp = new string[55];
        rowDataTemp[0] = Time.frameCount.ToString();
        rowDataTemp[1] = RightP_X;
        rowDataTemp[2] = RightP_Y;
        rowDataTemp[3] = RightP_Z;

        rowDataTemp[4] = RightR_W;
        rowDataTemp[5] = RightR_X;
        rowDataTemp[6] = RightR_Y;
        rowDataTemp[7] = RightR_Z;

        rowDataTemp[8] = LeftP_X;
        rowDataTemp[9] = LeftP_Y;
        rowDataTemp[10] = LeftP_Z;

        rowDataTemp[11] = LeftR_W;
        rowDataTemp[12] = LeftR_X;
        rowDataTemp[13] = LeftR_Y;
        rowDataTemp[14] = LeftR_X;

        rowDataTemp[15] = playerpos_X;
        rowDataTemp[16] = playerpos_Y;
        rowDataTemp[17] = playerpos_Z;

        rowDataTemp[18] = playerrot_W;
        rowDataTemp[19] = playerrot_X;
        rowDataTemp[20] = playerrot_Y;
        rowDataTemp[21] = playerrot_Z;

        rowDataTemp[22] = Raccel_X;
        rowDataTemp[23] = Raccel_Y;
        rowDataTemp[24] = Raccel_Z;

        rowDataTemp[25] = Laccel_X;
        rowDataTemp[26] = Laccel_Y;
        rowDataTemp[27] = Laccel_Z;

        rowDataTemp[28] = Cam_pos_X;
        rowDataTemp[29] = Cam_pos_Y;
        rowDataTemp[30] = Cam_pos_Z;

        rowDataTemp[31] = Cam_rot_W;
        rowDataTemp[32] = Cam_rot_X;
        rowDataTemp[33] = Cam_rot_Y;
        rowDataTemp[34] = Cam_rot_Z;

        rowDataTemp[35] = Raaccel_X;
        rowDataTemp[36] = Raaccel_X;
        rowDataTemp[37] = Raaccel_X;

        rowDataTemp[38] = Laaccel_X;
        rowDataTemp[39] = Laaccel_Y;
        rowDataTemp[40] = Laaccel_Z;

        rowDataTemp[41] = Rvel_X;
        rowDataTemp[42] = Rvel_X;
        rowDataTemp[43] = Rvel_X;

        rowDataTemp[44] = Lvel_X;
        rowDataTemp[45] = Lvel_Y;
        rowDataTemp[46] = Lvel_Z;

        rowDataTemp[47] = Ravel_X;
        rowDataTemp[48] = Ravel_X;
        rowDataTemp[49] = Ravel_X;

        rowDataTemp[50] = Lavel_X;
        rowDataTemp[51] = Lavel_Y;
        rowDataTemp[52] = Lavel_Z;

        rowDataTemp[53] = PrimaryHandTrigger;
        rowDataTemp[54] = SecondaryHandTrigger;





        rowData1.Add(rowDataTemp);

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData1[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb1 = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb1.AppendLine(string.Join(delimiter, output[index]));


        StreamWriter outStream = File.AppendText(filePath + fileName);
        outStream.Write(sb1);
        outStream.Close();
    
    }

}