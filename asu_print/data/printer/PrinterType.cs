namespace printer.Database
{
    /// <summary/>
    /// Тип принтера
    /// </summary>
    public enum PrinterType
    {
        /// <summary/>
        /// Автоматизированная печатная машинка 
        /// </summary>
        DaisyWheel,

        /// <summary/>
        /// Матричный принтер
        /// </summary>
        DotMatrix,

        /// <summary/>
        /// Струйный принтер
        /// </summary>
        Inkjet,

        /// <summary/>
        /// Лазерный принтер
        /// </summary>
        Laser,

        /// <summary/>
        /// Сублимационный принтер (фотопринтер)
        /// </summary>
        DyeSublimation
    }
}