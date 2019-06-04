using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework;
using Live2D.Cubism.Framework.LookAt;
using Live2D.Cubism.Framework.HarmonicMotion;
using System;

public class AddMotions : MonoBehaviour {

    // Use this for initialization
    
    void Start () {
        GameObject model = GameObject.Find("18-8-18_Live2d_MeidoChan");
        model.AddComponent<Penetration>();
        
         
        // Auto Eyeblink
        GameObject EyeL = GameObject.Find("Parameters/ParamEyeLOpen");
        GameObject EyeR = GameObject.Find("Parameters/ParamEyeROpen");
 
        EyeL.AddComponent<CubismEyeBlinkParameter>();
        EyeR.AddComponent<CubismEyeBlinkParameter>();

        var blinkcontroller = model.AddComponent<CubismEyeBlinkController>();
        blinkcontroller.BlendMode = CubismParameterBlendMode.Override;
        model.AddComponent<CubismAutoEyeBlinkInput>();

        
        // Eye leading
        GameObject AngleX = GameObject.Find("Parameters/ParamAngleX");
        GameObject AngleY = GameObject.Find("Parameters/ParamAngleY");
        GameObject EyeBallX = GameObject.Find("Parameters/ParamEyeBallX");
        GameObject EyeBallY = GameObject.Find("Parameters/ParamEyeBallY");
        GameObject BodyX = GameObject.Find("Parameters/ParamBodyAngleX");
        GameObject BodyY = GameObject.Find("Parameters/ParamBodyAngleY");

        var angleX = AngleX.AddComponent<CubismLookParameter>();
        angleX.Axis = CubismLookAxis.X;
        angleX.Factor = 30;
        var angleY = AngleY.AddComponent<CubismLookParameter>();
        angleY.Axis = CubismLookAxis.Y;
        angleY.Factor = 30;
        var eyeBallX = EyeBallX.AddComponent<CubismLookParameter>();
        eyeBallX.Axis = CubismLookAxis.X;
        eyeBallX.Factor = 2;
        var eyeBallY = EyeBallY.AddComponent<CubismLookParameter>();
        eyeBallY.Axis = CubismLookAxis.Y;
        eyeBallY.Factor = 1;
        var bodyX = BodyX.AddComponent<CubismLookParameter>();
        bodyX.Axis = CubismLookAxis.X;
        bodyX.Factor = 15;
        var bodyY = BodyY.AddComponent<CubismLookParameter>();
        bodyY.Axis = CubismLookAxis.Y;
        bodyY.Factor = 15;

        var lookcontroller = model.AddComponent<CubismLookController>();
        lookcontroller.BlendMode = CubismParameterBlendMode.Override;
        lookcontroller.Target = GameObject.Find("LookTarget");
        

        //Breath
        GameObject breath = GameObject.Find("Parameters/ParamBreath");
        var breathparam = breath.AddComponent<CubismHarmonicMotionParameter>();
        breathparam.Direction = CubismHarmonicMotionDirection.Centric;
        breathparam.Channel = 0;

        var breathcontroller = model.AddComponent<CubismHarmonicMotionController>();
        breathcontroller.BlendMode = CubismParameterBlendMode.Override;
        breathcontroller.ChannelTimescales = new float[1];
        breathcontroller.ChannelTimescales[0] = 1.5f;

        


    }

}
