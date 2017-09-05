using System;
using System.Collections.Generic;
using System.Windows.Forms;

//2
using System.Drawing;

namespace OpenGL
{
    class cOGL
    {
        Control p;
        int Width;
        int Height;

        float d;

        float[] TTT;
        float[] TZT;
        float[] TTZ;
        float[] TZZ;
        float[] ZZZ;
        float[] ZTT;
        float[] ZTZ;
        float[] ZZT;

        float[] TTT2;
        float[] TZT2;
        float[] TTZ2;
        float[] TZZ2;
        float[] ZZZ2;
        float[] ZTT2;
        float[] ZTZ2;
        float[] ZZT2;

        float[][][] FACES;
        float[][][] FACES2;

        int[] ScaleFlag;
        int[] MoveFlag;

        double angleZY, angleXZ, angleXY, angleXYZ, angleXYZ2, angleZY2, angleXZ2, angleXY2;

        float OpenScaleVar;
        float MoveScaleVar;

        public static float T = 1.0f;
        public static float Z = 0.0f;
        public static float T2 = 1.5f;
        public static float Z2 = -0.5f;

        public double angleSized = (Math.PI / 180);

        int Flag = 0;
        public Boolean Xlight=false, Ylight=false, Zlight=false;
        GLUquadric obj;

        public cOGL(Control pb)
        {
            p = pb;
            Width = p.Width;
            Height = p.Height;

            InitializeGL();
            obj = GLU.gluNewQuadric(); //!!!


            TTT = new float[3] { T, T, T };
            TZT = new float[3] { T, Z, T };
            TTZ = new float[3] { T, T, Z };
            TZZ = new float[3] { T, Z, Z };
            ZZZ = new float[3] { Z, Z, Z };
            ZTT = new float[3] { Z, T, T };
            ZTZ = new float[3] { Z, T, Z };
            ZZT = new float[3] { Z, Z, T };


            TTT2 = new float[3] { T2, T2, T2 };
            TZT2 = new float[3] { T2, Z2, T2 };
            TTZ2 = new float[3] { T2, T2, Z2 };
            TZZ2 = new float[3] { T2, Z2, Z2 };
            ZZZ2 = new float[3] { Z2, Z2, Z2 };
            ZTT2 = new float[3] { Z2, T2, T2 };
            ZTZ2 = new float[3] { Z2, T2, Z2 };
            ZZT2 = new float[3] { Z2, Z2, T2 };


            initialize(1, 0);
            angleZY = 0.0;
            angleXZ = 0.0;
            angleXY = 0.0;
            angleXYZ = 0.0;
            angleZY2 = 0.0;
            angleXZ2 = 0.0;
            angleXY2 = 0.0;
            angleXYZ2 = 0.0;

            OpenScaleVar = 0.01f;
            MoveScaleVar = 0.01f;

            ScaleFlag = new int[] { 0, 0, 0, 0, 0, 0 };
            MoveFlag = new int[] { 0, 0, 0, 0, 0, 0 };

            FACES = new float[6][][]{ new float[][] { ZZZ, ZTZ, ZTT, ZZT  },
                                      new float[][] { TZZ, ZZZ, ZZT, TZT  },
                                      new float[][] { TZZ, TTZ, TTT, TZT  },
                                      new float[][] { TTZ, ZTZ, ZTT, TTT  },
                                      new float[][] { ZTZ, ZZZ, TZZ, TTZ  },
                                      new float[][] { ZTT, ZZT, TZT, TTT} };

            FACES2 = new float[6][][]{new float[][] { ZZZ2, ZTZ2, ZTT2, ZZT2  },
                                      new float[][] { TZZ2, ZZZ2, ZZT2, TZT2  },
                                      new float[][] { TZZ2, TTZ2, TTT2, TZT2  },
                                      new float[][] { TTZ2, ZTZ2, ZTT2, TTT2  },
                                      new float[][] { ZTZ2, ZZZ2, TZZ2, TTZ2  },
                                      new float[][] { ZTT2, ZZT2, TZT2, TTT2} };


            intOptionC = 1;

            ground[0, 0] = 1;
            ground[0, 1] = 1;
            ground[0, 2] = -0.5f;

            ground[1, 0] = 0;
            ground[1, 1] = 1;
            ground[1, 2] = -0.5f;

            ground[2, 0] = 1;
            ground[2, 1] = 0;
            ground[2, 2] = -0.5f;

            wall[0, 0] = -15;
            wall[0, 1] = 3;
            wall[0, 2] = 0;

            wall[1, 0] = 15;
            wall[1, 1] = 3;
            wall[1, 2] = 0;

            wall[2, 0] = 15;
            wall[2, 1] = 3;
            wall[2, 2] = 15;

            isSolid = true;

            InitializeGL();
            obj = GLU.gluNewQuadric(); //!!!
        }

        ~cOGL()
        {
            GLU.gluDeleteQuadric(obj); //!!!
            WGL.wglDeleteContext(m_uint_RC);
        }

