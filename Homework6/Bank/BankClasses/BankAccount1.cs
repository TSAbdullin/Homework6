using Tumakov.Bank.BankEnums;

namespace Tumakov.Bank.BankClasses
{
    class BankAccount1 // Упражнение 7.1
    {
        private string _accountNumber; // поле для номера счета, сделал строкой, т.к. оно может быть длинным и чтобы не мудрить с long, по сути сделал через строку потому что с ним никаких арифм. операций делать не надо, только сравнивать
        private decimal _balance; // баланс
        private TypeOfBankAccount _typeOfBankAccount; // тип счета

        public BankAccount1(string accountNumber, decimal balance, TypeOfBankAccount typeOfBankAccount)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _typeOfBankAccount = typeOfBankAccount;
        }

        // геттеры и сеттеры
        public void setAccountNumber(string accountNumber)
        {
        _accountNumber = accountNumber; // сеттер для номера счета, как будто бы тоже не нужен, но на всякий случай сделал, т.к. может все-таки кто-то его поменять захочет через банк ы
        }
        public string getAccountNumber() {  return _accountNumber; } // геттер для номера счета

        public decimal getBalance() { return _balance; } // для баланса только геттер, потому что я не вижу смысла в сеттере для баланса, это странно было бы

        public TypeOfBankAccount getTypeOfBankAccount() { return _typeOfBankAccount; } // геттер для типа счета
        public void setTypeOfBankAccount(TypeOfBankAccount typeOfBankAccount) // сеттер для типа счета
        {
            _typeOfBankAccount = typeOfBankAccount;
        }
    }
}