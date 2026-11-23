namespace HostelManager
{
    public class Hostel
    {
        private string _name;
        private int _capacity;
        private List<Guest> _guests;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Capacity
        {
            get { return _capacity; }
        }

        public List<Guest> Guests
        {
            get { return _guests; }
        }

        public Hostel(string name, int capacity)
        {
            Name = name;
            _capacity = capacity;
            _guests = new List<Guest>();
        }

        public bool AddGuest(Guest guest)
        {
            if (_guests.Count > _capacity)
            {
                return false;
            }

            _guests.Add(guest);
            return true;
        }

        public Guest FindByName(string name)
        {
            foreach (Guest guest in _guests)
            {
                if (guest.Name == name)
                {
                    return guest;
                }
            }
            return null;
        }

        public bool CheckOut(string name)
        {
            Guest guest = FindByName(name);
            if (guest == null)
            {
                return false;
            }

            _guests.Remove(guest);
            return true;
        }

        public int TotalNights()
        {
            int total = 0;
            foreach (Guest guest in _guests)
            {
                total += guest.NightsStayed;
            }
            return total;
        }

        public Guest LongestStay()
        {
            Guest longest = null;
            foreach (Guest guest in _guests)
            {
                if (longest == null || guest.NightsStayed > longest.NightsStayed)
                {
                    longest = guest;
                }
            }
            return longest;
        }
    }
}
