namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a Batman room, where the hero encounters Batman.
    /// </summary>
    public class BatmanRoom : Room
    {
        static BatmanRoom()
        {
            RoomFactory.Instance.Register(RoomType.Batman, () => new BatmanRoom());
        }

        /// <inheritdoc/>
        public override RoomType Type { get; } = RoomType.Batman;

        /// <inheritdoc/>
        public override bool IsActive { get; protected set; } = true;

        /// <summary>
        /// The hero encounters Batman is in the room.
        /// </summary>
        public override void Activate(Hero hero, Map map)
        {
            if (IsActive)
            {
                ConsoleHelper.WriteLine("You step into a dimly lit room, and a figure emerges from the shadows. It's Batman, the Dark Knight himself!", ConsoleColor.DarkBlue);
                ConsoleHelper.WriteLine("Batman turns to you and says, 'I see you're on a dangerous quest. Take this.' He hands you a powerful gadget that will aid you in your journey.", ConsoleColor.DarkBlue);
                
                // TODO: Add custom behavior for the Batman room

                IsActive = false;
            }
        }

        // Rest of the class remains the same...

        // ...
    }
}
