namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a Batman room, where the hero encounters Batman.
    /// </summary>
    public class BatmanRoom : Room
    {
        static BatmanRoom()
        {
            RoomFactory.Instance.Register(RoomType.BatmanRoom, () => new BatmanRoom());
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

                // Custom behavior for the Batman room
                if (hero.HasGadget)
                {
                    ConsoleHelper.WriteLine("You already have a gadget. Batman nods approvingly and disappears into the shadows.", ConsoleColor.DarkBlue);
                }
                else
                {
                    hero.HasGadget = true;
                    ConsoleHelper.WriteLine("You receive the gadget from Batman. It's a versatile tool that can help you overcome various challenges. You feel empowered and ready to continue your quest.", ConsoleColor.DarkBlue);
                }

                IsActive = false;
            }
        }

        /// <inheritdoc/>
        public override DisplayDetails Display()
        {
            return IsActive ? new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.DarkBlue)
                            : base.Display();
        }

        /// <summary>
        /// Displays sensory information about the Batman room, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the Batman room.</param>
        /// <param name="heroDistance">The distance between the hero and the Batman room.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (!IsActive)
            {
                if (base.DisplaySense(hero, heroDistance))
                {
                    return true;
                }
                if (heroDistance == 0)
                {
                    ConsoleHelper.WriteLine("You recall the encounter with Batman in the room, feeling inspired by his presence.", ConsoleColor.DarkGray);
                    return true;
                }
            }
            else if (heroDistance == 1 || heroDistance == 2)
            {
                ConsoleHelper.WriteLine(heroDistance == 1 ? "A faint bat-like scent fills the air, hinting at something mysterious nearby." : "You hear the faint sound of a cape rustling and whispers of justice in the shadows.", ConsoleColor.DarkBlue);
                return true;
            }
            return false;
        }
    }
}