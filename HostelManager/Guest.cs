namespace HostelManager
{
    public class Guest
    {
        private string _name;
        private int _age;
        private bool _isStudent;
        private int _balance;
        private int _nightsStayed;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 16 && value < 99)
                {
                    _age = value;
                }
                else
                {
                    _age = 0;
                }
            }
        }

        public bool IsStudent
        {
            get { return _isStudent; }
            set { _isStudent = value; }
        }

        public int Balance
        {
            get { return _balance; }
        }

        public int NightsStayed
        {
            get { return _nightsStayed; }
        }

        public Guest(string name, int age, bool isStudent)
        {
            Name = name;
            Age = age;
            IsStudent = isStudent;
        }

        public bool Deposit(int amount)
        {
            if (amount == 5000 || amount == 10000 || amount == 20000)
            {
                _balance += amount;
                return true;
            }
            return false;
        }

        public static int StayFee(int nights, bool isStudent)
        {
            if (nights < 1)
            {
                return 0;
            }

            int nightlyRate = 6000;
            if (isStudent)
            {
                nightlyRate = 4000;
            }

            int fee = nights * nightlyRate;
            if (nights >= 7)
            {
                fee = fee * 85 / 100;
            }
            return fee;
        }

        public bool Stay(int nights)
        {
            int fee = StayFee(nights, IsStudent);
            if (nights < 1 || fee > _balance)
            {
                return false;
            }

            _balance -= fee;
            _nightsStayed += nights;
            return true;
        }

        public string GetDescription()
        {
            string ageText = Age + " éves";
            if (Age == 0)
            {
                ageText = "ismeretlen kor";
            }

            string typeText = "teljes árú";
            if (IsStudent)
            {
                typeText = "diák";
            }

            return $"{Name} ({ageText}, {typeText}): {Balance} Ft egyenleg, {NightsStayed} éjszaka";
        }
    }
}
