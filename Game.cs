// Include code libraries you need below (use the namespace).
using Game10003;
using Microsoft.VisualBasic.FileIO;
using Raylib_cs;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Color DarkBlue = new Color(8, 0, 94, 255);
        Color Svelt = new Color(22, 14, 0, 255);
        Color orange = new Color(255, 171, 46, 255);
        Color Pink = new Color(255, 195, 233, 255);
        Color StoneGrey = new Color(38, 51, 51, 200);

        float[] xCoordinates = [];
        float stalagmiteSize = 50;
        float stalactiteSize = 50;

        int currentwingposition = 1;
        public void Setup()
        {
            Window.SetTitle("Flappy bat");
            Window.SetSize(400, 400);
            Window.TargetFPS = 60;

            int count = 25;
            xCoordinates = new float[count];
            for (int i = 0; i < count; i++)
            {
                xCoordinates[i] = Random.Integer(10, 390);
            }
        }
        //Draw bat body without wing tips
        void DrawBatBody()
        {
            //ears
            Draw.FillColor = Svelt;
            Draw.Triangle(180, 100, 190, 160, 140, 140);
            Draw.Triangle(220, 100, 210, 150, 260, 140);
            Draw.FillColor = Pink;

            //head
            Draw.FillColor = Svelt;
            Draw.LineColor = Color.Black;
            Draw.Capsule(160, 160, 240, 160, 30);
            //body
            Draw.FillColor = Svelt;
            Draw.Capsule(200, 185, 200, 250, 30);

            //eyes
            Draw.FillColor = Color.OffWhite;
            Draw.Circle(225, 145, 5);
            Draw.Circle(185, 145, 5);

            //mouth
            Draw.FillColor = Pink;
            Draw.Capsule(185, 170, 230, 170, 5);
            Draw.FillColor = Color.White;
            Draw.Triangle(195, 195, 190, 165, 200, 165);
            Draw.Triangle(215, 195, 210, 165, 220, 165);

            //Wings
            Draw.FillColor = Svelt;
            Draw.Triangle(140, 250, 190, 200, 110, 200);
            Draw.Triangle(250, 250, 220, 200, 280, 200);

        }
        public void Update()
        {
            Window.ClearBackground(orange);
            DrawBatBody();

            // Stalactites&Stalagmites
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                Draw.FillColor = StoneGrey;
                Draw.Triangle(xCoordinates[i], 400, xCoordinates[i] + 10, 400, xCoordinates[i] + (10 / 2), 400 - stalactiteSize - Random.Integer(0, 10));
                Draw.Triangle(xCoordinates[i], 0, xCoordinates[i] + 10, 0, xCoordinates[i] + (10 / 2), stalactiteSize + Random.Integer(0, 10));
            }
            // draws wing tips in neutral position
            if (currentwingposition == 0)
            {
                //wing tip neutral
                Draw.FillColor = Svelt;
                Draw.Triangle(290, 250, 320, 200, 260, 200);
                Draw.Triangle(90, 250, 60, 200, 150, 200);

            }
            //draws wing tips in up poisition
            else if (currentwingposition == 1)
            {
                //wing tip up
                Draw.FillColor = Svelt;
                Draw.Triangle(80, 240, 60, 170, 150, 200);
                Draw.Triangle(300, 240, 320, 180, 260, 200);
            }
            //draws wing tips in down position
            else if (currentwingposition == 2)
            {
                //wing tip down
                Draw.FillColor = Svelt;
                Draw.Triangle(100, 270, 160, 200, 50, 220);
                Draw.Triangle(280, 260, 320, 220, 260, 200);
            }
            //Check if the Space key has been pressed this frame
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                currentwingposition = Random.Integer(0, 3);
                Console.WriteLine($"{currentwingposition}");
            }
        }
    }
}







