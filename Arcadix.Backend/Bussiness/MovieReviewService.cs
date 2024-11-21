namespace Bussiness
{
    using API;
    using DTOS;
    using IBussiness;
    using IData;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MovieReviewService : IMovieReviewService
    {
        public readonly IMovieReviewRepository _movieReviewRepository;

        public MovieReviewService(IMovieReviewRepository movieReviewRepository)
        {
            _movieReviewRepository = movieReviewRepository;
        }
        public async Task<List<MovieReviewGetDTO>> GetMovies()
        {
            return await _movieReviewRepository.GetMovies();
        }


        public async Task<MovieReviewGetDTO> GetMovieById(int id)
        {
            var movie = await _movieReviewRepository.GetMovieById(id);

            return movie;
        }


        public async Task AddMovie(MovieReviewGetDTO movie)
        {
            await _movieReviewRepository.AddMovie(movie);
        }


        public async Task<bool> UpdateMovie(MovieReviewGetDTO movie)
        {
            return await _movieReviewRepository.UpdateMovie(movie);
        }


        public async Task<bool> DeleteMovie(int Id)
        {
            return await _movieReviewRepository.DeleteMovie(Id);
        }
    }
}
