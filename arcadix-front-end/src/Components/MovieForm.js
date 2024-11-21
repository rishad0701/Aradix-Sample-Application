import React,{useState,useEffect} from 'react';
import {addMovie,updateMovie} from '../Services/movieService';

const MovieForm = ({movieToEdit,fetchMovies,handleCloseForm})=>{
    const [movieName,setMovieName] = useState('');
    const [reviewComments,setReviewComments] = useState('');
    const [isEditing,setEditing] = useState(false);


    useEffect(()=>{
        if(movieToEdit && movieToEdit.movieNameDto){
            setMovieName(movieToEdit.movieNameDto);
            setReviewComments(movieToEdit.reviewCommentsDto);
            setEditing(true);
        }else{
            setMovieName('');
            setReviewComments('');
            setEditing(false);
        }
    },[movieToEdit]);

    const handleSubmit = async(e)=>{
        e.preventDefault();

        const movie ={
            movieNameDto : movieName,
            reviewCommentsDto : reviewComments,
        };

        if(isEditing){
            await updateMovie({...movie,movieIdDto:movieToEdit.movieIdDto})
        }else{
            await addMovie(movie);
        }

        setMovieName('');
        setReviewComments('');
        setEditing(false);
        fetchMovies();
        handleCloseForm();
    }
    
    return(
        <div>
            <h3>{isEditing?'Edit Movie' : 'Add Movie'}</h3>

            <form onSubmit={handleSubmit}>
                <input 
                    type='text'
                    placeholder='Movie Name'
                    value={movieName}
                    onChange={(e)=>setMovieName(e.target.value)}
                    required
                />
                <textarea 
                    placeholder='Review Comments'
                    value={reviewComments}
                    onChange={(e)=>setReviewComments(e.target.value)}
                    required
                />
                <button type='submit' style={{marginRight : '10px'}}>{isEditing?'Update' : 'Add'}</button>
                <button type='button' onClick={handleCloseForm}>Cancel</button>
            </form>
        </div>
    )
} 


export default MovieForm;