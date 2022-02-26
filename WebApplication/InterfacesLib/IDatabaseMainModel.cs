namespace InterfacesLib
{
    /// <summary>
    /// Модель для базы данных для основной модели данных
    /// </summary>
    public interface IDatabaseMainModel : IMainModel
    {
        /// <summary>
        /// Идентификатор основной модели в базе данных
        /// </summary>
        public long Id { get; }
        public Int32 Code { get; set; }
        public string Value { get; set; }

        // Какой-то баг словил, при котором сериализация в JSON срабатывает некорректно,
        // т.е. в объектах наследуемых от типа IDatabaseMainModel выводится только поле Id,
        // хотя данные подгружаются корректно.

    }
}
