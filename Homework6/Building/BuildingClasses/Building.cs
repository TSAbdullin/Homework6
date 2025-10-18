namespace Tumakov.Building.BuildingClasses
{
    class Building
    {
        private long _id; // идентификатор здания
        private ushort _height; // высота здания
        private byte _amountOfFloors; // количество этажей
        private ushort _amountOfFlats; // количество квартир
        private byte _amountOfEntrances; // количество подъездов
        private static long _idCounter = 1;

        public Building(ushort height, byte amountOfFloors, ushort amountOfFlats, byte amountOfEntrances)
        {
            _id = _idCounter++;
            _height = height;
            _amountOfFloors = amountOfFloors;
            _amountOfFlats = amountOfFlats;
            _amountOfEntrances = amountOfEntrances;
        }

        public ushort CalculateHeightOfFloor() // ushort использовал, потому что максимальная высота этажа в мире - 828 (Бурдж-Халифа)
        {
            return (byte)(_height / _amountOfFloors);
        }

        public ushort CalculateAmountOfFlatsInEntrance() // количество квартир в подъезде
        {
            return (ushort)(_amountOfFlats / _amountOfEntrances);
        }

        public byte CalculateAmountOfFlatsInFloors() // количество квартир на этаже
        {
            return (byte)(CalculateAmountOfFlatsInEntrance() /  _amountOfFloors);
        }

        // геттеры 
        public long getId() { return _id; } // получаем идентификатор
        public int getHeight() { return _height; } // получаем высоту
        public byte getAmountOfFloors() { return _amountOfFloors; } // получаем количество этажей
        public ushort getAmountOfFlats() { return _amountOfFlats; } // получаем количество квартир
        public byte getAmountOfEntrances() { return _amountOfEntrances; } // получаем количество подъездов
    }
}
