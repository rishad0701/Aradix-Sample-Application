namespace DTOS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MovieReviewGetDTO
    {
        public int MovieIdDto { get; set; }

        public string MovieNameDto { get; set; } = null!;

        public string? ReviewCommentsDto { get; set; }
    }
}
