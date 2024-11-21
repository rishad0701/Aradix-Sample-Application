namespace Data
{
    using API;
    using DTOS;
    using IData;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Formats.Asn1;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MovieReviewRepository : IMovieReviewRepository
    {
        public readonly MovieReviewContext _context;

        public MovieReviewRepository(MovieReviewContext context)
        {
            _context = context;
        }

        public async Task<List<MovieReviewGetDTO>> GetMovies() 
        {
            //var movies = await _context.Movies.ToListAsync();

            //List<MovieReviewGetDTO> moviesDto = new List<MovieReviewGetDTO>();

            //foreach(var mv in movies)
            //{
            //    moviesDto.Add(new MovieReviewGetDTO() { MovieIdDto = mv.MovieId, MovieNameDto = mv.MovieName, ReviewCommentsDto = mv.ReviewComments });
            //}
            //return moviesDto;

            var moviesDto = await _context.Movies.
                                                              Select(
                                                                    m=>new MovieReviewGetDTO 
                                                                    { MovieIdDto = m.MovieId,
                                                                        MovieNameDto = m.MovieName,
                                                                        ReviewCommentsDto = m.ReviewComments
                                                                    }).ToListAsync();
            return moviesDto;
        }


        public async Task<MovieReviewGetDTO> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id); 

            if(movie == null)
            {
                throw new Exception("movie not found");
            }

            return (new MovieReviewGetDTO { MovieIdDto = movie.MovieId, MovieNameDto = movie.MovieName, ReviewCommentsDto = movie.ReviewComments });
        }


        public async Task AddMovie(MovieReviewGetDTO movie)
        {
            _context.Movies.Add(new Movie() { MovieName = movie.MovieNameDto, ReviewComments = movie.ReviewCommentsDto });
            await _context.SaveChangesAsync();
        }


        public async Task<bool> UpdateMovie(MovieReviewGetDTO movie)
        {
            var exist = await _context.Movies.FindAsync(movie.MovieIdDto);
            if (exist == null)
            {
                return false;   
            }
            exist.MovieName = movie.MovieNameDto;
            exist.ReviewComments = movie.ReviewCommentsDto;
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteMovie(int Id)
        {
            var movie = await _context.Movies.FindAsync(Id);
            
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
