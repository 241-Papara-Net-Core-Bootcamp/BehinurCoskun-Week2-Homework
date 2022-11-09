using System;

namespace PaparaSecondWeek.Extensions.DateTimeExtension
{
    public static class DateTimeExtenions
    {
        /// <summary>
        /// Verilen tarihi gün ay yıl olarak formatlar.
        /// </summary>
        /// <param name="dateTime">Tarih parametresi</param>
        /// <returns></returns>
        public static string FormatDate(this DateTime dateTime)
        {
            return dateTime.ToString("dd.MM.yyyy");
        }
        /// <summary>
        /// Verilen formata göre tarihi ayarlar.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string FormatDate(this DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// Verilen tarihin kaçıncı ayda olduğunu gösteren extension
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetMonth(this DateTime date)
        {
            return date.Month;
        }
    }
}
