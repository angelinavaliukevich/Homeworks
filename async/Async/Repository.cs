using System;
using System.Threading.Tasks;

namespace Async
{
    internal class Repository
    {
        private static readonly FakeDB db = new FakeDB();

        /// <summary>
        /// Возвращает Id клиента
        /// </summary>
        public static async Task<int> GetClientId()
        {
            return await FakeDB.GetData(1);
        }

        /// <summary>
        /// Возвращает имя
        /// </summary>
        public static async Task<string>  GetFirstName(int clientId)
        {
            return await FakeDB.GetData("Tom");
        }

        /// <summary>
        /// Возвращает фамилию
        /// </summary>
        public static async Task<string> GetLastName(int clientId)
        {
            return await FakeDB.GetData("Cruise");
        }

        /// <summary>
        /// Возвращает Id кредита
        /// </summary>
        public static async Task<long> GetCreditId(int clientId)
        {
            return await FakeDB.GetData(12345678987654321);
        }

        /// <summary>
        /// Возвращает дату получения кредита
        /// </summary>
        public static async Task<DateTime> GetDateOfCredit(long creditId)
        {
            return await FakeDB.GetData(new DateTime(2020, 05, 01));
        }

        /// <summary>
        /// Возвращает сумму кредита
        /// </summary>
        public static async Task<int> GetCreditAmount(long creditId)
        {
            return await FakeDB.GetData(94000);
        }

        /// <summary>
        /// Возвращает ежемесячный процент по кредиту
        /// </summary>
        public static async Task<int> GetMonthlyRate(long creditId)
        {
            return await FakeDB.GetData(2);
        }

        /// <summary>
        /// Возвращает ежемесячный платеж по кредиту
        /// </summary>
        public static async Task<int> GetMonthlyPayment(long creditId)
        {
            return await FakeDB.GetData(4000);
        }

        /// <summary>
        /// Возвращает срок кредита
        /// </summary>
        public static async Task<int> GetCreditTerm(long creditId)
        {
            return await FakeDB.GetData(24);
        }
    }
}
