namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a Slimy gel monster in the game.
    /// </summary>
    public class GelatinousCube : Monster
    {
        public override void Activate(Hero hero, Map map)
        {

            ConsoleHelper.WriteLine("Excting text", ConsoleColor.Red);
            hero.Kill("You got gooed!!!");
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            return false;
        }

        public override DisplayDetails Display()
        {
            return new DisplayDetails("[C]", ConsoleColor.Green);
        }
    }
}
