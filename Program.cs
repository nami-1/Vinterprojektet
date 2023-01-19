using Raylib_cs;

Raylib.InitWindow(800, 600, "Space Cadet");
Raylib.SetTargetFPS(60);

Random generetor = new Random(); 

Texture2D avatarImage = Raylib.LoadTexture ("santa.png");
Texture2D startmenu = Raylib.LoadTexture("officialwallpaper.png");
Texture2D backgrounda = Raylib.LoadTexture("backgroundo.png");
Texture2D meteor = Raylib.LoadTexture("finalmeteor.png");
Texture2D meteor2 = Raylib.LoadTexture("finalmeteor.png");



Rectangle accplayer = new Rectangle(400, 420, avatarImage.width, avatarImage.height);
Rectangle target = new Rectangle(100,100, meteor.width, meteor.height);
Rectangle target2 = new Rectangle(500,100, meteor.width, meteor.height);

float speed = 7;

string currentScene = "start"; 

while (Raylib.WindowShouldClose() == false)
{
    //logik
    if (currentScene == "game") { 



    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {

        accplayer.x += speed;
    }

    else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
        accplayer.x -= speed;
    }

     
     if (accplayer.x > 820) {
        accplayer.x = 0;
     }

     else if (accplayer.x < -1) {
        accplayer.x = 790;
     }

     if(Raylib.CheckCollisionRecs (accplayer,target)) {
        currentScene = "end";
     }

     if(Raylib.CheckCollisionRecs (accplayer,target2)) {
        currentScene = "end";
     }


     target.y += 5;

     if (target.y == 450) {
        target.y =100;
        target.x = generetor.Next(800);
     }

     target2.y += 5;

     if (target2.y == 450) {
        target2.y =100;
        target2.x = generetor.Next(800);
     }


    

    }

    
    if (currentScene == "end") {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)) {
            currentScene = "game";
            accplayer.x = 400;
            accplayer.y = 420;
        }

        else if  (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
            currentScene = "start";
        }

    }
    
    else if (currentScene == "start") {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)) {
            currentScene = "game";
        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_Q)) {
            currentScene = "instructions";
        }
    }

    else if (currentScene == "instructions") {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
            currentScene = "start";
        }
    }

 



    //grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "game"){
    Raylib.DrawTexture(backgrounda, 0, 0, Color.WHITE);
    Raylib.DrawTexture(avatarImage, (int)accplayer.x, (int)accplayer.y, Color.WHITE);
    Raylib.DrawTexture(meteor, (int)target.x, (int)target.y, Color.WHITE);
    Raylib.DrawTexture(meteor2, (int)target2.x, (int)target2.y, Color.WHITE);
    
    }
     
     else if (currentScene == "start") {
        Raylib.DrawTexture(startmenu, 0, 0, Color.WHITE);
        Raylib.DrawText("Welcome to Space Cadet (Watchout)", 40, 100, 40, Color.RED);
        Raylib.DrawText("Press ENTER to start or Q to instructions", 40, 180, 33, Color.RED);
     }

     else if (currentScene == "end"){
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("Santa died becase of you!", 40, 150, 25, Color.RED );
        Raylib.DrawText("GAME OVER PRESS ENTER TO PLAY AGAIN", 40, 100, 25, Color.RED );
        Raylib.DrawText("PRESS SPACE TO GO BACK TO THE START SCREEN", 40, 200, 25, Color.RED );

     }

     else if (currentScene == "instructions") {
        Raylib.DrawTexture(startmenu, 0, 0, Color.WHITE);
        Raylib.DrawText("Move to left and right with A & D and avoid the falling meteors", 40, 100, 25, Color.RED);
        Raylib.DrawText("Press Space to go back to the start screen", 40, 150, 25, Color.RED);
     }
    Raylib.EndDrawing();
} 