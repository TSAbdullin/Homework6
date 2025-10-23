using Tumakov.Bank.BankClasses;
using Tumakov.Bank.BankEnums;
using Tumakov.Building.BuildingClasses;

namespace Homework6
{
    class Start
    {
        public static void Main(string[] args)
        {
            /////////////////////////////////
            Console.WriteLine("Упражнение 7.1 Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип\r\nбанковского счета " +
                "(использовать перечислимый тип из упр. 3.1). Предусмотреть методы для\r\nдоступа к данным – заполнения и чтения. " +
                "Создать объект класса, заполнить его поля и\r\nвывести информацию об объекте класса на печать.\n");

            BankAccount1 bankAccount1 = new BankAccount1("124124123", 230000m, TypeOfBankAccount.Текущий);
            Console.WriteLine($"Тип счета: {bankAccount1.getTypeOfBankAccount()}\nНомер счета: {bankAccount1.getAccountNumber()}\nБаланс: {bankAccount1.getBalance()}\n");
            /////////////////////////////////

            /////////////////////////////////
            Console.WriteLine("Упражнение 7.2 Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы\r\nномер счета генерировался сам и " +
                "был уникальным. Для этого надо создать в классе\r\nстатическую переменную и метод, который увеличивает значение этого переменной.\n");

            BankAccount2 bankAccount2_1 = new BankAccount2(1230000, TypeOfBankAccount.Текущий);
            BankAccount2 bankAccount2_3 = new BankAccount2(1241234, TypeOfBankAccount.Сберегательный);
            BankAccount2 bankAccount2_4 = new BankAccount2(1230523000, TypeOfBankAccount.Текущий);

            Console.WriteLine($"Тип счета: {bankAccount2_1.getTypeOfBankAccount()}\nНомер счета: {bankAccount2_1.getAccountNumber()}\nБаланс: {bankAccount2_1.getBalance()}\n");
            Console.WriteLine($"Тип счета: {bankAccount2_3.getTypeOfBankAccount()}\nНомер счета: {bankAccount2_3.getAccountNumber()}\nБаланс: {bankAccount2_3.getBalance()}\n");
            Console.WriteLine($"Тип счета: {bankAccount2_4.getTypeOfBankAccount()}\nНомер счета: {bankAccount2_4.getAccountNumber()}\nБаланс: {bankAccount2_4.getBalance()}\n");
            /////////////////////////////////

            /////////////////////////////////
            Console.WriteLine("Упражнение 7.3 Добавить в класс счет в банке два метода: снять со счета и положить на\r\nсчет. Метод снять со счета проверяет, " +
                "возможно ли снять запрашиваемую сумму, и в случае\r\nположительного результата изменяет баланс.\n");

            BankAccount3 bankAccount3_1= new BankAccount3(1230000, TypeOfBankAccount.Текущий);
            BankAccount3 bankAccount3_2 = new BankAccount3(1230000, TypeOfBankAccount.Текущий);
            BankAccount3 bankAccount3_3 = new BankAccount3(1230000, TypeOfBankAccount.Текущий);

            try
            {
                bankAccount3_1.Withdraw(1000);
                bankAccount3_1.RefillBalance(-1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            /////////////////////////////////

            /////////////////////////////////
            Console.WriteLine("Домашнее задание 7.1 Реализовать класс для описания здания (уникальный номер здания,\r\nвысота, этажность, количество квартир, подъездов)." +
                " Поля сделать закрытыми,\r\nпредусмотреть методы для заполнения полей и получения значений полей для печати.\r\nДобавить методы вычисления высоты этажа, " +
                "количества квартир в подъезде, количества\r\nквартир на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания\r\nгенерировался программно." +
                " Для этого в классе предусмотреть статическое поле, которое бы\r\nхранило последний использованный номер здания, и предусмотреть метод, который\r\nувеличивал " +
                "бы значение этого поля.\n");

            Building building = new Building(30, 10, 160, 4);
            Building building2 = new Building(40, 10, 160, 4);


            Console.WriteLine($"ID: {building.getId()}\nВысота этажа: {building.CalculateHeightOfFloor()}\nКоличество квартир в подъезде: {building.CalculateAmountOfFlatsInEntrance()}\nКоличество квартир на этаже: {building.CalculateAmountOfFlatsInFloors()}\n");
            Console.WriteLine($"ID: {building2.getId()}\nВысота этажа: {building2.CalculateHeightOfFloor()}\nКоличество квартир в подъезде: {building2.CalculateAmountOfFlatsInEntrance()}\nКоличество квартир на этаже: {building2.CalculateAmountOfFlatsInFloors()}\n");

            /////////////////////////////////
        }
    }
}