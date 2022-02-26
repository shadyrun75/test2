namespace InterfacesLib
{
    /// <summary>
    /// Основная модель данных
    /// </summary>
    public interface IMainModel
    {
        /// <summary>
        /// Код модели
        /// </summary>
        public Int32 Code { get; set; }
        /// <summary>
        /// Текстовое значение модели
        /// </summary>
        public string Value { get; set; }
    }
}
