using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace JA.Classes
{
    public enum Country
    {
        [Description("Россия")]
        russia,

        [Description("Соединённые Штаты Америки")]
        usa,

        [Description("Германия")]
        germany,

        [Description("Франция")]
        france,

        [Description("Китай")]
        china,

        [Description("Япония")]
        japan,

        [Description("Великобритания")]
        UK,

        [Description("Канада")]
        canada,

        [Description("Бразилия")]
        brazil,

        [Description("Австралия")]
        australia,

        [Description("Буларусь")]
        belarus,

        [Description("Украина")]
        ukraine,
        
        [Description("Другая")]
        others
    }
}
