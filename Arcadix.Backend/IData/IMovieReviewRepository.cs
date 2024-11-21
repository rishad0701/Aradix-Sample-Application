namespace IData
{
    using DTOS;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMovieReviewRepository
    {
        Task<List<MovieReviewGetDTO>> GetMovies();
        Task<MovieReviewGetDTO> GetMovieById(int id);
        Task AddMovie(MovieReviewGetDTO movie);
        Task<bool> UpdateMovie(MovieReviewGetDTO movie);
        Task<bool> DeleteMovie(int Id);
    }
}
