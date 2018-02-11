using Syph_V02.Core.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Models
{
    /// <summary>
    /// Implementation of this class is not full !! It's for DEMO V02
    /// </summary>
    public class Player : IPlayer
    {       
        private string name;
        private int id;
        private int souls;
        private bool isAlive;
        private IList<ISpawn> inventory;
        private IList<IPlayer> team;

        public Player(string name, int id, IList<IPlayer> team)
        {
            this.name = name;
            this.id = id;
            this.souls = 8000;
            this.team = team;
            this.inventory = new List<ISpawn>();

            this.isAlive = true;
        }

        public string Name =>  this.name;

        public int ID => this.id;

        public int Souls => this.souls;

        public bool IsAlive => this.isAlive;

        public IList<ISpawn> Inventory => this.inventory;

        public IList<IPlayer> Team => this.team;

        public void TakeDamage(int d)
        {
            this.souls -= d;

            if (this.Souls <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            this.isAlive = false;
        }

        public void Surrender()
        {
            this.isAlive = false;
        }

        public void Summon(ISpawn spawn)
        {
            throw new NotImplementedException();
        }

        public void ListInventory()
        {
            throw new NotImplementedException();
        }
    }
    //public delegate void PlayerJoin();

    //public class Player : Entity, IPlayer
    //{
    //    private IList<ISpawn> playerInventory;
    //    private Dictionary<SpawnRank, int> spawns;
    //    private IList<IPlayer> team;
    //    private int id;
    //    private bool isAlive;

    //    public Player(string name, int id, IList<IPlayer> team)
    //        : base(name, 8000, EntityType.Player)
    //    {
    //        this.id = id;
    //        this.team = team;
    //        this.playerInventory = new List<ISpawn>();
    //        this.isAlive = true;
    //        this.PlayerJoin += new PlayerJoin(WelcomeUser);

    //        this.spawns = new Dictionary<SpawnRank, int>
    //        {
    //            { SpawnRank.Junior, 7},
    //            { SpawnRank.Regular, 5},
    //            { SpawnRank.Senior, 3}
    //        };

    //        PlayerJoin();
    //    }

    //    public IList<ISpawn> Inventory => this.playerInventory;

    //    public int ID => this.id;

    //    public bool IsAlive => this.isAlive;

    //    public IList<IPlayer> Team => this.team;

    //    event PlayerJoin PlayerJoin;

    //    public void WelcomeUser()
    //    {
    //        FileLogger.Log($"Player {this.Name} with ID {this.id} entered the game.");
    //    }

    //    public void TakeDamage(int d)
    //    {
    //        this.Souls -= d;

    //        FileLogger.Log($" -- Player {this.Name} takes {d} damage");

    //        if (this.Souls <= 0)
    //        {
    //            Die();
    //        }
    //    }

    //    public void Die()
    //    {
    //        FileLogger.Log($" -- Player {this.Name} died.");

    //        this.isAlive = false;
    //    }

    //    public void Surrender()
    //    {
    //        FileLogger.Log($" -- Player {this.Name} surrendered.");

    //        this.isAlive = false;
    //    }

    //    public void Summon(ISpawn spawn)
    //    {
    //        if (this.spawns[spawn.Rank] <= 0)
    //        {
    //            throw new SpawnInventoryFullException("A Player cannot have more than 7 Junior, 5 Regular or 3 Senior Spawns!");
    //        }

    //        this.playerInventory.Add(spawn);

    //        this.spawns[spawn.Rank]--;

    //        FileLogger.Log($" -- Player {this.Name} has summoned {spawn.Rank} {spawn.Type} {spawn.Name}!");
    //    }

    //    public void ListInventory()
    //    {
    //        if (this.Inventory.Count == 0)
    //        {
    //            Console.WriteLine($"Player {this.Name}'s inventory is empty!");
    //            return;
    //        }

    //        ConsoleLogger.Print($"Player {this.Name}'s inventory:");
    //        foreach (ISpawn spawn in Inventory.OrderBy(x => x.Rank))
    //        {
    //            ConsoleLogger.Print($" - {spawn.Stats()}");
    //        }
    //    }
    //}
}
