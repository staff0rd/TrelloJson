using System.Collections.Generic;

namespace TrelloJson
{
    class List
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Closed { get; set; }
        public string IdBoard { get; set; }
        public string Pos { get; set; }
        public string Subscribed { get; set; }
        public List<Card> Cards { get; set; }

        public List()
        {
            Cards = new List<Card>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}