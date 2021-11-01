using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    /// <summary>
    /// Класс эмулирующий работу с источником данных.
    /// Этот класс не должен меняться!
    /// </summary>
    internal class FakeDB
    {
        /// <summary>
        /// Возвращает переданные ему данные спустя интервал времени
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="data">Данные которые класс вернет</param>
        /// <returns>Данные переданные в метод</returns>
        public static async ValueTask<T>  GetData<T>(T data)
        {
            await Task.Run(() => Thread.Sleep(1000));
            return data;
        }
    }
}
