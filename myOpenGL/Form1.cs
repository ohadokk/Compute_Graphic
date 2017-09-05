using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenGL;
using System.Runtime.InteropServices; 

namespace myOpenGL
{
    public partial class Form1 : Form
    {
        cOGL cGL;
        bool XFlag=false,YFlag,ZFlag;
        bool singlton=true;
        public Form1()
        {

            InitializeComponent();
            cGL = new cOGL(panel1);
            //apply the bars values as cGL.ScrollValue[..] properties 
            //!!!
            hScrollBarScroll(hScrollBar1, null);
            hScrollBarScroll(hScrollBar2, null);
            hScrollBarScroll(hScrollBar3, null);
            hScrollBarScroll(hScrollBar4, null);
            hScrollBarScroll(hScrollBar5, null);
            hScrollBarScroll(hScrollBar6, null);
            hScrollBarScroll(hScrollBar7, null);
            hScrollBarScroll(hScrollBar8, null);
            hScrollBarScroll(hScrollBar9, null);
            hScrollBarScroll(hScrollBar10, null);
            hScrollBarScroll(hScrollBar11, null);
            hScrollBarScroll(hScrollBar12, null);
            hScrollBarScroll(hScrollBar13, null);
            hScrollBarScroll(hScrollBar14, null);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //cGL.ScrollValue[11 - 1] = (-100) / 10.0f;
            cGL.ScrollValue[10 - 1] = (-20) / 10.0f;
            cGL.Draw();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            cGL.OnResize();
        }

        public float[] oldPos = new float[7];

        private void numericUpDownValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nUD = (NumericUpDown)sender;
            int i = int.Parse(nUD.Name.Substring(nUD.Name.Length - 1));
            int pos = (int)nUD.Value;
            switch (i)
            {
                case 1:
                    if (pos > oldPos[i - 1])
                    {
                        if (cGL.xShiftFlag == 0.0)
                        {
                            cGL.xShift = 0.0f;
                            cGL.xShiftFlag = 1.0f;

                        }
                        cGL.xShift += 0.5f;
                        cGL.intOptionC = 4;
                    }
                    else
                    {
                        if (cGL.xShiftFlag == 1.0)
                        {
                            cGL.xShift = 0.0f;
                            cGL.xShiftFlag = 0.0f;

                        }
                        cGL.xShift -= 0.5f;
                        cGL.intOptionC = -4;
                    }
                    break;
                case 2:
                    if (pos > oldPos[i - 1])
                    {
                        if (cGL.yShiftFlag == 0.0)
                        {
                            cGL.yShift = 0.0f;
                            cGL.yShiftFlag = 1.0f;

                        }
                        cGL.yShift += 0.5f;
                        cGL.intOptionC = 5;
                    }
                    else
                    {
                        if (cGL.yShiftFlag == 1.0)
                        {
                            cGL.yShift = 0.0f;
                            cGL.yShiftFlag = 0.0f;

                        }
                        cGL.yShift -= 0.5f;
                        cGL.intOptionC = -5;
                    }
                    break;
                case 3:
                    if (pos > oldPos[i - 1])
                    {
                        if (cGL.zShiftFlag == 0.0)
                        {
                            cGL.zShift = 0.0f;
                            cGL.zShiftFlag = 1.0f;

                        }
                        cGL.zShift += 0.5f;
                        cGL.intOptionC = 6;
                    }
                    else
                    {
                        if (cGL.zShiftFlag == 1.0)
                        {
                            cGL.zShift = 0.0f;
                            cGL.zShiftFlag = 0.0f;

                        }
                        cGL.zShift -= 0.5f;
                        cGL.intOptionC = -6;
                    }
                    break;
                case 4:
                    if (pos > oldPos[i - 1])
                    {
                        if (cGL.xAngleFlag == 0.0)
                        {
                            cGL.xAngle = 0.0f;
                            cGL.xAngleFlag = 1.0f;

                        }
                        cGL.xAngle += 0.75f;
                        cGL.intOptionC = 1;
                    }
                    else
                    {
                        if (cGL.xAngleFlag == 1.0)
                        {
                            cGL.xAngle = 0.0f;
                            cGL.xAngleFlag = 0.0f;

                        }
                        cGL.xAngle -= 0.75f;
                        cGL.intOptionC = -1;
                    }
                    break;
                case 5:
                    if (pos > oldPos[i - 1])
                    {
                        if (cGL.yAngleFlag == 1.0)
                        {
                            cGL.yAngle = 0.0f;
                            cGL.yAngleFlag = 0.0f;

                        }
                        cGL.yAngle += 0.75f;
                        cGL.intOptionC = 2;
                    }
                    else
                    {
                        if (cGL.yAngleFlag == 0.0)
                        {
                            cGL.yAngle = 0.0f;
                            cGL.yAngleFlag = 1.0f;

                        }
                        cGL.yAngle -= 0.75f;
                        cGL.intOptionC = -2;
                    }
                    break;
                case 6:
                    if (pos > oldPos[i - 1])
                    {
                        if (cGL.zAngleFlag == 1.0)
                        {
                            cGL.zAngle = 0.0f;
                            cGL.zAngleFlag = 0.0f;

                        }
                        cGL.zAngle += 0.75f;
                        cGL.intOptionC = 3;
                    }
                    else
                    {
                        if (cGL.zAngleFlag == 0.0)
                        {
                            cGL.zAngle = 0.0f;
                            cGL.zAngleFlag = 1.0f;

                        }
                        cGL.zAngle -= 0.75f;
                        cGL.intOptionC = -3;
                    }
                    break;
            }
            cGL.Draw();
            oldPos[i - 1] = pos;

        }

