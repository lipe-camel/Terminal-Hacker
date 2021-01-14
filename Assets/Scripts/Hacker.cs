using UnityEngine;

public class Hacker : MonoBehaviour
{
    
    // Game configuration data
    string[] level1Passwords = { "feed", "stories", "reels", "post", "like", "follow" };
    string[] level2Passwords = { "upvote", "award", "subreddit", "downvote", "repost", "karma" };
    string[] level3Passwords = { "search", "adversiment", "translate", "enterprise", "marketing", "information" };
    string[] locals = { "Instagram", "reddit", "Google" };

    //Game state
    public int level;
    string playerName;
    enum Screen { PlayerName, MainMeu, Password, Win, Lose };
    Screen currentScreen;
    string password;
    int tries = 3;

    private void Update()
    {

    }

    void Start()
    {
        PlayerNameMenu();
    }

    void OnUserInput(string input)
    {
        if (currentScreen == Screen.PlayerName)
        {
            RunPlayerName(input);
            ShowMainMenu("Ol�, agente ");
        }
        else if (input == "menu")
        {
            ShowMainMenu("Ol�, agente ");
        }
        else if (currentScreen == Screen.MainMeu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunGame(input);
        }
        else if (currentScreen == Screen.Win)
        {
            ShowMainMenu("Parab�ns, agente ");
        }
        else if (currentScreen == Screen.Lose)
        {
            ShowMainMenu("Que pena, agente ");
        }

    }

    void PlayerNameMenu()
    {
        currentScreen = Screen.PlayerName;
        Terminal.WriteLine("Identifique-se:");
    }

    void RunPlayerName(string input)
    {
        if (input == "007")
        {
            playerName = "Bond";
        }
        else if (input == "menu" || input == "Menu")
        {
            playerName = "Engra�adinho";
        }
        else if (input == "tay" || input == "Tay")
        {
            playerName = "Taynaja";
        }

        else
        {
            playerName = input;
        }

    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMeu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting + playerName);
        tries = 3;
        Terminal.WriteLine("Escolha onde quer hackear:");
        Terminal.WriteLine("Pressione 1 para hackear " + locals[0]);
        Terminal.WriteLine("Pressione 2 para hackear " + locals[1]);
        Terminal.WriteLine("Pressione 3 para hackear " + locals[2]);
        Terminal.WriteLine("Digite menu a qualquer momento para\nretornar.");
        Terminal.WriteLine("Digite um n�mero:");
    }

    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");
        if (isValidNumber)
        {
            level = int.Parse(input);
            AskforPassword();
        }
        else if (input == "limpar")
        {
            ShowMainMenu("Ol�, agente ");
        }
        else if (!isValidNumber)
        {
            InvalidNumbers(input);//check for easter eggs
        }
    
    }

    void InvalidNumbers(string input)
    {
        if (input == "filo" || input == "Filo" || input == "fil�" || input == "Fil�")
        {
            Terminal.WriteLine(@"  /^ ^\
 / 0 0 \  au
 V\ Y /V    au
  / - \       au
 /    |
V__) ||");
        }
        else if (input == "leia" || input == "Leia" || input == "l�ia" || input == "L�ia")
        {
            Terminal.WriteLine(@"            /)-_-(\
             (o o)
     .-----__/\o/  AU
    /  __      /     AU
\__/\ /  \_\ |/        AU
     \\     ||
     //     ||
     |\     |\");
        }
        else if (input == "sora" || input == "Sora")
        {
            Terminal.WriteLine(@" fiu     /_
  fiiu  >' )
        ( ( \ 
         ''|\");
        }
        else if (input == "nami" || input == "Nami")
        {
            Terminal.WriteLine(@"  _\       PI
 ( '<  PI      PI
/ ) )       PI
/|''    PI");
        }
        else if (input == "tay" || input == "Tay" || input == "taynara" || input == "Taynara")
        {
            Terminal.WriteLine(@"             ____
            / . .\
            \  ---<
             \  /
   __________/ /
-=:___________/");
        }
        else if (input == "felipe" || input == "Felipe" || input == "Frippy" || input == "frippy" || input == "lipe")
        {
            Terminal.WriteLine(@"   //
 _oo\
(__/ \  _  _
   \  \/ \/ \
   (         )\
    \_______/  \
     [[] [[]
     [[] [[]");
        }
        else if (input == "4 8 15 16 23 42")
        {
            ShowWinMenu();
        }
        else if (input == "69" || input == "420")
        {
            Terminal.WriteLine("nice");
        }
        else if (input == "99vidas ")
        {
            tries = 99;
            Terminal.WriteLine("Agora voc� tem 99 tentativas.");
        }

        else
        {
            Terminal.WriteLine("Digite uma entrada v�lida");
        }

    } //the easter eggs

    void AskforPassword()
    {
        print(level1Passwords.Length);
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Voc� escolheu hackear " + locals[(level - 1)] + ".");
        PasswordRandomizer();
        ShowTries();
    }

    void PasswordRandomizer()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level umber");
                break;
        }
    }

    void ShowTries()
    {
        Terminal.WriteLine("Voc� tem " + tries + " tentativas.\n" +
            "*DICA: " + password.Anagram() + " *" +
            "\nDigite a senha:");
    }

    void RunGame(string input)
    {
        if (input == password)
        {
            ShowWinMenu();
        }
        else
        {
            IncorrectPassword();
        }
    }

    void ShowWinMenu()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("\n\n\n\n"+
                           "======================================\n" +
                           "=           VOC� GANHOU!!!           =\n" +
                           "=     Aperte Enter para retornar     =\n" +
                           "======================================");
    }

    void IncorrectPassword()
    {
        tries = tries - 1;
        Terminal.WriteLine("Senha incorreta");
        if(tries <= 0)
        {
            ShowLoseMenu();
        }
        else
        {
            ShowTries();
        }
    }

    void ShowLoseMenu()
    {
        currentScreen = Screen.Lose;
        Terminal.ClearScreen();
        Terminal.WriteLine("\n\n\n\n" +
                           "======================================\n" +
                           "=           VOC� PERDEU!!!           =\n" +
                           "=     Aperte Enter para retornar     =\n" +
                           "======================================");
    }

}