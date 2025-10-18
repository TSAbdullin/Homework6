using Tumakov.Bank.BankEnums;

namespace Tumakov.Bank.BankClasses
{
    class BankAccount3
    {
        private long _accountNumber; // поле для номера счета, сделал строкой, т.к. оно может быть длинным и чтобы не мудрить с long, по сути сделал через строку потому что с ним никаких арифм. операций делать не надо, только сравнивать
        private decimal _balance; // баланс
        private TypeOfBankAccount _typeOfBankAccount; // тип счета
        private static long _idCounter = 1;

        public BankAccount3(decimal balance, TypeOfBankAccount typeOfBankAccount)
        {
            _accountNumber = _idCounter++;
            _balance = balance;
            _typeOfBankAccount = typeOfBankAccount;
        }

        public void Withdraw(decimal money) // метод для вывода денег
        {
            if (money <= 0)
            {
                throw new ArgumentException("Сумма не может быть отрицательной!\n");
            }   

            if (_balance >= money)
            {
                _balance -= money;
                Console.WriteLine($"Сумма {money} успешно выведена!\nТекущий баланс: {_balance}\n");
            }
            else
            {
                Console.WriteLine("На балансе недостаточно средств!\n");
            }
        } 

        public void RefillBalance(decimal money) // метод для пополнения баланса
        {
            if (money <= 0)
            {
                throw new ArgumentException("Сумма пополнения не может быть отрицательной!\n");
            }

            _balance += money;
            Console.WriteLine($"Баланс успешно пополнен на {money}\nТекущий баланс: {_balance}\n");
        }

        // геттеры и сеттеры
        public long getAccountNumber() { return _accountNumber; } // геттер для номера счета

        public decimal getBalance() { return _balance; } // для баланса только геттер, потому что я не вижу смысла в сеттере для баланса, это странно было бы

        public TypeOfBankAccount getTypeOfBankAccount() { return _typeOfBankAccount; } // геттер для типа счета
        public void setTypeOfBankAccount(TypeOfBankAccount typeOfBankAccount) // сеттер для типа счета
        {
            _typeOfBankAccount = typeOfBankAccount;
        }
    }
}
