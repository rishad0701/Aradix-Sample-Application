import React,{useState,useEffect} from 'react';
import {getMovies,deleteMovie} from '../Services/movieService';
import MovieForm from './MovieForm';
import './Home.css';


const Home = () =>{
    const[movies,setMovies] = useState([]);
    const[movieToEdit,setMovieToEdit] = useState(null);
    const[showForm,setShowForm] = useState(false);


    useEffect(()=>{
        /*debugger*/
        fetchMovies();
        console.log(movies);
    },[]);

    const fetchMovies = async()=>{
        const data = await getMovies();
        setMovies(data);
    };

    const handleDelete = async(movieIdDto)=>{
        await deleteMovie(movieIdDto);
        fetchMovies();
    }

    const handleEdit = async(movie)=>{
        setMovieToEdit(movie);
        setShowForm(true);
    }

    const hanldeAdd = ()=>{
        setMovieToEdit(null);
        setShowForm(true);
    }

    const handleCloseForm=()=>{
        setShowForm(false);
    };

    return(
        <div className="home-container">
            <h1>Movie Reviews</h1>
            <button onClick={hanldeAdd} style={{backgroundColor:'black'}}>Add New Movie</button>
            {
                showForm && (
                    <div className="movie-form-container">
                    <MovieForm
                    movieToEdit={movieToEdit}
                    fetchMovies={fetchMovies}
                    handleCloseForm={handleCloseForm}
                    />
                    </div>
                )
            }
            <table>
                <thead>
                    <tr>
                        <th>Movie Name</th>
                        <th>Movie COmments</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                   {movies.map((movie)=>(
                    <tr key={movie.movieIdDto}>
                        <td>{movie.movieNameDto}</td>
                        <td>{movie.reviewCommentsDto}</td>
                        <td>
                            <button onClick={()=>handleEdit(movie)} style={{marginRight : '10px'}}>Edit</button>
                            <button onClick={()=>handleDelete(movie.movieIdDto)} style={{backgroundColor: '#dc3545' }}>Delete</button>
                        </td>
                    </tr>
                   ))} 
                </tbody>
            </table>
        </div>
    )
}


export default Home;