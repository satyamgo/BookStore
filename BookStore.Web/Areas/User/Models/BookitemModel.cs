using BookStore.Core.Entities.Models;

namespace BookStore.Web.Areas.User.Models
{
    public class BookitemModel
    {
        public int id { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public string content { get; set; }

        public int? StatusId { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public virtual Status Status { get; set; }
    }
}
