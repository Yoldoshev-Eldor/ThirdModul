namespace _3._6dars;

internal class Program
{
    static void Main(string[] args)
    {
        var music = new MusicCrudApiBroker();
        //var id = new Guid("36db3dc9-6ffd-4b26-b74f-1b904e6b8b46");


        //music.UpdateMusic(id);
        music.GetMusicByAuthorname("Sherali Jo'rayev");
    }
}
