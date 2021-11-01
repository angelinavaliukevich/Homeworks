using System;
using System.Threading.Tasks;

namespace Async
{
    internal class CreditCalculator
    {
        private readonly Repository repository = new Repository();

        public static async ValueTask<CreditInfo> Calculate()
        {
            int clientId = await Repository.GetClientId();
            string firstName = await Repository.GetFirstName(clientId);
            string lastName = await Repository.GetLastName(clientId);
            long creditId = await Repository.GetCreditId(clientId);

            DateTime dateOfCredit = await Repository.GetDateOfCredit(creditId);
            int creditAmount = await Repository.GetCreditAmount(creditId);
            int monthlyRate = await Repository.GetMonthlyRate(creditId);
            int monthlyPayment = await Repository.GetMonthlyPayment(creditId);
            int creditTerm = await Repository.GetCreditTerm(creditId);

            // Вычисляем количество месяцев с получения кредита
            int months = 12 * (DateTime.Now.Year - dateOfCredit.Year) + DateTime.Now.Month - dateOfCredit.Month;

            // Вычисляем уже выплаченную сумму
            int paidAmount = months * monthlyPayment;

            // Вычисляем общую сумму платежа по процентам
            double interestCharges = creditAmount * monthlyRate / 100 * creditTerm;

            return new CreditInfo
            {
                FullName = $"{firstName} {lastName}",
                PaidAmount = paidAmount,
                LeftToPay = creditAmount + interestCharges - paidAmount
            };
        }
    }
}
