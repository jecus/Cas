namespace CASTerms
{
    /// <summary>
    /// Перечисления типов сообщений
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Ошибка подключения
        /// </summary>
        ConnectionError = 0,
        /// <summary>
        /// Информация представленая в реестре не сходится с информаций полученой из USB ключа
        /// </summary>
        LicenseInformationNotEqual = 1,
        /// <summary>
        /// Отсутсвие USB ключа
        /// </summary>
        USBKeyAbsence = 2,
        /// <summary>
        /// Не верный USB Ключ
        /// </summary>
        USBKeyNotValid = 3,
        /// <summary>
        /// Истечение срока действия лицензии
        /// </summary>
        LicenseExpired = 4,
        /// <summary>
        /// Не задано ограничение по Expires
        /// </summary>
        LicenseExpiresNULL = 5,
        /// <summary>
        /// Файл лицензии не найден
        /// </summary>
        LicenseNotFound = 6,
        /// <summary>
        /// Ошибка при удалении чего-либо
        /// </summary>
        DeleteError = 7,
        /// <summary>
        /// Ошибка при открытии чего-либо
        /// </summary>
        LoadError = 8,
        /// <summary>
        /// Неверное значение параметра
        /// </summary>
        InvalidValue = 9,
        /// <summary>
        /// Ошибка при сохранении чего-либо
        /// </summary>
        SaveError = 10,
        /// <summary>
        /// Нарушение лицензии
        /// </summary>
        LicenseViolation = 11,

    }
}