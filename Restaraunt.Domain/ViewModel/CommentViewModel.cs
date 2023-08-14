using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public long DishId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

    }
}
