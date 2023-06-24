using System.Transactions;

namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a Slimy gel monster in the game.
    /// </summary>
    public class GelatinousCube : Monster, IMoveable
    {
        private Location _location;
        public GelatinousCube(Location location)
        {
            _location = location;
        }
        public Location GetLocation()
        {
            return _location;
        }
        public override void Activate(Hero hero, Map map)
        {

            ConsoleHelper.WriteLine("Oh! ladies and gentlemen The movement you've all been waiting for The most diabolic hero in the world SLIM SHADY!", ConsoleColor.Red);
            hero.Kill("The king of undergound rap have distroyed you!!!");
        }
        public void Move(Hero hero, Map map)
        {
            var potentialLocation = new Location(_location.Row + 1, _location.Column);
            //If potentialLocation is valid(on map & room at the location is inactive)
            if (potentialLocation.Row < map.Rows && !map.GetRoomAtLocation(potentialLocation).IsActive)
            {
                //then do this ,otherwise do nothing 
                /*map.GetRoomAtLocation(_location).RemoveMonster();
                _location = new Location(_location.Row + 1, _location.Column);
                map.GetRoomAtLocation(_location).AddMonster(this);*/
                _location = potentialLocation;
                map.GetRoomAtLocation(potentialLocation).AddMonster(this);
            }
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