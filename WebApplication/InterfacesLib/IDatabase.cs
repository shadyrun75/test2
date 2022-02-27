namespace InterfacesLib
{
    public interface IDatabase
    {
        /// <summary>
        /// Метод для вставки массива данных в базу данных
        /// </summary>
        /// <param name="data">Массив данных</param>
        public void Insert(IEnumerable<IMainModel> data);
        /// <summary>
        /// Метод для выборки массива данных
        /// </summary>
        /// <param name="offset">Смещение по выборке</param>
        /// <param name="count">Количество записей для выборки</param>
        /// <param name="code">Поле код для фильтрации</param>
        /// <param name="value">Поле значение для фильтрации</param>
        /// <returns>Массив данных</returns>
        public IEnumerable<IDatabaseMainModel> Select(ref int totalcount, int? offset, int? count, int? code, string? value);
        /// <summary>
        /// Очистка данных в базе данных
        /// </summary>
        public void Clear();
    }
}
