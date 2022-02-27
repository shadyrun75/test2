using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib
{
    public class PagingInfo
    {
        /// <summary>
        /// Всего элементов
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// Элементов на страницу
        /// </summary>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// Текущая страница
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Всего страниц
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (ItemsPerPage == 0)
                    return 0;
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}
