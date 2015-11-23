using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Game
    {
        public Game()
        {
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        public GameStateType    GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid RedUserId { get; set; }

        public virtual User RedUser { get; set; }

        public Guid BlueUserId { get; set; }

        public virtual User BlueUser { get; set; }
    }
}