        public void DrawAll()
        {


            GL.glLineWidth(5.0f);
            float[] pos = new float[4];
            //GL.glEnable(GL.GL_LIGHT0);
            //pos[0] = 10; pos[1] = 10; pos[2] = 10; pos[3] = 1;
            //GL.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, pos);
            //GL.glDisable(GL.GL_LIGHTING);
            GL.glPushMatrix();
            GL.glScalef(2.0f, 2.0f, 2.0f);
            GL.glTranslatef(-0.5f, 0.0f, 0.5f);

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  RED
            //GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(ZZZ[0], ZZZ[1], ZZZ[2]);
            GL.glVertex3f(TZZ[0], TZZ[1], TZZ[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //y  GREEN 
            // GL.glColor3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(ZZZ[0], ZZZ[1], ZZZ[2]);
            GL.glVertex3f(ZTZ[0], ZTZ[1], ZTZ[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  BLUE
            // GL.glColor3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(ZZZ[0], ZZZ[1], ZZZ[2]);
            GL.glVertex3f(ZZT[0], ZZT[1], ZZT[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  YELLOW
            //GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(TTT[0], TTT[1], TTT[2]);
            GL.glVertex3f(ZTT[0], ZTT[1], ZTT[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //y  TURKIZ 
            // GL.glColor3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(TTT[0], TTT[1], TTT[2]);
            GL.glVertex3f(TZT[0], TZT[1], TZT[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  PURPUL
            //GL.glColor3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(TTT[0], TTT[1], TTT[2]);
            GL.glVertex3f(TTZ[0], TTZ[1], TTZ[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  WHITE
            //GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(ZTT[0], ZTT[1], ZTT[2]);
            GL.glVertex3f(ZTZ[0], ZTZ[1], ZTZ[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  GRAY
            //GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(ZTT[0], ZTT[1], ZTT[2]);
            GL.glVertex3f(ZZT[0], ZZT[1], ZZT[2]);

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  LIGHT GREEN
            //GL.glColor3f(0.1f, 0.8f, 0.5f);
            GL.glVertex3f(TZT[0], TZT[1], TZT[2]);
            GL.glVertex3f(ZZT[0], ZZT[1], ZZT[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  LIGHT TURKIZ
            //GL.glColor3f(0.1f, 0.8f, 0.9f);
            GL.glVertex3f(TZT[0], TZT[1], TZT[2]);
            GL.glVertex3f(TZZ[0], TZZ[1], TZZ[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  LIGHT PURPUL
            //GL.glColor3f(1.0f, 0.6f, 1.0f);
            GL.glVertex3f(TTZ[0], TTZ[1], TTZ[2]);
            GL.glVertex3f(ZTZ[0], ZTZ[1], ZTZ[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  GRY BULE
            //GL.glColor3f(0.4f, 0.6f, 1.0f);
            GL.glVertex3f(TTZ[0], TTZ[1], TTZ[2]);
            GL.glVertex3f(TZZ[0], TZZ[1], TZZ[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glEnd();

            /////////////////////////////////////////////////////////////////////////////




            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  RED
            //GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(ZZZ[0], ZZZ[1], ZZZ[2]);
            GL.glVertex3f(ZZZ2[0], ZZZ2[1], ZZZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  BLUE
            //GL.glColor3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(ZZT[0], ZZT[1], ZZT[2]);
            GL.glVertex3f(ZZT2[0], ZZT2[1], ZZT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  YELLOW
            //GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(ZTT[0], ZTT[1], ZTT[2]);
            GL.glVertex3f(ZTT2[0], ZTT2[1], ZTT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //y  TURKIZ 
            //GL.glColor3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(TZT[0], TZT[1], TZT[2]);
            GL.glVertex3f(TZT2[0], TZT2[1], TZT2[2]);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  PURPUL
            //GL.glColor3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(TTZ[0], TTZ[1], TTZ[2]);
            GL.glVertex3f(TTZ2[0], TTZ2[1], TTZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  WHITE
            //GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(TTT[0], TTT[1], TTT[2]);
            GL.glVertex3f(TTT2[0], TTT2[1], TTT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  GRAY
            //GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(ZZT[0], ZZT[1], ZZT[2]);
            GL.glVertex3f(ZZT2[0], ZZT2[1], ZZT2[2]);

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  LIGHT GREEN
            //GL.glColor3f(0.1f, 0.8f, 0.5f);
            GL.glVertex3f(ZZT[0], ZZT[1], ZZT[2]);
            GL.glVertex3f(ZZT2[0], ZZT2[1], ZZT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //x  LIGHT TURKIZ
            //GL.glColor3f(0.1f, 0.8f, 0.9f);
            GL.glVertex3f(TZZ[0], TZZ[1], TZZ[2]);
            GL.glVertex3f(TZZ2[0], TZZ2[1], TZZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  LIGHT PURPUL
            //GL.glColor3f(1.0f, 0.6f, 1.0f);
            GL.glVertex3f(ZTZ[0], ZTZ[1], ZTZ[2]);
            GL.glVertex3f(ZTZ2[0], ZTZ2[1], ZTZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            GL.glBegin(GL.GL_LINES);
            //z  GRY BULE
            //GL.glColor3f(0.4f, 0.6f, 1.0f);
            GL.glVertex3f(TZZ[0], TZZ[1], TZZ[2]);
            GL.glVertex3f(TZZ2[0], TZZ2[1], TZZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glEnd();






            ///////////////////////////////////////////////////////////////////////////////

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //x  RED
            //GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(ZZZ2[0], ZZZ2[1], ZZZ2[2]);
            GL.glVertex3f(TZZ2[0], TZZ2[1], TZZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();


            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //y  GREEN 
            //GL.glColor3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(ZZZ2[0], ZZZ2[1], ZZZ2[2]);
            GL.glVertex3f(ZTZ2[0], ZTZ2[1], ZTZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //z  BLUE
            //GL.glColor3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(ZZZ2[0], ZZZ2[1], ZZZ2[2]);
            GL.glVertex3f(ZZT2[0], ZZT2[1], ZZT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //x  YELLOW
            //GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(TTT2[0], TTT2[1], TTT2[2]);
            GL.glVertex3f(ZTT2[0], ZTT2[1], ZTT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //y  TURKIZ 
            //GL.glColor3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(TTT2[0], TTT2[1], TTT2[2]);
            GL.glVertex3f(TZT2[0], TZT2[1], TZT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            // GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //z  PURPUL
            //GL.glColor3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(TTT2[0], TTT2[1], TTT2[2]);
            GL.glVertex3f(TTZ2[0], TTZ2[1], TTZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //x  WHITE
            //GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(ZTT2[0], ZTT2[1], ZTT2[2]);
            GL.glVertex3f(ZTZ2[0], ZTZ2[1], ZTZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            // GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //x  GRAY
            //GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(ZTT2[0], ZTT2[1], ZTT2[2]);
            GL.glVertex3f(ZZT2[0], ZZT2[1], ZZT2[2]);

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            // GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //x  LIGHT GREEN
            //GL.glColor3f(0.1f, 0.8f, 0.5f);
            GL.glVertex3f(TZT2[0], TZT2[1], TZT2[2]);
            GL.glVertex3f(ZZT2[0], ZZT2[1], ZZT2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //x  LIGHT TURKIZ
            //GL.glColor3f(0.1f, 0.8f, 0.9f);
            GL.glVertex3f(TZT2[0], TZT2[1], TZT2[2]);
            GL.glVertex3f(TZZ2[0], TZZ2[1], TZZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //z  LIGHT PURPUL
            // GL.glColor3f(1.0f, 0.6f, 1.0f);
            GL.glVertex3f(TTZ2[0], TTZ2[1], TTZ2[2]);
            GL.glVertex3f(ZTZ2[0], ZTZ2[1], ZTZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();

            GL.glPushMatrix();
            GL.glScalef(1.0f, 1.0f, 1.0f);
            //GL.glTranslatef(0.5f, 0.5f, 0.5f);
            GL.glBegin(GL.GL_LINES);
            //z  GRY BULE
            //GL.glColor3f(0.4f, 0.6f, 1.0f);
            GL.glVertex3f(TTZ2[0], TTZ2[1], TTZ2[2]);
            GL.glVertex3f(TZZ2[0], TZZ2[1], TZZ2[2]);
            GL.glEnd();
            GL.glPopMatrix();
           
            GL.glEnd();
            GL.glPopMatrix();
        }
        public void initialize(int cube, int size)
        {
            if (cube == 1)
            {
                TTT[0] = T + size;
                TTT[1] = T + size;
                TTT[2] = T + size;

                TZT[0] = T + size;
                TZT[1] = Z + size;
                TZT[2] = T + size;

                TTZ[0] = T + size;
                TTZ[1] = T + size;
                TTZ[2] = Z + size;

                TZZ[0] = T + size;
                TZZ[1] = Z + size;
                TZZ[2] = Z + size;

                ZZZ[0] = Z + size;
                ZZZ[1] = Z + size;
                ZZZ[2] = Z + size;

                ZTT[0] = Z + size;
                ZTT[1] = T + size;
                ZTT[2] = T + size;

                ZTZ[0] = Z + size;
                ZTZ[1] = T + size;
                ZTZ[2] = Z + size;

                ZZT[0] = Z + size;
                ZZT[1] = Z + size;
                ZZT[2] = T + size;
            }
            if (cube == 2)
            {
                TTT2[0] = T2 + size;
                TTT2[1] = T2 + size;
                TTT2[2] = T2 + size;

                TZT2[0] = T2 + size;
                TZT2[1] = Z2 + size;
                TZT2[2] = T2 + size;

                TTZ2[0] = T2 + size;
                TTZ2[1] = T2 + size;
                TTZ2[2] = Z2 + size;

                TZZ2[0] = T2 + size;
                TZZ2[1] = Z2 + size;
                TZZ2[2] = Z2 + size;

                ZZZ2[0] = Z2 + size;
                ZZZ2[1] = Z2 + size;
                ZZZ2[2] = Z2 + size;

                ZTT2[0] = Z2 + size;
                ZTT2[1] = T2 + size;
                ZTT2[2] = T2 + size;

                ZTZ2[0] = Z2 + size;
                ZTZ2[1] = T2 + size;
                ZTZ2[2] = Z2 + size;

                ZZT2[0] = Z2 + size;
                ZZT2[1] = Z2 + size;
                ZZT2[2] = T2 + size;
            }
        }
        public void initializeSet(int cube, float size, int XYZ)
        {

            if (cube == 1)
            {
                TTT[XYZ] = TTT[XYZ] + size;
                TZT[XYZ] = TZT[XYZ] + size;
                TTZ[XYZ] = TTZ[XYZ] + size;
                TZZ[XYZ] = TZZ[XYZ] + size;
                ZZZ[XYZ] = ZZZ[XYZ] + size;
                ZTT[XYZ] = ZTT[XYZ] + size;
                ZTZ[XYZ] = ZTZ[XYZ] + size;
                ZZT[XYZ] = ZZT[XYZ] + size;
            }
            if (cube == 2)
            {
                TTT2[XYZ] = TTT2[XYZ] + size;
                TZT2[XYZ] = TZT2[XYZ] + size;
                TTZ2[XYZ] = TTZ2[XYZ] + size;
                TZZ2[XYZ] = TZZ2[XYZ] + size;
                ZZZ2[XYZ] = ZZZ2[XYZ] + size;
                ZTT2[XYZ] = ZTT2[XYZ] + size;
                ZTZ2[XYZ] = ZTZ2[XYZ] + size;
                ZZT2[XYZ] = ZZT2[XYZ] + size;
            }
        }
        public void initializeAngle()
        {
           
            angleZY = 0.0;
            angleXZ = 0.0;
            angleXY = 0.0;
            angleXYZ = 0.0;
            angleZY2 = 0.0;
            angleXZ2 = 0.0;
            angleXY2 = 0.0;
            angleXYZ2 = 0.0;
            initialize(1, 1);
            initialize(2, 1);
            
          
          

        }
        public void OpenClose(int faceIndex, int pm, float OpenScale)
        {
            switch (faceIndex)
            {
                case 0:
                    OpenCloseZY(FACES[faceIndex], pm, OpenScale, ref angleZY);
                    break;
                case 1:
                    OpenCloseXZ(FACES[faceIndex], pm, OpenScale, ref angleXZ);
                    break;
                case 2:
                    OpenCloseZY(FACES[faceIndex], pm, OpenScale, ref angleZY);
                    break;
                case 3:
                    OpenCloseXZ(FACES[faceIndex], pm, OpenScale, ref angleXZ);
                    break;
                case 4:
                    OpenCloseXY(FACES[faceIndex], pm, OpenScale, ref angleXY);
                    break;
                case 5:
                    OpenCloseXY(FACES[faceIndex], pm, OpenScale, ref angleXY);
                    break;
                case 20:
                    OpenCloseZY(FACES2[faceIndex - 20], pm, OpenScale, ref angleZY2);
                    break;
                case 21:
                    OpenCloseXZ(FACES2[faceIndex - 20], pm, OpenScale, ref angleXZ2);
                    break;
                case 22:
                    OpenCloseZY(FACES2[faceIndex - 20], pm, OpenScale, ref angleZY2);
                    break;
                case 23:
                    OpenCloseXZ(FACES2[faceIndex - 20], pm, OpenScale, ref angleXZ2);
                    break;
                case 24:
                    OpenCloseXY(FACES2[faceIndex - 20], pm, OpenScale, ref angleXY2);
                    break;
                case 25:
                    OpenCloseXY(FACES2[faceIndex - 20], pm, OpenScale, ref angleXY2);
                    break;
            }
        }


        public void OpenCloseZY(float[][] face, int pm, float OpenScale, ref double angle)
        {
            face[0][2] -= OpenScale * pm * (float)Math.Sin(angle);
            face[0][1] -= OpenScale * pm * (float)Math.Sin(angle);

            face[1][2] -= OpenScale * pm * (float)Math.Sin(angle);
            face[1][1] += OpenScale * pm * (float)Math.Sin(angle);

            face[2][2] += OpenScale * pm * (float)Math.Sin(angle);
            face[2][1] += OpenScale * pm * (float)Math.Sin(angle);

            face[3][2] += OpenScale * pm * (float)Math.Sin(angle);
            face[3][1] -= OpenScale * pm * (float)Math.Sin(angle);

            angle += angleSized;
        }
        public void OpenCloseXZ(float[][] face, int pm, float OpenScale, ref double angle)
        {
            face[0][0] += OpenScale * pm * (float)Math.Sin(angle); ;
            face[0][2] -= OpenScale * pm * (float)Math.Sin(angle); ;

            face[1][0] -= OpenScale * pm * (float)Math.Sin(angle); ;
            face[1][2] -= OpenScale * pm * (float)Math.Sin(angle); ;

            face[2][0] -= OpenScale * pm * (float)Math.Sin(angle); ;
            face[2][2] += OpenScale * pm * (float)Math.Sin(angle); ;

            face[3][0] += OpenScale * pm * (float)Math.Sin(angle); ;
            face[3][2] += OpenScale * pm * (float)Math.Sin(angle); ;

            angle += angleSized;

        }
        public void OpenCloseXY(float[][] face, int pm, float OpenScale, ref double angle)
        {
            face[0][0] -= OpenScale * pm * (float)Math.Sin(angle);
            face[0][1] += OpenScale * pm * (float)Math.Sin(angle);

            face[1][0] -= OpenScale * pm * (float)Math.Sin(angle);
            face[1][1] -= OpenScale * pm * (float)Math.Sin(angle);

            face[2][0] += OpenScale * pm * (float)Math.Sin(angle);
            face[2][1] -= OpenScale * pm * (float)Math.Sin(angle);

            face[3][0] += OpenScale * pm * (float)Math.Sin(angle);
            face[3][1] += OpenScale * pm * (float)Math.Sin(angle);

            angle += angleSized;
        }


        public void MoveXYZ(int cube, ref double angle, int face, int pm, int XYZ, float MoveScale, int scene)
        {
            if (cube == 1)
            {
                if (XYZ >= 0 && XYZ <= 3)
                {
                    FACES[face][0][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    FACES[face][1][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    FACES[face][2][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    FACES[face][3][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    if (scene == 5)
                        angle += angleSized / 6.5;
                    else
                        angle += angleSized;
                }
            }
            if (cube == 2)
            {
                if (XYZ >= 0 && XYZ <= 3)
                {
                    FACES2[face - 20][0][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    FACES2[face - 20][1][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    FACES2[face - 20][2][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    FACES2[face - 20][3][XYZ] += MoveScale * pm * (float)Math.Sin(angle);
                    if (scene == 5)
                        angle += angleSized / 6.5;
                    else
                        angle += angleSized;
                }
            }

        }


        public void FlagMAchine(int Faceback1, int FaceFront1, int Faceback2, int FaceFront2, int XYZ, int pm)
        {
            //scene3(2, ref angleXYZ2, 20, 22, 0);
            //scene1(1, ref angleXYZ, 0, 2, 0);

            if (angleXYZ2 < Math.PI)
            {
                MoveXYZ(2, ref angleXYZ2, FaceFront2, -pm, XYZ, MoveScaleVar * 2f, 3);
                OpenClose(Faceback2, -pm, OpenScaleVar / 2);

                OpenClose(FaceFront1, pm, OpenScaleVar / 2);
                MoveXYZ(1, ref angleXYZ, Faceback1, pm, XYZ, MoveScaleVar / 2, 1);
            }
            else
            {

                if (angleXYZ2 < Math.PI * 2)
                {

                    MoveXYZ(1, ref angleXYZ, FaceFront1, pm, XYZ, MoveScaleVar * 2f, 3);
                    OpenClose(Faceback1, -pm, OpenScaleVar / 2);



                    OpenClose(FaceFront2, pm, OpenScaleVar / 2);
                    MoveXYZ(2, ref angleXYZ2, Faceback2, -pm, XYZ, MoveScaleVar / 2, 1);


                }
                else
                {
                    if (angleXYZ2 < Math.PI * 3)
                    {
                        MoveXYZ(1, ref angleXYZ, Faceback1, -pm, XYZ, MoveScaleVar * 2f, 3);
                        OpenClose(FaceFront1, -pm, OpenScaleVar / 2);

                        OpenClose(Faceback2, pm, OpenScaleVar / 2);
                        MoveXYZ(2, ref angleXYZ2, FaceFront2, pm, XYZ, MoveScaleVar / 2, 1);
                    }
                    else
                    {
                        if (angleXYZ2 < Math.PI * 4)
                        {
                            MoveXYZ(2, ref angleXYZ2, Faceback2, pm, XYZ, MoveScaleVar * 2f, 3);
                            OpenClose(FaceFront2, -pm, OpenScaleVar / 2);



                            OpenClose(Faceback1, pm, OpenScaleVar / 2);
                            MoveXYZ(1, ref angleXYZ, FaceFront1, -pm, XYZ, MoveScaleVar / 2, 1);
                        }
                        else
                        {
                            angleXYZ2 = 0.0;
                            initialize(1, 0);
                            initialize(2, 0);

                        }

                        //Flag = 2;

                    }
                }
            }
            initializeSet(1, 0.0024f, XYZ);
            initializeSet(2, 0.0024f, XYZ);
        }


        uint m_uint_HWND = 0;

        public uint HWND
        {
            get { return m_uint_HWND; }
        }

        uint m_uint_DC = 0;

        public uint DC
        {
            get { return m_uint_DC; }
        }
        uint m_uint_RC = 0;

        public uint RC
        {
            get { return m_uint_RC; }
        }




        float[] planeCoeff = { 1, 1, 1, 1 };
        float[,] ground = new float[3, 3];//{ { 1, 1, -0.5 }, { 0, 1, -0.5 }, { 1, 0, -0.5 } };
        float[,] wall = new float[3, 3];//{ { -15, 3, 0 }, { 15, 3, 0 }, { 15, 3, 15 } };

        // Reduces a normal vector specified as a set of three coordinates,
        // to a unit normal vector of length one.
        void ReduceToUnit(float[] vector)
        {
            float length;

            // Calculate the length of the vector		
            length = (float)Math.Sqrt((vector[0] * vector[0]) +
                                (vector[1] * vector[1]) +
                                (vector[2] * vector[2]));

            // Keep the program from blowing up by providing an exceptable
            // value for vectors that may calculated too close to zero.
            if (length == 0.0f)
                length = 1.0f;

            // Dividing each element by the length will result in a
            // unit normal vector.
            vector[0] /= length;
            vector[1] /= length;
            vector[2] /= length;
        }

        const int x = 0;
        const int y = 1;
        const int z = 2;

       

        // Points p1, p2, & p3 specified in counter clock-wise order
        void calcNormal(float[,] v, float[] outp)
        {
            float[] v1 = new float[3];
            float[] v2 = new float[3];

            // Calculate two vectors from the three points
            v1[x] = v[0, x] - v[1, x];
            v1[y] = v[0, y] - v[1, y];
            v1[z] = v[0, z] - v[1, z];

            v2[x] = v[1, x] - v[2, x];
            v2[y] = v[1, y] - v[2, y];
            v2[z] = v[1, z] - v[2, z];

            // Take the cross product of the two vectors to get
            // the normal vector which will be stored in out
            outp[x] = v1[y] * v2[z] - v1[z] * v2[y];
            outp[y] = v1[z] * v2[x] - v1[x] * v2[z];
            outp[z] = v1[x] * v2[y] - v1[y] * v2[x];

            // Normalize the vector (shorten length to one)
            ReduceToUnit(outp);
        }

        float[] cubeXform = new float[16];

        // Creates a shadow projection matrix out of the plane equation
        // coefficients and the position of the light. The return value is stored
        // in cubeXform[,]
        void MakeShadowMatrix(float[,] points)
        {
            float[] planeCoeff = new float[4];
            float dot;

            // Find the plane equation coefficients
            // Find the first three coefficients the same way we
            // find a normal.
            calcNormal(points, planeCoeff);

            // Find the last coefficient by back substitutions
            planeCoeff[3] = -(
                (planeCoeff[0] * points[2, 0]) + (planeCoeff[1] * points[2, 1]) +
                (planeCoeff[2] * points[2, 2]));


            // Dot product of plane and light position
            dot = planeCoeff[0] * pos[0] +
                    planeCoeff[1] * pos[1] +
                    planeCoeff[2] * pos[2] +
                    planeCoeff[3];

            // Now do the projection
            // First column
            cubeXform[0] = dot - pos[0] * planeCoeff[0];
            cubeXform[4] = 0.0f - pos[0] * planeCoeff[1];
            cubeXform[8] = 0.0f - pos[0] * planeCoeff[2];
            cubeXform[12] = 0.0f - pos[0] * planeCoeff[3];

            // Second column
            cubeXform[1] = 0.0f - pos[1] * planeCoeff[0];
            cubeXform[5] = dot - pos[1] * planeCoeff[1];
            cubeXform[9] = 0.0f - pos[1] * planeCoeff[2];
            cubeXform[13] = 0.0f - pos[1] * planeCoeff[3];

            // Third Column
            cubeXform[2] = 0.0f - pos[2] * planeCoeff[0];
            cubeXform[6] = 0.0f - pos[2] * planeCoeff[1];
            cubeXform[10] = dot - pos[2] * planeCoeff[2];
            cubeXform[14] = 0.0f - pos[2] * planeCoeff[3];

            // Fourth Column
            cubeXform[3] = 0.0f - pos[3] * planeCoeff[0];
            cubeXform[7] = 0.0f - pos[3] * planeCoeff[1];
            cubeXform[11] = 0.0f - pos[3] * planeCoeff[2];
            cubeXform[15] = dot - pos[3] * planeCoeff[3];
        }
        //Shadows


        public bool isSolid = true;
        void DrawFloor()
        {
            GL.glEnable(GL.GL_LIGHTING);
            GL.glBegin(GL.GL_QUADS);
            //!!! for blended REFLECTION 
            GL.glColor4d(0, 0, 1, 0.5);
            GL.glVertex3d(-4, -4, -1);
            GL.glVertex3d(-4, 4, -1);
            GL.glVertex3d(4, 4, -1);
            GL.glVertex3d(4, -4, -1);
            GL.glEnd();
            GL.glDisable(GL.GL_LIGHTING);



        }
        void DrawFigures()
        {
            int i;
            //!!!!!!!!!!!!!
            GL.glPushMatrix();
            //!!!!!!!!!!!!!
            //plane grids
            GL.glDisable(GL.GL_LIGHTING);
            if (!isSolid)
            {
                GL.glColor3d(0, 0, 0.5);
                GL.glBegin(GL.GL_LINES);
                for (i = -20; i < 21; i++)
                {
                    GL.glVertex3d(-20, i, ground[0, 2] + 5);
                    GL.glVertex3d(20, i, ground[0, 2] + 5);
                    GL.glVertex3d(i, -20, ground[0, 2] + 5);
                    GL.glVertex3d(i, 20, ground[0, 2] + 5);
                }
                GL.glEnd();
                GL.glColor3d(0, 0.0, 0);
                GL.glBegin(GL.GL_LINES);
                for (i = -20; i < 21; i++)
                {
                    GL.glVertex3d(-20, wall[0, 1] - 0.05, i);
                    GL.glVertex3d(20, wall[0, 1] - 0.05, i);
                    GL.glVertex3d(i, wall[0, 1] - 0.05, -20);
                    GL.glVertex3d(i, wall[0, 1] - 0.05, 20);
                }
                GL.glEnd();
            }
            else
            {
                //GL.glEnable(GL.GL_LIGHTING);
                //GL.glColor3f(0, 0, 1);
                GL.glBegin(GL.GL_QUADS);

                GL.glColor3f(0.000f, 0.749f, 1.000f);
                GL.glVertex3d(-100, -100, ground[0, 2] - 0.05);
                GL.glColor3f(0.482f, 0.408f, 0.933f);
                GL.glVertex3d(-100, 100, ground[0, 2] - 0.05);
                GL.glColor3f(0.690f, 0.878f, 0.902f);
                GL.glVertex3d(100, 100, ground[0, 2] - 0.05);
                GL.glColor3f(0.498f, 1.000f, 0.831f);
                GL.glVertex3d(100, -100, ground[0, 2] - 0.05);
               

                GL.glColor3f(0.878f, 1.000f, 1.000f);
                GL.glVertex3d(-100, wall[0, 1] + 0.05, 100);
                GL.glColor3f(0.604f, 0.804f, 0.196f);
                GL.glVertex3d(100, wall[0, 1] + 0.05, 100);
                GL.glColor3f(0.125f, 0.698f, 0.667f);
                GL.glVertex3d(100, wall[0, 1] + 0.05, -100);
                GL.glColor3f(1.000f, 0.000f, 0.000f);
                GL.glVertex3d(-100, wall[0, 1] + 0.05, -100);


                GL.glEnd();
            }

            //Draw Light Source
            GL.glDisable(GL.GL_LIGHTING);
            GL.glTranslatef(pos[0], pos[1], pos[2]);
            //Yellow Light source
            GL.glColor3f(1, 1, 0);
            GLUT.glutSolidSphere(0.5, 8, 8);
            GL.glTranslatef(-pos[0], -pos[1], -pos[2]);
            //projection line from source to plane
            //GL.glBegin(GL.GL_LINES);
            //GL.glColor3d(0.5, 0.5, 0);
            //GL.glVertex3d(pos[0], pos[1], ground[0, 2] - 0.01);
            //GL.glVertex3d(pos[0], pos[1], pos[2]);
            //GL.glEnd();

            //main System draw
            GL.glEnable(GL.GL_LIGHTING);

           // DrawObjects(false, 1);


            //end of regular show
            //!!!!!!!!!!!!!
            GL.glPopMatrix();
            //!!!!!!!!!!!!!

            //SHADING begin
            //we'll define cubeXform matrix in MakeShadowMatrix Sub
            // Disable lighting, we'll just draw the shadow
            //else instead of shadow we'll see stange projection of the same objects
            GL.glDisable(GL.GL_LIGHTING);

            // floor shadow
            //!!!!!!!!!!!!!
            GL.glPushMatrix();
            //!!!!!!!!!!!!    		
            MakeShadowMatrix(ground);
            GL.glMultMatrixf(cubeXform);
            DrawObjects(true, 1);
            //!!!!!!!!!!!!!
            GL.glPopMatrix();
            //!!!!!!!!!!!!!

            // wall shadow
            //!!!!!!!!!!!!!
            GL.glPushMatrix();
            //!!!!!!!!!!!!       
            MakeShadowMatrix(wall);
            GL.glMultMatrixf(cubeXform);
            DrawObjects(true, 2);
            //!!!!!!!!!!!!!
            GL.glPopMatrix();
            //!!!!!!!!!!!!!
        }
        void DrawFigures2()
        {
            //ground[0, 2] = ground[1, 2] = ground[2, 2] = ScrollValue[9];
            GL.glPushMatrix();

            // must be in scene to be reflected too
            GL.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, pos);

            //Draw Light Source
            GL.glDisable(GL.GL_LIGHTING);
            GL.glTranslatef(pos[0], pos[1], pos[2]);
            //Yellow Light source
            GL.glColor3f(1, 1, 0);
            //GLUT.glutSolidSphere(0.05, 8, 8);
            GL.glTranslatef(-pos[0], -pos[1], -pos[2]);
            //projection line from source to plane
            //GL.glBegin(GL.GL_LINES);
            //GL.glColor3d(0.5, 0.5, 0);
            //GL.glVertex3d(pos[0], pos[1], 0);
            //GL.glVertex3d(pos[0], pos[1], pos[2]);
            //GL.glEnd();

            //main System draw
            GL.glEnable(GL.GL_LIGHTING);

            //GL.glRotated(intOptionB, 0, 0, 1); //rotate both

            GL.glColor3f(0, 0, 0);
            GL.glTranslated(0, -0.5, 1);
            //GL.glRotated(intOptionC, 1, 1, 1);
            // MakeShadowMatrix(ground);
           
            DrawAll();
            //GL.glRotated(-intOptionC, 1, 1, 1);
            GL.glTranslated(0, -0.5, -1);

            GL.glTranslated(1, 2, 1.5);
            GL.glRotated(90, 1, 0, 0);
            GL.glColor3d(0, 1, 1);
            GL.glRotated(intOptionB, 1, 0, 0);
            //GLUT.glutSolidTeapot(1);
            GL.glRotated(-intOptionB, 1, 0, 0); //not neccessary
            GL.glRotated(-90, 1, 0, 0);     //not neccessary
            GL.glTranslated(-1, -2, -1.5);  //not neccessary 

            GL.glRotated(intOptionB, 0, 0, 1); //rotate both not neccessary

            GL.glPopMatrix();

          
        }
        void DrawObjects(bool isForShades, int c)
        {

            if (!isForShades)
                GL.glColor3d(1, 1, 1);
            else
                if (c == 1)
                GL.glColor3d(0.5, 0.5, 0.5);
            else
                GL.glColor3d(0.8, 0.8, 0.8);
            //GLUT.glutSolidCube(1);

                DrawCube(false);
         
            DrawAll();

            //GL.glTranslated(1, 2, 0.3);
            //GL.glRotated(90, 1, 0, 0);
            //if (!isForShades)
            //    GL.glColor3d(0, 1, 1);
            //else
            //    if (c == 1)
            //        GL.glColor3d(0.5, 0.5, 0.5);
            //    else
            //        GL.glColor3d(0.8, 0.8, 0.8);
            // GLUT.glutSolidTeapot(1);
            GL.glRotated(-90, 1, 0, 0);
            GL.glTranslated(-1, -2, -0.3);
        }
        void DrawCube(Boolean flag)
        {

            GL.glPushMatrix();
            GL.glScalef(8.0f, 8.0f, 8.0f);
            GL.glTranslatef(-0.5f, -0.5f, -1.125f);
            // cube
            GL.glBegin(GL.GL_QUADS);


            //1
            if(flag==true)
                GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(0.0f, 0.0f, 0.0f);
            //if (flag == true)
            //    GL.glColor3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 1.0f, 0.0f);
            //if (flag == true)
            //    GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 1.0f, 0.0f);

            if (flag == true)
                GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 0.0f, 0.0f);

            //2
            if (flag == true)
                GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(0.0f, 0.0f, 0.0f);
            //if (flag == true)
            //    GL.glColor3f(0.0f, 0.0f, 1.0f);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);
            //if (flag == true)
            //    GL.glColor3f(0.0f, 1.0f, 1.0f);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);
            if (flag == true)
                GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 1.0f, 0.0f);


            //3
            if (flag == true)
                GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(0.0f, 0.0f, 0.0f);
            //if (flag == true)
            //    GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(1.0f, 0.0f, 0.0f);
            //if (flag == true)
            //    GL.glColor3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(1.0f, 0.0f, 1.0f);
            if (flag == true)
                GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 0.0f, 1.0f);


            //4
            if (flag == true)
                GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(1.0f, 0.0f, 0.0f);
            //if (flag == true)
            //    GL.glColor3f(1.0f, 0.0f, 1.0f);
            GL.glVertex3f(1.0f, 0.0f, 1.0f);
            //if (flag == true)
            //    GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glVertex3f(1.0f, 1.0f, 1.0f);
            if (flag == true)
                GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 1.0f, 0.0f);


            //5
            if (flag == true)
                GL.glColor3f(1.0f, 0.0f, 0.0f);
            GL.glVertex3f(1.0f, 1.0f, 1.0f);
            //if (flag == true)
            //    GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(1.0f, 1.0f, 0.0f);
            //if (flag == true)
            //    GL.glColor3f(0.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 1.0f, 0.0f);
            if (flag == true)
                GL.glColor3f(1.0f, 1.0f, 0.0f);
            GL.glVertex3f(0.0f, 1.0f, 1.0f);


            //6

            //GL.glColor3f(1.0f, 1.0f, 1.0f);
            //GL.glVertex3f(1.0f, 1.0f, 1.0f);

            //GL.glColor3f(0.0f, 1.0f, 1.0f);
            //GL.glVertex3f(0.0f, 1.0f, 1.0f);

            //GL.glColor3f(0.0f, 0.0f, 1.0f);
            //GL.glVertex3f(0.0f, 0.0f, 1.0f);

            //GL.glColor3f(1.0f, 0.0f, 1.0f);
            //GL.glVertex3f(1.0f, 0.0f, 1.0f);


            GL.glEnd();
            GL.glPopMatrix();
        }
        public float[] pos = new float[4];
        public int intOptionB = 1;

        public float[] ScrollValue = new float[14];
        public float zShift = 0.0f;
        public float yShift = 0.0f;
        public float xShift = 0.0f;
        public float zAngle = 0.0f;
        public float yAngle = 0.0f;
        public float xAngle = 0.0f;
        public float zShiftFlag = 1.0f;
        public float yShiftFlag = 1.0f;
        public float xShiftFlag = 1.0f;
        public float zAngleFlag = 1.0f;
        public float yAngleFlag = 1.0f;
        public float xAngleFlag = 1.0f;
        public int intOptionC = 0;
        double[] AccumulatedRotationsTraslations = new double[16];

        public void Draw()
        {


            //Shadows
            pos[0] = ScrollValue[10];
            pos[1] = ScrollValue[11];
            pos[2] = ScrollValue[12];
            pos[3] = 1.0f;
            ground[0, 2] = ground[1, 2] = ground[2, 2] = -9.1f;
            wall[0, 1] = wall[1, 1] = wall[2, 1] = 10f;
            //Shadows

            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //                                                           see InitializeGL also
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            GL.glLoadIdentity();

            // not trivial
            double[] ModelVievMatrixBeforeSpecificTransforms = new double[16];
            double[] CurrentRotationTraslation = new double[16];

            GLU.gluLookAt(ScrollValue[0], ScrollValue[1], ScrollValue[2],
                       ScrollValue[3], ScrollValue[4], ScrollValue[5],
                       ScrollValue[6], ScrollValue[7], ScrollValue[8]);
            //GLU.gluLookAt(110, 0, 200,
            //         100, 100, 100,
            //         100, 110,100);
           GL.glRotatef(60f, -100.0f, 15.0f, -500.0f);
            GL.glTranslatef(-15.0f, 15.0f, -5.0f);
          
            //save current ModelView Matrix values
            //in ModelVievMatrixBeforeSpecificTransforms array
            //ModelView Matrix ========>>>>>> ModelVievMatrixBeforeSpecificTransforms
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, ModelVievMatrixBeforeSpecificTransforms);
            //ModelView Matrix was saved, so
            GL.glLoadIdentity(); // make it identity matrix

            //make transformation in accordance to KeyCode
            float delta;
            if (intOptionC != 0)
            {

                delta = 5.0f * Math.Abs(intOptionC) / intOptionC; // signed 5

                switch (Math.Abs(intOptionC))
                {
                    case 1:
                        GL.glRotatef( xAngle, 1, 0, 0);
                        break;
                    case 2:
                        GL.glRotatef( yAngle, 0, 1, 0);
                        break;
                    case 3:
                        GL.glRotatef( zAngle, 0, 0, 1);
                        break;
                    case 4:
                        GL.glTranslatef(xShift / 20, 0, 0);
                        break;
                    case 5:
                        GL.glTranslatef(0, yShift / 20, 0);
                        break;
                    case 6:
                        GL.glTranslatef(0, 0, zShift / 20);
                        break;
                }

            }
            //as result - the ModelView Matrix now is pure representation
            //of KeyCode transform and only it !!!

            //save current ModelView Matrix values
            //in CurrentRotationTraslation array
            //ModelView Matrix =======>>>>>>> CurrentRotationTraslation
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, CurrentRotationTraslation);

            //The GL.glLoadMatrix function replaces the current matrix with
            //the one specified in its argument.
            //The current matrix is the
            //projection matrix, modelview matrix, or texture matrix,
            //determined by the current matrix mode (now is ModelView mode)
            GL.glLoadMatrixd(AccumulatedRotationsTraslations); //Global Matrix

            //The GL.glMultMatrix function multiplies the current matrix by
            //the one specified in its argument.
            //That is, if M is the current matrix and T is the matrix passed to
            //GL.glMultMatrix, then M is replaced with M • T
            GL.glMultMatrixd(CurrentRotationTraslation);

            //save the matrix product in AccumulatedRotationsTraslations
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, AccumulatedRotationsTraslations);

            //replace ModelViev Matrix with stored ModelVievMatrixBeforeSpecificTransforms
            GL.glLoadMatrixd(ModelVievMatrixBeforeSpecificTransforms);
            //multiply it by KeyCode defined AccumulatedRotationsTraslations matrix
            GL.glMultMatrixd(AccumulatedRotationsTraslations);

            //DrawAxes();
            
            DrawFigures();
            //GL.glFlush();
            //WGL.wglSwapBuffers(m_uint_DC);
            //REFLECTION b    	
            intOptionB += 10; //for rotation
            intOptionC += 2; //for rotation
            // without REFLECTION was only DrawAll(); 
            // now

            GL.glEnable(GL.GL_BLEND);
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);

           
            DrawCube(true);
            //only floor, draw only to STENCIL buffer
            GL.glEnable(GL.GL_STENCIL_TEST);
            GL.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xFFFFFFFF); // draw floor always
            GL.glColorMask((byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE, (byte)GL.GL_FALSE);
            GL.glDisable(GL.GL_DEPTH_TEST);
          
            DrawFloor();

            // restore regular settings
            GL.glColorMask((byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE, (byte)GL.GL_TRUE);
            GL.glEnable(GL.GL_DEPTH_TEST);

            // reflection is drawn only where STENCIL buffer value equal to 1
            GL.glStencilFunc(GL.GL_EQUAL, 1, 0xFFFFFFFF);
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);

            GL.glEnable(GL.GL_STENCIL_TEST);

            // draw reflected scene
            GL.glPushMatrix();
            GL.glScalef(1, 1, -1); //swap on Z axis
            GL.glEnable(GL.GL_CULL_FACE);
            GL.glCullFace(GL.GL_BACK);
            DrawFigures2();
            GL.glCullFace(GL.GL_FRONT);
            DrawFigures2();
            GL.glDisable(GL.GL_CULL_FACE);
            GL.glPopMatrix();


            
            // really draw floor 
            //( half-transparent ( see its color's alpha byte)))
            // in order to see reflected objects 
            GL.glDepthMask((byte)GL.GL_FALSE);
          
            DrawFloor();
            GL.glDepthMask((byte)GL.GL_TRUE);
            // Disable GL.GL_STENCIL_TEST to show All, else it will be cut on GL.GL_STENCIL
            GL.glDisable(GL.GL_STENCIL_TEST);
            DrawFigures2();
            GL.glFlush();

            WGL.wglSwapBuffers(m_uint_DC);

        }

        protected virtual void InitializeGL()
        {
            m_uint_HWND = (uint)p.Handle.ToInt32();
            m_uint_DC = WGL.GetDC(m_uint_HWND);

            // Not doing the following WGL.wglSwapBuffers() on the DC will
            // result in a failure to subsequently create the RC.
            WGL.wglSwapBuffers(m_uint_DC);

            WGL.PIXELFORMATDESCRIPTOR pfd = new WGL.PIXELFORMATDESCRIPTOR();
            WGL.ZeroPixelDescriptor(ref pfd);
            pfd.nVersion = 1;
            pfd.dwFlags = (WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_SUPPORT_OPENGL | WGL.PFD_DOUBLEBUFFER | GL.GL_STENCIL_BUFFER_BIT);
            pfd.iPixelType = (byte)(WGL.PFD_TYPE_RGBA);
            pfd.cColorBits = 32;
            pfd.cDepthBits = 32;
            pfd.iLayerType = (byte)(WGL.PFD_MAIN_PLANE);

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //for Stencil support 

            pfd.cStencilBits = 32;

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            int pixelFormatIndex = 0;
            pixelFormatIndex = WGL.ChoosePixelFormat(m_uint_DC, ref pfd);
            if (pixelFormatIndex == 0)
            {
                MessageBox.Show("Unable to retrieve pixel format");
                return;
            }

            if (WGL.SetPixelFormat(m_uint_DC, pixelFormatIndex, ref pfd) == 0)
            {
                MessageBox.Show("Unable to set pixel format");
                return;
            }
            //Create rendering context
            m_uint_RC = WGL.wglCreateContext(m_uint_DC);
            if (m_uint_RC == 0)
            {
                MessageBox.Show("Unable to get rendering context");
                return;
            }
            if (WGL.wglMakeCurrent(m_uint_DC, m_uint_RC) == 0)
            {
                MessageBox.Show("Unable to make rendering context current");
                return;
            }


            initRenderingGL();
        }

        public void OnResize()
        {
            Width = p.Width;
            Height = p.Height;
            GL.glViewport(0, 0, Width, Height);
            Draw();
        }

        protected virtual void initRenderingGL()
        {
            if (m_uint_DC == 0 || m_uint_RC == 0)
                return;
            if (this.Width == 0 || this.Height == 0)
                return;

            GL.glShadeModel(GL.GL_SMOOTH);
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);
            GL.glClearDepth(1.0f);


            GL.glEnable(GL.GL_LIGHT0);
            GL.glEnable(GL.GL_COLOR_MATERIAL);
            GL.glColorMaterial(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT_AND_DIFFUSE);

            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LEQUAL);
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_Hint, GL.GL_NICEST);


            GL.glViewport(0, 0, this.Width, this.Height);
            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();

            //nice 3D
            GLU.gluPerspective(45.0, 1.0, 0.4, 100.0);


            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();

            //save the current MODELVIEW Matrix (now it is Identity)
            GL.glGetDoublev(GL.GL_MODELVIEW_MATRIX, AccumulatedRotationsTraslations);
        }
    }
}


