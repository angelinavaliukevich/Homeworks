using System.Text;

namespace Async
{
    /// <summary>
    /// Информация о кредите
    /// </summary>
    internal class CreditInfo
    {
        /// <summary>
        /// Имя кредитополучателя
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Выплачено по кредиту
        /// </summary>
        public int PaidAmount { get; set; }

        /// <summary>
        /// Осталось выплатить по кредиту
        /// </summary>
        public double LeftToPay { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Имя: {FullName}");
            sb.AppendLine($"Выплачено по кредиту: {PaidAmount}");
            sb.AppendLine($"Остаток по кредиту: {LeftToPay}");

            return sb.ToString();
        }
    }
}
