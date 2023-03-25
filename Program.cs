int credits = 50;

StartLuckDice(ref credits);

static void StartLuckDice(ref int credits) {
    int wager;
    Console.Clear();
    System.Console.WriteLine("Welcome to Lucky Dice!");
    System.Console.WriteLine($"Current Credits: {credits}");
    System.Console.WriteLine("Please enter your wager. *You can only bet what you have with a min of 20 and max of 50*");
    wager = GetWager(credits);
    Console.Clear();
    PlayLuckyDice(ref credits, wager);
    System.Console.WriteLine($"\nNew Credits: {credits}");
}

static int GetWager(int credits) {
    int wager;
    try {
        wager = int.Parse(Console.ReadLine());
    } catch {
        wager = -1;
    }
    while (wager < 20 || wager > 50 || wager > credits) {
        System.Console.WriteLine("Wager is invalid. *You can only bet what you have with a min of 20 and max of 50*");
        try {
        wager = int.Parse(Console.ReadLine());
        } catch {
            wager = -1;
        }
    }
    return wager;
}

static void PlayLuckyDice(ref int credits, int wager) {
    int playerWins = 0;
    int compWins = 0;
    int playerTotal = 0;
    int compTotal = 0;
    int count = 1;
    Random r = new Random();
    while (playerWins < 3 && compWins < 3) {
        System.Console.WriteLine($"Player Wins: {playerWins}, Computer Wins: {compWins}\n");
        while (count < 7 && count > 0) {
            int playerRolled = r.Next(1, 7);
            int compRolled = r.Next(1, 7);
            System.Console.WriteLine($"Roll: {count}, Player: {playerRolled}, Computer: {compRolled}");
            playerTotal += playerRolled;
            compTotal += compRolled;
            count++;
            System.Console.WriteLine("Press ENTER to continue\n");
            Console.ReadKey();
        }
        count = 1;
        System.Console.WriteLine($"Player Total: {playerTotal}, Computer Total: {compTotal}");
        if (playerTotal > compTotal) {
            playerWins++;
            System.Console.WriteLine($"Player rolled higher. Player wins round. Player Wins: {playerWins}, Computer Wins: {compWins}\n");
        } else {
            compWins++;
            System.Console.WriteLine($"Computer rolled higher or tied. Computer wins round. Player Wins: {playerWins}, Computer Wins: {compWins}\n");
        }
        playerTotal = 0;
        compTotal = 0;
        System.Console.WriteLine("Press ENTER to continue");
        Console.ReadKey();
        Console.Clear();
    }
    if (playerWins > compWins) {
        System.Console.WriteLine("You won more rounds than the computer! You double your wager!");
        credits -= wager;
        credits += (wager * 2);
    } else {
        System.Console.WriteLine("You lost more rounds than the computer! You lost your wager :(");
        credits -= wager;
    }
}