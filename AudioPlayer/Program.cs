using System.Media;

string directoryName = @"Media\";
// Словарь для хранения звуков и клавиш.
Dictionary<ConsoleKey, string> soundFiles = new()
{
    { ConsoleKey.D, directoryName + "sound_D.wav" },
    { ConsoleKey.F, directoryName + "sound_F.wav" },
    { ConsoleKey.G, directoryName + "sound_G.wav" },
    { ConsoleKey.H, directoryName + "sound_H.wav" },
    { ConsoleKey.J, directoryName + "sound_J.wav" },
    { ConsoleKey.K, directoryName + "sound_K.wav" },
};

Queue<SoundPlayer> soundQueue = new Queue<SoundPlayer>();

Console.WriteLine("Нажите одну из клавиш D F G H J K для проигрывания звука.");
Console.WriteLine("Нажмите ESC для выхода из приложения.");
Console.WriteLine(Environment.CurrentDirectory);

ConsoleKeyInfo consoleKeyInfo;

while (true)
{
    consoleKeyInfo = Console.ReadKey();

    if (consoleKeyInfo.Key == ConsoleKey.Escape)
    {
        break;
    }

    if (soundFiles.ContainsKey(consoleKeyInfo.Key))
    {
        SoundPlayer soundPlayer = new(soundFiles[consoleKeyInfo.Key]);

        soundQueue.Enqueue(soundPlayer);

        PlayNextSound();
    }
}

void PlayNextSound()
{
    if (soundQueue.Count <= 0)
    {
        return;
    }
    SoundPlayer sound = soundQueue.Dequeue();
    sound.PlaySync();
}