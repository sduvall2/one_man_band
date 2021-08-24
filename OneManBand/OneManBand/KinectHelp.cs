using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Kinect;


namespace OneManBand
{
    class KinectHelp
    {
        KinectSensor myKinect;
        //Rectangle videoDisplayRectangle;
        string errorMessage = "";

        Texture2D kinectVideoTexture;
        byte[] colorData = null;
        Skeleton[] skeletons = null;
        Skeleton trackedSkeleton;

        //public KinectHelp()
        //{ 
        //    kinectVideoTexture = 
            
        //    myKinect = KinectSensor.KinectSensors.FirstOrDefault();
        //    myKinect.SkeletonStream.Enable();
        //    myKinect.Start();

        //    myKinect.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(myKinect_SkeletonFrameReady);
        //}

        //public void draw(SpriteBatch spriteBatch, Rectangle videoDisplayRectangle, SpriteFont messageFont)
        //{
        //    if (kinectVideoTexture != null)
        //    {
        //        spriteBatch.Draw(kinectVideoTexture, videoDisplayRectangle, Color.White);
        //    }

        //    if (errorMessage.Length > 0)
        //    {
        //        spriteBatch.DrawString(messageFont, errorMessage, Vector2.Zero, Color.White);
        //    }
        //}

        //public void drawSkeletonProcess()
        //{
        //    if (trackedSkeleton != null)
        //    {
        //        ////head & shoulders
        //        //drawJoint(trackedSkeleton.Joints[JointType.Head], texJointBlue);

        //        ////shoulders
        //        //drawJoint(trackedSkeleton.Joints[JointType.ShoulderCenter], texJointBlue);

        //        ////spine & hips
        //        //drawJoint(trackedSkeleton.Joints[JointType.Spine], texJointBlue);
        //        //drawJoint(trackedSkeleton.Joints[JointType.HipCenter], texJointBlue);

        //        ////Right Arm
        //        //drawJoint(trackedSkeleton.Joints[JointType.ShoulderRight], texJointPurple);
        //        //drawJoint(trackedSkeleton.Joints[JointType.ElbowRight], texJointPurple);
        //        //drawJoint(trackedSkeleton.Joints[JointType.WristRight], texJointPurple);
        //        //drawJoint(trackedSkeleton.Joints[JointType.HandRight], texJointPurple);

        //        ////Left Arm
        //        //drawJoint(trackedSkeleton.Joints[JointType.ShoulderLeft], texJointYellow);
        //        //drawJoint(trackedSkeleton.Joints[JointType.ElbowLeft], texJointYellow);
        //        //drawJoint(trackedSkeleton.Joints[JointType.WristLeft], texJointYellow);
        //        //drawJoint(trackedSkeleton.Joints[JointType.HandLeft], texJointYellow);

        //        ////Right Leg
        //        //drawJoint(trackedSkeleton.Joints[JointType.HipRight], texJointRed);
        //        //drawJoint(trackedSkeleton.Joints[JointType.KneeRight], texJointRed);
        //        //drawJoint(trackedSkeleton.Joints[JointType.AnkleRight], texJointRed);
        //        //drawJoint(trackedSkeleton.Joints[JointType.FootRight], texJointRed);


        //        ////Left Leg
        //        //drawJoint(trackedSkeleton.Joints[JointType.HipLeft], texJointGreen);
        //        //drawJoint(trackedSkeleton.Joints[JointType.KneeLeft], texJointGreen);
        //        //drawJoint(trackedSkeleton.Joints[JointType.AnkleLeft], texJointGreen);
        //        //drawJoint(trackedSkeleton.Joints[JointType.FootLeft], texJointGreen);

        //        //DrawSkeleton(spriteBatch, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), texJointRed);
        //        DrawSkeleton(texJointRed);
        //        //if right elbow height == height of the right sholder joint 
        //        //if left elbow height ==  height of the left shoulder joint 
        //        //draw the joint green
        //        Joint rightElbow = trackedSkeleton.Joints[JointType.ElbowRight];
        //        Joint leftElbow = trackedSkeleton.Joints[JointType.ElbowLeft];
        //        Joint rightShol = trackedSkeleton.Joints[JointType.ShoulderRight];
        //        Joint leftShol = trackedSkeleton.Joints[JointType.ShoulderLeft];
        //        if (rightElbow.Position.Y >= rightShol.Position.Y)
        //        {
        //            drawJoint(rightElbow, texJointGreen);
        //            drawJoint(rightShol, texJointGreen);
        //        }
        //        if (leftElbow.Position.Y >= leftShol.Position.Y)
        //        {
        //            drawJoint(leftElbow, texJointGreen);
        //            drawJoint(leftShol, texJointGreen);
        //        }
        //    }
        //}

        //void myKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        //{
        //    using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
        //    {
        //        if (skeletonFrame != null)
        //        {
        //            if (skeletons == null)
        //            {
        //                skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
        //            }

        //            skeletonFrame.CopySkeletonDataTo(skeletons);

        //            trackedSkeleton = skeletons.Where(s => s.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();
        //        }
        //    }
        //}

        //void myKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        //{
        //    using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
        //    {
        //        if (colorFrame == null)
        //        {
        //            return;
        //        }

        //        if (colorData == null)
        //        {
        //            colorData = new byte[colorFrame.Width * colorFrame.Height * 4];
        //        }

        //        colorFrame.CopyPixelDataTo(colorData);
        //        kinectVideoTexture = new Texture2D(GraphicsDevice, colorFrame.Width, colorFrame.Height);
        //        Color[] bitmap = new Color[colorFrame.Width * colorFrame.Height];

        //        int sourceOffset = 0;
        //        for (int i = 0; i < bitmap.Length; i++)
        //        {
        //            bitmap[i] = new Color(colorData[sourceOffset + 2],
        //                colorData[sourceOffset + 1],
        //                colorData[sourceOffset],
        //                255);
        //            sourceOffset += 4;
        //        }

        //        kinectVideoTexture.SetData(bitmap);
        //    }
        //}

        //private void DrawSkeleton(Texture2D img)
        //{
        //    Vector2 resolution = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        //    if (trackedSkeleton != null)
        //    {
        //        foreach (Joint joint in trackedSkeleton.Joints)
        //        {
        //            Vector2 position = new Vector2((((0.5f * joint.Position.X) + 0.5f) * (resolution.X)), (((-0.5f * joint.Position.Y) + 0.5f) * (resolution.Y)));
        //            spriteBatch.Draw(img, new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 10, 10), Color.White);
        //        }
        //    }
        //}

        //private void drawJoint(Joint joint, Texture2D img)
        //{
        //    Vector2 resolution = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        //    Vector2 position = new Vector2((((0.5f * joint.Position.X) + 0.5f) * (resolution.X)), (((-0.5f * joint.Position.Y) + 0.5f) * (resolution.Y)));
        //    spriteBatch.Draw(img, new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 10, 10), Color.White);
        //}

        //public bool setupKinect()
        //{
        //    if (KinectSensor.KinectSensors.Count == 0)
        //    {
        //        errorMessage = "No Kinects detected";
        //        return false;
        //    }

        //    myKinect = KinectSensor.KinectSensors[0];

        //    try
        //    {
        //        myKinect.ColorStream.Enable();
        //    }
        //    catch
        //    {
        //        errorMessage = "Kinect initialise failed";
        //        return false;
        //    }

        //    myKinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(myKinect_ColorFrameReady);

        //    try
        //    {
        //        myKinect.Start();
        //    }
        //    catch
        //    {
        //        errorMessage = "Camera start failed";
        //        return false;
        //    }

        //    return true;
        //}
    }
}