        private void hScrollBarScroll(object sender, ScrollEventArgs e)
        {
            //cGL.intOptionC =0;
            label11.Text = (((HScrollBar)sender).Value).ToString();
            if(((HScrollBar)sender).Name.Equals("hScrollBar11"))
            {
                
            }
            if (((HScrollBar)sender).Name.Equals("hScrollBar12"))
            {
                if (((HScrollBar)sender).Value >= 60 && ((HScrollBar)sender).Value <= 141)
                    cGL.Ylight = true;
                else
                    cGL.Ylight = false;
            }
            if (((HScrollBar)sender).Name.Equals("hScrollBar13"))
            {
                cGL.Xlight = true;
            }

            HScrollBar hb = (HScrollBar)sender;
            int n = int.Parse(hb.Name.Substring(10));
            cGL.ScrollValue[n - 1] = (hb.Value - 100) / 10.0f;
            if (e != null)
                cGL.Draw();
        }

     

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cGL.isSolid = !cGL.isSolid;
            cGL.Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            XFlag = true;
            YFlag = false;
            ZFlag = false;
            singlton = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            ZFlag = true;
            XFlag = false;
            YFlag = false;
            singlton = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (singlton)
            {
                cGL.initializeAngle();
                cGL.initialize(1, 0);
                cGL.initialize(2, 0);
                cGL.initializeSet(1, 0.0024f, 0);
                cGL.initializeSet(2, 0.0024f, 0);
                
                //cGL.DrawAll();
                singlton = false;
            }
            if (XFlag)
            {
                //cGL.DrawAll();
                cGL.FlagMAchine(0, 2, 20, 22, 0, 1);
               // cGL.initializeAngle();
               
            }
            if (YFlag)
            {
                //cGL.DrawAll();
                cGL.FlagMAchine(1, 3, 21, 23, 1, 1);
            }
            if (ZFlag)
            {
                //cGL.DrawAll();
                cGL.FlagMAchine(4, 5, 24, 25, 2, 1);
            }
            cGL.Draw();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            YFlag = true;
            XFlag = false;
            ZFlag = false;
            singlton = true;
        }
    }
}