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

        public string Description => $"Страница {CurrentPage} из {TotalPages}. Всего {TotalItems} элементов.";

        public void Next()
        {
            if (CurrentPage < TotalPages)
                CurrentPage++;
            else
                CurrentPage = TotalPages;
        }

        public void Back()
        {
            if (CurrentPage > 1)
                CurrentPage--;
        }

        public void ToStart()
        {
            CurrentPage = 1;
        }

        public void ToEnd()
        {
            CurrentPage = TotalPages;
        }
    }
}
